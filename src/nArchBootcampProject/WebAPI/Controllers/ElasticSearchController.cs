using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using Nest;
using WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ElasticSearchController : BaseController
{
    private readonly IElasticSearch _elasticSearch;
    
    
    public ElasticSearchController(IElasticSearch elasticSearch)
    {
        _elasticSearch = elasticSearch;
    }

    [HttpGet("search/instructors")]
    public async Task<IActionResult> Get()
    {

         await _elasticSearch.CreateNewIndexAsync(new IndexModel
        {
            IndexName = "instructors",
            AliasName = "ainstructors",
            NumberOfReplicas = 1,
            NumberOfShards = 1,
        }
        );
        var instructor = new ElasticSearchInsertUpdateModel(new CreateInstructorCommand
        {
            UserName = "EgeTaliko",
            FirstName = "Ege Umut",
            LastName = "Tali",
            DateOfBirth = new DateTime(2024, 4, 7, 1, 5, 2),
            NationalIdentity = "12123132154",
            CompanyName = "Tali A.Ş"
        });

        IElasticSearchResult result2 = await _elasticSearch.InsertAsync(instructor);
        IEnumerable<IndexName> result3 = _elasticSearch.GetIndexList().Keys;
        List<ElasticSearchGetModel<GetListInstructorListItemDto>> result4 = await _elasticSearch.GetSearchByField<GetListInstructorListItemDto>(new SearchByFieldParameters
        {
            IndexName = "instructors",
            FieldName = "FirstName",
            Value = "Ege Umut"
        });
        return Ok(result4);
    }


}