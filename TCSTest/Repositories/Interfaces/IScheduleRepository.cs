using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        /// <summary>
        /// Gets all schedules.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of schedules.</returns>
        Task<List<Schedule>> GetAllSchedulesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a schedule by its ID.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="contentId">The ID of the content.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The schedule, if found; otherwise, null.</returns>
        Task<Schedule?> GetScheduleByIdAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="schedule">The schedule to add.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The added schedule.</returns>
        Task<Schedule> AddScheduleAsync(Schedule schedule, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing schedule.
        /// </summary>
        /// <param name="schedule">The schedule to update.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated schedule.</returns>
        Task<Schedule> UpdateScheduleAsync(Schedule schedule, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a schedule.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="contentId">The ID of the content.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted schedule.</returns>
        Task<Schedule> DeleteScheduleAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken = default);
    }
}
