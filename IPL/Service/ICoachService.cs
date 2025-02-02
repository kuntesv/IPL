
using IPLDataModels;
namespace IPL.Service
{
    public interface ICoachService
    {
        /// <summary>
        /// This method is used to create new coach in Coaches table.
        /// </summary>
        /// <param name="coachInput">The coach to be created in the table</param>
        /// <returns>It will return the instance of created coach.</returns>
        public Task<Coach> CreateCoachAsync(Coach coachInput);

        /// <summary>
        /// This method will return the coach details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the coach in the Coaches table.</param>
        /// <returns>Will return the Coach details for give id.</returns>
        public Task<Coach> GetCoachDetailsByIdAsync(int id);


        /// <summary>
        /// This method will return the coaches based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will returnt he instace of IEnumerable of Coach type</returns>
        public List<Coach> GetAllCoaches(int limit, int skip);

        /// <summary>
        /// This method will remove the Coach from the Coaches table for given id.
        /// </summary>
        /// <param name="coachId">Integer instance indicating the primary key of table for coachId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public Task RemoveCoachAsync(int coachId);


    }
}
