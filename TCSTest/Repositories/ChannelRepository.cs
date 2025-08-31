using Microsoft.EntityFrameworkCore;
using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ApplicationDbContext _context;

        public ChannelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Channel>> GetAllChannelsAsync(CancellationToken cancellationToken)
        {
            return await _context.ParseAsync<Channel>(cancellationToken);
        }

        public async Task<Channel?> GetChannelByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var channels = await _context.ParseAsync<Channel>(cancellationToken);
            return channels.FirstOrDefault(c => c.ChannelId == id);
        }

        public async Task<Channel> AddChannelAsync(Channel channel, CancellationToken cancellationToken)
        {
            var channels = await _context.ParseAsync<Channel>(cancellationToken);

            if (!channels.Any(c => c.ChannelId == channel.ChannelId))
            {
                channels.Add(channel);
                await _context.SaveAsync(channels);
            }
            return channel;
        }

        public async Task<Channel> UpdateChannelAsync(Channel channel, CancellationToken cancellationToken)
        {
            var channels = await _context.ParseAsync<Channel>(cancellationToken);
            var existingChannel = channels.FirstOrDefault(c => c.ChannelId == channel.ChannelId);
            if (existingChannel != null)
            {
                channels.Remove(existingChannel);
                channels.Add(channel);
                await _context.SaveAsync(channels);
            }
            return channel;
        }

        public async Task<Channel> DeleteChannelAsync(Guid id, CancellationToken cancellationToken)
        {
            var channels = await _context.ParseAsync<Channel>(cancellationToken);
            var existingChannel = channels.FirstOrDefault(c => c.ChannelId == id);
            if (existingChannel != null)
            {
                channels.Remove(existingChannel);
                await _context.SaveAsync(channels, cancellationToken);
            }
            return existingChannel;
        }
    }
}