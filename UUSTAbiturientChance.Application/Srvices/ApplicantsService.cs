using CSharpFunctionalExtensions;
using UUSTAbiturientChance.Core.Models;
using UUSTAbiturientChance.DataAccess.Repositories;

namespace UUSTAbiturientChance.Application.Srvices;

public class ApplicantsService : IApplicantsService
{
    private readonly IApplicantsRepository _applicantsRepository;
    public ApplicantsService(IApplicantsRepository applicantsRepository)
    {
        _applicantsRepository = applicantsRepository;
    }

    public async Task<Result> CreateApplicant(Applicant applicant)
    {
        return Result.Success(await _applicantsRepository.Create(applicant));
    }

    public async Task<Result<string>> DeleteApplicant(string uniqueCode)
    {
        var updateResult = await _applicantsRepository.Delete(uniqueCode);
        return Result.Success(updateResult.Value);
    }

    public async Task<Result<List<Applicant>>> GetAllApplicants()
    {
        var getAllResult = await _applicantsRepository.GetAll();
        return Result.Success(getAllResult.Value);
    }

    public async Task<Result<Applicant>> GetApplicantByUniqueCode(string uniqueCode)
    {
        var getResult = await _applicantsRepository.GetByUniqueCode(uniqueCode);
        return Result.Success(getResult.Value);
    }

    public async Task<Result<string>> UpdateApplicant(string uniqueCode, int pCode, bool hasNoEntranceTests, int totalCompetitiveScore, int totalEntranceTestsScore, int mathScore, int physicsScore, int russianScore, int achievementsScore, bool hasFirstPriorityRightArticle, bool hasSecondPriorityRightArticle, bool hasEnrollmentConsent, int priority)
    {
        var updateResult = await _applicantsRepository.Update(
            uniqueCode,
            pCode,
            hasNoEntranceTests,
            totalCompetitiveScore,
            totalEntranceTestsScore,
            mathScore,
            physicsScore,
            russianScore,
            achievementsScore,
            hasFirstPriorityRightArticle,
            hasSecondPriorityRightArticle,
            hasEnrollmentConsent,
            priority
            );

        return Result.Success(updateResult.Value);
    }
}
