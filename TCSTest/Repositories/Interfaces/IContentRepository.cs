using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces
{
    public interface IContentRepository
    {
        /// <summary>
        /// Gets all content items.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A list of content items.</returns>
        Task<List<Content>> GetAllContentsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a content item by its ID.
        /// </summary>
        /// <param name="id">The ID of the content.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The content item, or null if not found.</returns>
        Task<Content?> GetContentByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new content item.
        /// </summary>
        /// <param name="content">The content item to add.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The added content.</returns>
        Task<Content> AddContentAsync(Content content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing content item.
        /// </summary>
        /// <param name="content">The content item to update.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated content.</returns>
        Task<Content> UpdateContentAsync(Content content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a content item by its ID.
        /// </summary>
        /// <param name="id">The ID of the content to delete.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted content, or null if not found.</returns>
        Task<Content> DeleteContentAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
