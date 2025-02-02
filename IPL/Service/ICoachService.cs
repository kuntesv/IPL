
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
    }
}
