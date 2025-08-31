using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;
        private readonly ILogger<ChannelController> _logger;

        public ChannelController(IChannelService channelService, ILogger<ChannelController> logger)
        {
            _channelService = channelService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <returns>A list of channels.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllChannels()
        {
            try
            {
                var channels = await _channelService.GetAllChannelsAsync();
                return Ok(channels);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching channels");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <returns>The channel, if found; otherwise, null.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChannelById(Guid id)
        {
            try
            {
                var channel = await _channelService.GetChannelByIdAsync(id);
                if (channel == null)
                {
                    return NotFound("Channel not found");
                }
                return Ok(channel);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching channel with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new channel.
        /// </summary>
        /// <param name="channel">The channel to add.</param>
        /// <returns>The added channel.</returns>
        [HttpPost]
        public async Task<IActionResult> AddChannel([FromBody] ChannelDTO channel)
        {
            try
            {
                var result = await _channelService.AddChannelAsync(channel);
                return CreatedAtAction(nameof(GetChannelById), new { id = result.ChannelId }, result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while adding channel");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing channel.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <param name="channel">The updated channel information.</param>
        /// <returns>The updated channel.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChannel(Guid id, [FromBody] ChannelDTO channel)
        {
            try
            {
                if (id != channel.ChannelId)
                {
                    return BadRequest("Channel ID mismatch");
                }

                var result = await _channelService.UpdateChannelAsync(channel);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating channel with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a channel.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <returns>The deleted channel.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannel(Guid id)
        {
            try
            {
                var result = await _channelService.DeleteChannelAsync(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting channel with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
