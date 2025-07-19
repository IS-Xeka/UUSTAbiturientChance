using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using UUSTAbiturientChance.Application.Srvices.Entities;

namespace UUSTAbiturientChance.DataAccess.Configurations;

public class ApplicantsConfiguration : IEntityTypeConfiguration<ApplicantEntity>
{
    public void Configure(EntityTypeBuilder<ApplicantEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.UniqueCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.HasNoEntranceTests)
            .IsRequired();

        builder.Property(a => a.TotalCompetitiveScore)
            .IsRequired();

        builder.Property(a => a.TotalEntranceTestsScore)
            .IsRequired();

        builder.Property(a => a.MathAlgebraGeometryScore)
            .IsRequired();

        builder.Property(a => a.InformatcPhysicScore)
            .IsRequired();

        builder.Property(a => a.RussianLanguageScore)
            .IsRequired();

        builder.Property(a => a.IndividualAchievementsScore)
            .IsRequired();

        builder.Property(a => a.HasFirstPriorityRightArticle)
            .IsRequired();

        builder.Property(a => a.HasSecondPriorityRightArticle)
            .IsRequired();

        builder.Property(a => a.HasEnrollmentConsent)
            .IsRequired();

        builder.Property(a => a.Priority)
            .IsRequired();

        var serializerOptions = new JsonSerializerOptions();

        builder.Property(a => a.AppliedPrograms)
            .HasConversion(
                v => JsonSerializer.Serialize(v, serializerOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, serializerOptions))
            .IsRequired();

        // Опционально: индексы для часто используемых полей
        builder.HasIndex(a => a.UniqueCode)
            .IsUnique();

        builder.HasIndex(a => a.TotalCompetitiveScore);
    }
}
