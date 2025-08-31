using TCSTest.Models;
using TCSTest.DTOs;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<List<ContentDTO>> GetAllContentsAsync(CancellationToken cancellationToken)
        {
            var contents = await _contentRepository.GetAllContentsAsync(cancellationToken);
            return contents.Select(c => new ContentDTO
            {
                ContentId = c.ContentId,
                Title = c.Title,
                Type = c.Type,
                Genre = c.Genre,
                DurationMinutes = c.DurationMinutes,
                Rating = c.Rating,
                Year = c.Year,
                Season = c.Season,
                Episode = c.Episode
            }).ToList();
        }

        public async Task<ContentDTO?> GetContentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetContentByIdAsync(id, cancellationToken);
            if (content == null) return null;

            return new ContentDTO
            {
                ContentId = content.ContentId,
                Title = content.Title,
                Type = content.Type,
                Genre = content.Genre,
                DurationMinutes = content.DurationMinutes,
                Rating = content.Rating,
                Year = content.Year,
                Season = content.Season,
                Episode = content.Episode
            };
        }

        public async Task<ContentDTO> AddContentAsync(ContentDTO content, CancellationToken cancellationToken)
        {
            var newContent = new Content
            {
                ContentId = Guid.NewGuid(),
                Title = content.Title,
                Type = content.Type,
                Genre = content.Genre,
                DurationMinutes = content.DurationMinutes,
                Rating = content.Rating,
                Year = content.Year,
                Season = content.Season,
                Episode = content.Episode
            };

            var result = await _contentRepository.AddContentAsync(newContent, cancellationToken);

            return new ContentDTO
            {
                ContentId = result.ContentId,
                Title = result.Title,
                Type = result.Type,
                Genre = result.Genre,
                DurationMinutes = result.DurationMinutes,
                Rating = result.Rating,
                Year = result.Year,
                Season = result.Season,
                Episode = result.Episode
            };
        }

        public async Task<ContentDTO> UpdateContentAsync(ContentDTO content, CancellationToken cancellationToken)
        {
            var updatedContent = new Content
            {
                ContentId = (Guid)content.ContentId,
                Title = content.Title,
                Type = content.Type,
                Genre = content.Genre,
                DurationMinutes = content.DurationMinutes,
                Rating = content.Rating,
                Year = content.Year,
                Season = content.Season,
                Episode = content.Episode
            };

            var result = await _contentRepository.UpdateContentAsync(updatedContent, cancellationToken);

            return new ContentDTO
            {
                ContentId = result.ContentId,
                Title = result.Title,
                Type = result.Type,
                Genre = result.Genre,
                DurationMinutes = result.DurationMinutes,
                Rating = result.Rating,
                Year = result.Year,
                Season = result.Season,
                Episode = result.Episode
            };
        }

        public async Task<ContentDTO> DeleteContentAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _contentRepository.DeleteContentAsync(id, cancellationToken);

            return new ContentDTO
            {
                ContentId = result.ContentId,
                Title = result.Title,
                Type = result.Type,
                Genre = result.Genre,
                DurationMinutes = result.DurationMinutes,
                Rating = result.Rating,
                Year = result.Year,
                Season = result.Season,
                Episode = result.Episode
            };
        }
    }
}
