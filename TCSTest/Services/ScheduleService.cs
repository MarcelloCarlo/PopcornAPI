using Microsoft.EntityFrameworkCore;
using System.Linq;
using TCSTest.DTOs;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleDTO>> GetAllSchedulesAsync(CancellationToken cancellationToken)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesAsync(cancellationToken);

            return schedules.Where(s => s.Channel != null && s.Content != null && s.ChannelId == s.Channel.ChannelId && s.ContentId == s.Content.ContentId).Select(s => new ScheduleDTO
            {
                ChannelId = s.ChannelId,
                ContentId = s.ContentId,
                AirTime = s.AirTime,
                EndTime = s.EndTime,
                Channel = new ChannelDTO
                {
                    ChannelId = s.Channel.ChannelId,
                    Name = s.Channel.Name,
                    Category = s.Channel.Category,
                    Language = s.Channel.Language,
                    Region = s.Channel.Region
                },
                Content = new ContentDTO
                {
                    ContentId = s.Content.ContentId,
                    Title = s.Content.Title,
                    Type = s.Content.Type,
                    Genre = s.Content.Genre,
                    DurationMinutes = s.Content.DurationMinutes,
                    Rating = s.Content.Rating,
                    Year = s.Content.Year,
                    Season = s.Content.Season,
                    Episode = s.Content.Episode
                }
            }).ToList();
        }

        public async Task<ScheduleDTO?> GetScheduleByChannelIdAsync(Guid channelId, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetAllSchedulesAsync(cancellationToken);
            return schedule.Where(s => s.ChannelId == channelId).Select(s => new ScheduleDTO
            {
                ChannelId = s.ChannelId,
                ContentId = s.ContentId,
                AirTime = s.AirTime,
                EndTime = s.EndTime,
                Channel = new ChannelDTO
                {
                    ChannelId = s.Channel.ChannelId,
                    Name = s.Channel.Name,
                    Category = s.Channel.Category,
                    Language = s.Channel.Language,
                    Region = s.Channel.Region
                },
                Content = new ContentDTO
                {
                    ContentId = s.Content.ContentId,
                    Title = s.Content.Title,
                    Type = s.Content.Type,
                    Genre = s.Content.Genre,
                    DurationMinutes = s.Content.DurationMinutes,
                    Rating = s.Content.Rating,
                    Year = s.Content.Year,
                    Season = s.Content.Season,
                    Episode = s.Content.Episode
                }
            }).FirstOrDefault();
        }

        public async Task<List<ScheduleDTO>> GetCurrentScheduleAsync(CancellationToken cancellationToken)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesAsync(cancellationToken);
            return schedules.Where(s => s.AirTime.Date <= DateTime.UtcNow.Date && s.EndTime.Date >= DateTime.UtcNow.Date).Select(s => new ScheduleDTO
            {
                ChannelId = s.ChannelId,
                ContentId = s.ContentId,
                AirTime = s.AirTime,
                EndTime = s.EndTime,
                Channel = new ChannelDTO
                {
                    ChannelId = s.Channel.ChannelId,
                    Name = s.Channel.Name,
                    Category = s.Channel.Category,
                    Language = s.Channel.Language,
                    Region = s.Channel.Region
                },
                Content = new ContentDTO
                {
                    ContentId = s.Content.ContentId,
                    Title = s.Content.Title,
                    Type = s.Content.Type,
                    Genre = s.Content.Genre,
                    DurationMinutes = s.Content.DurationMinutes,
                    Rating = s.Content.Rating,
                    Year = s.Content.Year,
                    Season = s.Content.Season,
                    Episode = s.Content.Episode
                }
            }).ToList();

        }

        public async Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO schedule, CancellationToken cancellationToken)
        {
            ValidateAirTimeEndTime(schedule);

            var newSchedule = new Schedule
            {
                ChannelId = Guid.NewGuid(),
                ContentId = schedule.ContentId,
                AirTime = schedule.AirTime,
                EndTime = schedule.EndTime,
            };

            var addedSchedule = await _scheduleRepository.AddScheduleAsync(newSchedule, cancellationToken);

            return new ScheduleDTO
            {
                ChannelId = addedSchedule.ChannelId,
                ContentId = addedSchedule.ContentId,
                AirTime = addedSchedule.AirTime,
                EndTime = addedSchedule.EndTime
            };
        }

        public async Task<ScheduleDTO> UpdateScheduleAsync(ScheduleDTO schedule, CancellationToken cancellationToken)
        {
            ValidateAirTimeEndTime(schedule);

            var updatedSchedule = new Schedule
            {
                ChannelId = schedule.ChannelId,
                ContentId = schedule.ContentId,
                AirTime = schedule.AirTime,
                EndTime = schedule.EndTime,
            };

            var result = await _scheduleRepository.UpdateScheduleAsync(updatedSchedule, cancellationToken);

            return new ScheduleDTO
            {
                ChannelId = result.ChannelId,
                ContentId = result.ContentId,
                AirTime = result.AirTime,
                EndTime = result.EndTime
            };
        }

        public async Task<ScheduleDTO> DeleteScheduleAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken)
        {
            var deletedSchedule = await _scheduleRepository.DeleteScheduleAsync(channelId, contentId, cancellationToken);

            return new ScheduleDTO
            {
                ChannelId = deletedSchedule.ChannelId,
                ContentId = deletedSchedule.ContentId,
                AirTime = deletedSchedule.AirTime,
                EndTime = deletedSchedule.EndTime
            };
        }

        /// <summary>
        /// Validates the AirTime and EndTime properties of a ScheduleDTO.
        /// </summary>
        /// <param name="schedule">Schedule to validate.</param>
        /// <exception cref="ArgumentException">Air/End time error result.</exception>
        private void ValidateAirTimeEndTime(ScheduleDTO schedule)
        {
            if (schedule.AirTime >= schedule.EndTime)
            {
                throw new ArgumentException("AirTime must be earlier than EndTime.");
            }

            if ((schedule.EndTime - schedule.AirTime).TotalMinutes < 1)
            {
                throw new ArgumentException("Schedule duration must be at least 1 minute.");
            }
        }
    }
}