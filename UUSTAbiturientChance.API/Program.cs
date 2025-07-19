using Microsoft.EntityFrameworkCore;
using UUSTAbiturientChance.Application.Srvices;
using UUSTAbiturientChance.DataAccess;
using UUSTAbiturientChance.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IApplicantsService, ApplicantsService>();
builder.Services.AddScoped<IApplicantsRepository, ApplicantsRepository>();

builder.Services.AddDbContext<UUSTAbiturientChanceDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(UUSTAbiturientChanceDbContext)));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();


app.Run();
