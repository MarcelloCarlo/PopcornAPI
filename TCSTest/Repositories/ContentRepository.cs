using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly ApplicationDbContext _context;

        public ContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Content>> GetAllContentsAsync(CancellationToken cancellationToken)
        {
            return await _context.ParseAsync<Content>(cancellationToken);
        }

        public async Task<Content?> GetContentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var contents = await _context.ParseAsync<Content>(cancellationToken);
            return contents.FirstOrDefault(c => c.ContentId == id);
        }

        public async Task<Content> AddContentAsync(Content content, CancellationToken cancellationToken)
        {
            var contents = await _context.ParseAsync<Content>(cancellationToken);

            if (!contents.Any(c => c.ContentId == content.ContentId))
            {
                contents.Add(content);
                await _context.SaveAsync(contents, cancellationToken);
            }
            return content;
        }

        public async Task<Content> UpdateContentAsync(Content content, CancellationToken cancellationToken)
        {
            var contents = await _context.ParseAsync<Content>(cancellationToken);
            var existingContent = contents.FirstOrDefault(c => c.ContentId == content.ContentId);

            if (existingContent != null)
            {
                contents.Remove(existingContent);
                contents.Add(content);
                await _context.SaveAsync(contents, cancellationToken);
            }
            return content;
        }

        public async Task<Content> DeleteContentAsync(Guid id, CancellationToken cancellationToken)
        {
            var contents = await _context.ParseAsync<Content>(cancellationToken);
            var contentToRemove = contents.FirstOrDefault(c => c.ContentId == id);

            if (contentToRemove != null)
            {
                contents.Remove(contentToRemove);
                await _context.SaveAsync(contents, cancellationToken);
            }
            return contentToRemove!;
        }
    }
}