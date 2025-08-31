using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces
{
    public interface IChannelRepository
    {
        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of channels.</returns>
        Task<List<Channel>> GetAllChannelsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The channel with the specified ID, or null if not found.</returns>
        Task<Channel?> GetChannelByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new channel.
        /// </summary>
        /// <param name="channel">The channel to add.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The added channel.</returns>
        Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing channel.
        /// </summary>
        /// <param name="channel">The channel to update.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated channel.</returns>
        Task<Channel> UpdateChannelAsync(Channel channel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel to delete.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted channel.</returns>
        Task<Channel> DeleteChannelAsync(Guid id, CancellationToken cancellationToken = default);
    }
}