using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Schedule>> GetAllSchedulesAsync(CancellationToken cancellationToken)
        {
            var schedules = await _context.ParseAsync<Schedule>(cancellationToken);
            var channels = await _context.ParseAsync<Channel>(cancellationToken);
            var contents = await _context.ParseAsync<Content>(cancellationToken);

            var fullSchedules = schedules.Select(s =>
            {
                s.Channel = channels.FirstOrDefault(c => c.ChannelId == s.ChannelId);
                s.Content = contents.FirstOrDefault(c => c.ContentId == s.ContentId);
                return s;
            }).AsQueryable();

            return fullSchedules;
        }

        public async Task<Schedule?> GetScheduleByIdAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken)
        {
            var schedules = await _context.ParseAsync<Schedule>(cancellationToken);
            return schedules.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
        }

        public async Task<Schedule> AddScheduleAsync(Schedule schedule, CancellationToken cancellationToken)
        {
            var schedules = await _context.ParseAsync<Schedule>(cancellationToken);

            if (!schedules.Any(s => s.ChannelId == schedule.ChannelId && s.ContentId == schedule.ContentId))
            {
                schedules.Add(schedule);
                await _context.SaveAsync(schedules, cancellationToken);
            }
            return schedule;
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule, CancellationToken cancellationToken)
        {
            var schedules = await _context.ParseAsync<Schedule>(cancellationToken);
            var existingSchedule = schedules.FirstOrDefault(s => s.ChannelId == schedule.ChannelId && s.ContentId == schedule.ContentId);
            if (existingSchedule != null)
            {
                schedules.Remove(existingSchedule);
                schedules.Add(schedule);
                await _context.SaveAsync(schedules, cancellationToken);
            }
            return schedule;
        }

        public async Task<Schedule> DeleteScheduleAsync(Guid channelId, Guid contentId, CancellationToken cancellationToken)
        {
            var schedules = await _context.ParseAsync<Schedule>(cancellationToken);
            var schedule = schedules.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (schedule != null)
            {
                schedules.Remove(schedule);
                await _context.SaveAsync(schedules, cancellationToken);
            }
            return schedule;
        }
    }
}
