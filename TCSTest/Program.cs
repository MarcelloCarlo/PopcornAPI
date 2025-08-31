using Microsoft.EntityFrameworkCore;
using TCSTest.Data;
using TCSTest.Repositories;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services;
using TCSTest.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added some EF flavour but not fully used (json file is still the primary datasource)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("PopcornDB"));

// Repositories
builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

// Services
builder.Services.AddScoped<IChannelService, ChannelService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
