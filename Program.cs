using Microsoft.EntityFrameworkCore;
using StoryDragon.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReactApp",
        builder => {
            builder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoryDragonContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("StoryDragonConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();

