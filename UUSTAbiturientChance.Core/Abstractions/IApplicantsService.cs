using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.Application.Srvices
{
    public interface IApplicantsService
    {
        Task CreateApplicant(Applicant applicant);
        Task<Applicant> GetByUniqueCode(string uniqueCode);
    }
}