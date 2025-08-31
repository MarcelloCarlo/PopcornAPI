using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        private readonly ILogger<ContentController> _logger;

        public ContentController(IContentService contentService, ILogger<ContentController> logger)
        {
            _contentService = contentService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all content items.
        /// </summary>
        /// <returns>A list of content items.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllContents()
        {
            try
            {
                var contents = await _contentService.GetAllContentsAsync();
                return Ok(contents);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching contents");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a content item by its ID.
        /// </summary>
        /// <param name="id">The ID of the content.</param>
        /// <returns>The content item, or null if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentById(Guid id)
        {
            try
            {
                var content = await _contentService.GetContentByIdAsync(id);
                if (content == null)
                {
                    return NotFound("Content not found");
                }
                return Ok(content);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching content with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new content item.
        /// </summary>
        /// <param name="content">The content item to add.</param>
        /// <returns>The added content.</returns>
        [HttpPost]
        public async Task<IActionResult> AddContent([FromBody] ContentDTO content)
        {
            try
            {
                var result = await _contentService.AddContentAsync(content);
                return CreatedAtAction(nameof(GetContentById), new { id = result.ContentId }, result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while adding content");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing content item.
        /// </summary>
        /// <param name="id">The ID of the content to update.</param>
        /// <param name="content">The updated content item.</param>
        /// <returns>The updated content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent(Guid id, [FromBody] ContentDTO content)
        {
            try
            {
                if (id != content.ContentId)
                {
                    return BadRequest("Content ID mismatch");
                }
                var result = await _contentService.UpdateContentAsync(content);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating content with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a content item.
        /// </summary>
        /// <param name="id">The ID of the content to delete.</param>
        /// <returns>The deleted content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(Guid id)
        {
            try
            {
                var result = await _contentService.DeleteContentAsync(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting content with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
