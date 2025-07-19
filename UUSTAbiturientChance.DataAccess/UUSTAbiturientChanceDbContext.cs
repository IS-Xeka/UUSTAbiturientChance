using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UUSTAbiturientChance.Application.Srvices.Entities;

namespace UUSTAbiturientChance.DataAccess;

public class UUSTAbiturientChanceDbContext: DbContext
{
    public UUSTAbiturientChanceDbContext(DbContextOptions<UUSTAbiturientChanceDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<ApplicantEntity> Applicants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
