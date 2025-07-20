using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using UUSTAbiturientChance.Application.Srvices.Entities;
using UUSTAbiturientChance.Core.Models;
using UUSTAbiturientChance.DataAccess.Extensions;

namespace UUSTAbiturientChance.DataAccess.Repositories;

public class ApplicantsRepository : IApplicantsRepository
{
    private readonly UUSTAbiturientChanceDbContext _context;
    public ApplicantsRepository(UUSTAbiturientChanceDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Create(Applicant applicant)
    {
        var applicantEntity = new ApplicantEntity
        {
            UniqueCode = applicant.UniqueCode,
            PCode = applicant.PCode,
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
        return Result.Success();
    }

    public async Task<Result<List<Applicant>>> GetAll()
    {
        var applicantsEntity = await _context.Applicants
            .AsNoTracking()
            .ToListAsync();
        var applicants = applicantsEntity.Select(a => a.ToDomain()).ToList();
        return Result.Success(applicants);
    }

    public async Task<Result<Applicant>> GetByUniqueCode(string uniqueCode)
    {
        var applicantEntity = await _context.Applicants
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.UniqueCode == uniqueCode);

        return Result.Success(applicantEntity.ToDomain());
    }

    public async Task<Result<string>> Delete(string uniqueCode)
    {
        var applicant = await _context.Applicants.FirstOrDefaultAsync(a => a.UniqueCode == uniqueCode);
        if (applicant == null)
            await Console.Out.WriteLineAsync();

        _context.Applicants.Remove(applicant);
        await _context.SaveChangesAsync();
        return Result.Success(applicant.UniqueCode);
    }

    public async Task<Result<string>> Update(
        string uniqueCode,
        int pCode,
        bool hasNoEntranceTests,
        int totalCompetitiveScore,
        int totalEntranceTestsScore,
        int mathScore,
        int physicsScore,
        int russianScore,
        int achievementsScore,
        bool hasFirstPriorityRightArticle,
        bool hasSecondPriorityRightArticle,
        bool hasEnrollmentConsent,
        int priority)
    {
        if (!await _context.Applicants.AnyAsync(a => a.UniqueCode == uniqueCode))
            return "";
        await _context.Applicants.Where(a => a.UniqueCode == uniqueCode)
            .ExecuteUpdateAsync(app => app
                .SetProperty(a => a.PCode, pCode)
                .SetProperty(a => a.HasNoEntranceTests, hasNoEntranceTests)
                .SetProperty(a => a.TotalCompetitiveScore, totalCompetitiveScore)
                .SetProperty(a => a.TotalEntranceTestsScore, totalEntranceTestsScore)
                .SetProperty(a => a.MathAlgebraGeometryScore, mathScore)
                .SetProperty(a => a.InformatcPhysicScore, physicsScore)
                .SetProperty(a => a.RussianLanguageScore, russianScore)
                .SetProperty(a => a.IndividualAchievementsScore, achievementsScore)
                .SetProperty(a => a.HasFirstPriorityRightArticle, hasFirstPriorityRightArticle)
                .SetProperty(a => a.HasSecondPriorityRightArticle, hasSecondPriorityRightArticle)
                .SetProperty(a => a.HasEnrollmentConsent, hasEnrollmentConsent)
                .SetProperty(a => a.Priority, priority));
        return Result.Success(uniqueCode);
    }
}
