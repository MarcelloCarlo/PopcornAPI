using TCSTest.Models;
using TCSTest.DTOs;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;

        public ChannelService(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public async Task<List<ChannelDTO>> GetAllChannelsAsync(CancellationToken cancellationToken)
        {
            var channels = await _channelRepository.GetAllChannelsAsync(cancellationToken);
            return channels.Select(c => new ChannelDTO
            {
                ChannelId = c.ChannelId,
                Name = c.Name,
                Category = c.Category,
                Language = c.Language,
                Region = c.Region
            }).ToList();
        }

        public async Task<ChannelDTO?> GetChannelByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(id, cancellationToken);
            if (channel == null) return null;

            return new ChannelDTO
            {
                ChannelId = channel.ChannelId,
                Name = channel.Name,
                Category = channel.Category,
                Language = channel.Language,
                Region = channel.Region
            };
        }

        public async Task<ChannelDTO> AddChannelAsync(ChannelDTO channel, CancellationToken cancellationToken)
        {
            var newChannel = new Channel
            {
                ChannelId = channel.ChannelId ?? Guid.NewGuid(),
                Name = channel.Name,
                Category = channel.Category,
                Language = channel.Language,
                Region = channel.Region
            };

            var addedChannel = await _channelRepository.AddChannelAsync(newChannel, cancellationToken);

            return new ChannelDTO
            {
                ChannelId = addedChannel.ChannelId,
                Name = addedChannel.Name,
                Category = addedChannel.Category,
                Language = addedChannel.Language,
                Region = addedChannel.Region
            };
        }

        public async Task<ChannelDTO> UpdateChannelAsync(ChannelDTO channel, CancellationToken cancellationToken)
        {
            var updatedChannel = new Channel
            {
                ChannelId = (Guid)channel.ChannelId,
                Name = channel.Name,
                Category = channel.Category,
                Language = channel.Language,
                Region = channel.Region
            };

            var result = await _channelRepository.UpdateChannelAsync(updatedChannel, cancellationToken);

            return new ChannelDTO
            {
                ChannelId = result.ChannelId,
                Name = result.Name,
                Category = result.Category,
                Language = result.Language,
                Region = result.Region
            };
        }

        public async Task<ChannelDTO> DeleteChannelAsync(Guid id, CancellationToken cancellationToken)
        {
            var deletedChannel = await _channelRepository.DeleteChannelAsync(id, cancellationToken);

            return new ChannelDTO
            {
                ChannelId = deletedChannel.ChannelId,
                Name = deletedChannel.Name,
                Category = deletedChannel.Category,
                Language = deletedChannel.Language,
                Region = deletedChannel.Region
            };
        }
    }
}