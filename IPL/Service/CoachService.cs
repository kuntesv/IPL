using System.Data.Common;
using IPLDataModels;
using IPLDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPL.Service
{
    public class CoachService : ICoachService
    {
        IplSqlDbContext dbContext;

        public CoachService(IplSqlDbContext iplSqlDbContext)
        {
            dbContext = iplSqlDbContext;
        }

        public async Task<Coach> CreateCoachAsync(Coach coachInput)
        {

            try
            {
                var createdResponse = await dbContext.Coaches.AddAsync(coachInput);
                await dbContext.SaveChangesAsync();
                return createdResponse.Entity;
            }
            catch (DbException ex)
            {
                throw new Exception("Database Error while inserting data into Coaches table", ex);

            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occured ", ex);
            }
        }


        /// <summary>
        /// This method will return the coach details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the coach in the Coaches table.</param>
        /// <returns>Will return the Coach details for give id.</returns>
        public async Task<Coach> GetCoachDetailsByIdAsync(int id)
        {
            try
            {
                var response = await dbContext.Coaches.FirstOrDefaultAsync(q => q.Id == id);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will return the coaches based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will returnt he instace of IEnumerable of Coach type</returns>
        public List<Coach> GetAllCoaches(int limit, int skip)
        {
            return dbContext.Coaches.Skip(skip).Take(limit).ToList(); 
        }

        /// <summary>
        /// This method will remove the Coach from the Coaches table for given id.
        /// </summary>
        /// <param name="coachId">Integer instance indicating the primary key of table for coachId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public async Task RemoveCoachAsync(int coachId)
        {

            var coachToBeRemoved = await GetCoachDetailsByIdAsync(coachId);

            if (coachToBeRemoved != null)
            {
                dbContext.Remove(coachToBeRemoved);
                await dbContext.SaveChangesAsync();
            }

        }




    }
}
