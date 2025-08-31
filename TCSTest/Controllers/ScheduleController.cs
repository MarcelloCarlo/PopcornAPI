using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService scheduleService, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all schedules.
        /// </summary>
        /// <returns>A list of schedules.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ScheduleDTO>>> GetAllSchedules()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching schedules.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a schedule by channel ID.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <returns>The schedule, if found; otherwise, null.</returns>
        [HttpGet("{channelId}")]
        public async Task<ActionResult<ScheduleDTO?>> GetScheduleByChannelId(Guid channelId)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByChannelIdAsync(channelId);
                if (schedule == null)
                {
                    return NotFound();
                }
                return Ok(schedule);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching schedule.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the current schedule.
        /// </summary>
        /// <returns>A list of current schedules.</returns>
        [HttpGet("now")]
        public async Task<ActionResult<List<ScheduleDTO>>> GetCurrentSchedule()
        {
            try
            {
                var schedules = await _scheduleService.GetCurrentScheduleAsync();
                return Ok(schedules);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching current schedules.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="schedule">The schedule to add.</param>
        /// <returns>The added schedule.</returns>
        [HttpPost]
        public async Task<ActionResult> AddSchedule(ScheduleDTO schedule)
        {
            try
            {
                var result = await _scheduleService.AddScheduleAsync(schedule);
                return CreatedAtAction(nameof(GetScheduleByChannelId), new { channelId = result.ChannelId }, result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding schedule.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="contentId">The ID of the content.</param>
        /// <param name="schedule">The schedule to add.</param>
        /// <returns>The updated schedule.</returns>
        [HttpPut("{channelId}/{contentId}")]
        public async Task<ActionResult> UpdateSchedule(Guid channelId, Guid contentId, ScheduleDTO schedule)
        {
            try
            {
                var result = await _scheduleService.UpdateScheduleAsync(schedule);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating schedule.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a schedule.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="contentId">The ID of the content.</param>
        /// <returns>The deleted schedule.</returns>
        [HttpDelete("{channelId}/{contentId}")]
        public async Task<ActionResult> DeleteSchedule(Guid channelId, Guid contentId)
        {
            try
            {
                var result = await _scheduleService.DeleteScheduleAsync(channelId, contentId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting schedule.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}