using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.DataAccess.Repositories
{
    public interface IApplicantsRepository
    {
        Task Create(Applicant applicant);
        Task<Applicant> GetByUniqueCode(string uniqueCode);
    }
}