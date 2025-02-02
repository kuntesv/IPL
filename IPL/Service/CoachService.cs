using System.Data.Common;
using IPLDataModels;
using IPLDbContext;
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






    }
}
