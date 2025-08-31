using TCSTest.DTOs;

namespace TCSTest.Services.Interfaces
{
    public interface IScheduleService
    {
        /// <summary>
        /// Gets all schedules.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of schedules.</returns>
        Task<IQueryable<ScheduleDTO>> GetAllSchedulesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a schedule by channel ID.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The schedule, if found; otherwise, null.</returns>
        Task<ScheduleDTO?> GetScheduleByChannelIdAsync(Guid channelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the current schedule.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of current schedules.</returns>
        Task<List<ScheduleDTO>> GetCurrentScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="schedule">The schedule to add.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The added schedule.</returns>
        Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO schedule, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing schedule.
        /// </summary>
        /// <param name="schedule">The schedule to update.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated Schedule.</returns>
        Task<ScheduleDTO> UpdateScheduleAsync(ScheduleDTO schedule, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a schedule.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="contentId">The ID of the content.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted schedule.</returns>
        Task<ScheduleDTO> DeleteScheduleAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken = default);
    }
}