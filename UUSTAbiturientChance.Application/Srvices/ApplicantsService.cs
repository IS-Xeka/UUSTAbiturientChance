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

    public async Task CreateApplicant(Applicant applicant)
    {
        await _applicantsRepository.Create(applicant);
    }

    public async Task<Applicant> GetByUniqueCode(string uniqueCode)
    {
        return await _applicantsRepository.GetByUniqueCode(uniqueCode);
    }
}
