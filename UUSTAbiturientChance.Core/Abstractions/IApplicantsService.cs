using CSharpFunctionalExtensions;
using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.Application.Srvices
{
    public interface IApplicantsService
    {
        Task<Result> CreateApplicant(Applicant applicant);
        Task<Result<string>> DeleteApplicant(string uniqueCode);
        Task<Result<List<Applicant>>> GetAllApplicants();
        Task<Result<Applicant>> GetApplicantByUniqueCode(string uniqueCode);
        Task<Result<string>> UpdateApplicant(string uniqueCode, int pCode, bool hasNoEntranceTests, int totalCompetitiveScore, int totalEntranceTestsScore, int mathScore, int physicsScore, int russianScore, int achievementsScore, bool hasFirstPriorityRightArticle, bool hasSecondPriorityRightArticle, bool hasEnrollmentConsent, int priority);
    }
}