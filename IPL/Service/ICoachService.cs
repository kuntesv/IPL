
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


    }
}
