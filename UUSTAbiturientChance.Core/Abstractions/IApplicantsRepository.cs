using CSharpFunctionalExtensions;
using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.DataAccess.Repositories
{
    public interface IApplicantsRepository
    {
        Task<Result> Create(Applicant applicant);
        Task<Result<string>> Delete(string uniqueCode);
        Task<Result<List<Applicant>>> GetAll();
        Task<Result<Applicant>> GetByUniqueCode(string uniqueCode);
        Task<Result<string>> Update(string uniqueCode, int pCode, bool hasNoEntranceTests, int totalCompetitiveScore, int totalEntranceTestsScore, int mathScore, int physicsScore, int russianScore, int achievementsScore, bool hasFirstPriorityRightArticle, bool hasSecondPriorityRightArticle, bool hasEnrollmentConsent, int priority);
    }
}