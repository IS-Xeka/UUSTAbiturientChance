using CSharpFunctionalExtensions;
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
    [Route("GetByUniqueCode")]
    public async Task<ActionResult<ApplicantResponse>> GetByUniqueCode(string uniqueCode)
    {
        var applicantResult = await _applicantsService.GetApplicantByUniqueCode(uniqueCode);
        var applicant = applicantResult.Value;
        var applicantResponse = new ApplicantResponse
        (
            applicant.UniqueCode,
            applicant.PCode,
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
    [Route("CreateApplicant")]
    public async Task<ActionResult> CreateApplicant([FromBody] ApplicantRequest request)
    {
        var applicantResult = Applicant.Create(
            request.UniqueCode,
            request.PCode,
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

        await _applicantsService.CreateApplicant(applicantResult.Value);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        var applicantEntitesResult = await _applicantsService.GetAllApplicants();
        return Ok(applicantEntitesResult.Value.Select(a => new ApplicantResponse
        (
            a.UniqueCode,
            a.PCode,
            a.HasNoEntranceTests,
            a.TotalCompetitiveScore,
            a.TotalEntranceTestsScore,
            a.MathAlgebraGeometryScore,
            a.InformatcPhysicScore,
            a.RussianLanguageScore,
            a.IndividualAchievementsScore,
            a.HasFirstPriorityRightArticle,
            a.HasSecondPriorityRightArticle,
            a.HasEnrollmentConsent,
            a.Priority
            )).ToList());
    }
}
