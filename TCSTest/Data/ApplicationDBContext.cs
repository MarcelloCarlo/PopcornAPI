using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCSTest.Models;

using Channel = TCSTest.Models.Channel;
namespace TCSTest.Data
{
    // The "DB Context" in question is the .json files
    public partial class ApplicationDbContext : DbContext
    {
        private class JSON_CONSTANTS
        {
            public const string SOURCE_DIRECTORY = "Json Store/";
            public const string JSON_FILE_EXTENSION = ".json";
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Channel>().ToTable("channels");   // maps Channel -> channels (e.g. channels.json)
            modelBuilder.Entity<Channel>().HasKey(c => c.ChannelId);

            modelBuilder.Entity<Content>().ToTable("content_catalog"); // maps Content -> content_catalog (e.g. content_catalog.json)
            modelBuilder.Entity<Content>().HasKey(c => c.ContentId);

            modelBuilder.Entity<Schedule>().ToTable("channel_schedule"); // maps Schedule -> channel_schedule (e.g. channel_schedule.json)
            modelBuilder.Entity<Schedule>()
                .HasKey(s => new { s.ChannelId, s.ContentId }); // Composite key for Schedule
        }

        public async Task<List<TSource>> ParseAsync<TSource>(CancellationToken cancellationToken = default)
        {
            if (!File.Exists(GetJsonFilePath<TSource>())) return new List<TSource>();

            var json = await File.ReadAllTextAsync(GetJsonFilePath<TSource>(), cancellationToken);
            return JsonSerializer.Deserialize<List<TSource>>(json) ?? new List<TSource>();
        }

        public async Task SaveAsync<TSource>(List<TSource> data, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(GetJsonFilePath<TSource>(), json, cancellationToken);
        }

        private string GetTableName<TSource>()
        {
            var entityType = Model.FindEntityType(typeof(TSource));
            return entityType?.GetTableName() ?? typeof(TSource).Name;
        }

        private string GetJsonFilePath<TSource>()
        {
            return Path.Combine(JSON_CONSTANTS.SOURCE_DIRECTORY, GetTableName<TSource>() + JSON_CONSTANTS.JSON_FILE_EXTENSION);
        }
    }
}