using System.Data.Common;
using IPLDataModels;
using IPLDbContext;

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


    }
}
