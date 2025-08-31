using TCSTest.DTOs;

namespace TCSTest.Services.Interfaces
{
    public interface IChannelService
    {
        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>A list of channels.</returns>
        Task<List<ChannelDTO>> GetAllChannelsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>The channel with the specified ID, or null if not found.</returns>
        Task<ChannelDTO?> GetChannelByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new channel.
        /// </summary>
        /// <param name="channel">The channel to add.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>The added channel.</returns>
        Task<ChannelDTO> AddChannelAsync(ChannelDTO channel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing channel.
        /// </summary>
        /// <param name="channel">The channel to update.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>The updated channel.</returns>
        Task<ChannelDTO> UpdateChannelAsync(ChannelDTO channel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel to delete.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>The deleted channel.</returns>
        Task<ChannelDTO> DeleteChannelAsync(Guid id, CancellationToken cancellationToken = default);
    }
}