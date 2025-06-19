using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetlistByDynamic;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ModelController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery
            {
                PageRequest = pageRequest
            };
            GetListResponse<GetListModelListItemDto>? response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }
        [HttpPost("Getlist/ByDynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
        {
            GetlistByDynamicModelQuery getListModelQuery = new GetlistByDynamicModelQuery
            {
                PageRequest = pageRequest,
                DynamicQuery = dynamicQuery,
            };
            GetListResponse<GetListByDynamicModelListItemDto>? response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }
    }
}
