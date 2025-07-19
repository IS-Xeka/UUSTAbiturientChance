using Microsoft.EntityFrameworkCore;
using UUSTAbiturientChance.Application.Srvices.Entities;
using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.DataAccess.Repositories;

public class ApplicantsRepository : IApplicantsRepository
{
    private readonly UUSTAbiturientChanceDbContext _context;
    public ApplicantsRepository(UUSTAbiturientChanceDbContext context)
    {
        _context = context;
    }

    public async Task Create(Applicant applicant)
    {
        var applicantEntity = new ApplicantEntity {
            Id = applicant.Id,
            PCode = applicant.PCode,
            UniqueCode = applicant.UniqueCode,
            HasNoEntranceTests = applicant.HasNoEntranceTests,
            TotalCompetitiveScore = applicant.TotalCompetitiveScore,
            TotalEntranceTestsScore = applicant.TotalEntranceTestsScore,
            MathAlgebraGeometryScore = applicant.MathAlgebraGeometryScore,
            InformatcPhysicScore = applicant.InformatcPhysicScore,
            RussianLanguageScore = applicant.RussianLanguageScore,
            IndividualAchievementsScore = applicant.IndividualAchievementsScore,
            HasFirstPriorityRightArticle = applicant.HasFirstPriorityRightArticle,
            HasSecondPriorityRightArticle = applicant.HasSecondPriorityRightArticle,
            HasEnrollmentConsent = applicant.HasEnrollmentConsent,
            Priority = applicant.Priority
            };
        await _context.AddAsync(applicantEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Applicant> GetByUniqueCode(string uniqueCode)
    {
        var applicantEntity = await _context.Applicants
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.UniqueCode == uniqueCode);

        return Applicant.Create(
            applicantEntity.Id,
            applicantEntity.PCode,
            applicantEntity.UniqueCode,
            applicantEntity.HasNoEntranceTests,
            applicantEntity.TotalCompetitiveScore,
            applicantEntity.TotalEntranceTestsScore,
            applicantEntity.MathAlgebraGeometryScore,
            applicantEntity.InformatcPhysicScore,
            applicantEntity.RussianLanguageScore,
            applicantEntity.IndividualAchievementsScore,
            applicantEntity.HasFirstPriorityRightArticle,
            applicantEntity.HasSecondPriorityRightArticle,
            applicantEntity.HasEnrollmentConsent,
            applicantEntity.Priority
            );
    }
}
