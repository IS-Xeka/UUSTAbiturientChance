using Microsoft.AspNetCore.Mvc;
using UUSTAbiturientChance.API.Contracts;
using UUSTAbiturientChance.Application.Srvices;
using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicantsController : Controller
{
    private readonly IApplicantsService _applicantsService;
    public ApplicantsController(IApplicantsService applicantsService)
    {
        _applicantsService = applicantsService;
    }
    [HttpGet]
    public async Task<ActionResult<ApplicantResponse>> GetByUniqueCode(string uniqueCode)
    {
        var applicant = await _applicantsService.GetByUniqueCode(uniqueCode);
        var applicantResponse = new ApplicantResponse
        (
            applicant.Id,
            applicant.PCode,
            applicant.UniqueCode,
            applicant.HasNoEntranceTests,
            applicant.TotalCompetitiveScore,
            applicant.TotalEntranceTestsScore,
            applicant.MathAlgebraGeometryScore,
            applicant.InformatcPhysicScore,
            applicant.RussianLanguageScore,
            applicant.IndividualAchievementsScore,
            applicant.HasFirstPriorityRightArticle,
            applicant.HasSecondPriorityRightArticle,
            applicant.HasEnrollmentConsent,
            applicant.Priority
        );

        return Ok(applicantResponse);
    }

    [HttpPost]
    public async Task<ActionResult> CreateApplicant([FromBody] ApplicantRequest request)
    {
        var applicant = Applicant.Create(
            Guid.NewGuid(),
            request.PCode,
            request.UniqueCode,
            request.HasNoEntranceTests,
            request.TotalCompetitiveScore,
            request.TotalEntranceTestsScore,
            request.MathScore,
            request.InfPhysicsScore,
            request.RussianScore,
            request.AchievementsScore,
            request.HasFirstPriorityRightArticle,
            request.HasSecondPriorityRightArticle,
            request.HasEnrollmentConsent,
            request.Priority
            );
        await _applicantsService.CreateApplicant(applicant);
        return Ok();
    }
}
