using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BrandsController : BaseController
    {


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse? response = await Mediator.Send(createBrandCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdatedBrandResponse? response = await Mediator.Send(updateBrandCommand);
            return Ok(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete([FromBody]Guid Id )
        {
            DeleteBrandCommand deleteBrandCommand = new()
            {
                Id = Id
            };
            DeletedBrandResponse? response = await Mediator.Send(deleteBrandCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new GetListBrandQuery
            {
                PageRequest = pageRequest
            };
            GetListResponse<GetListBrandListItemDto>? response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new()
            {
                Id = Id
            };
            GetByIdBrandResponse? response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);
        }
    }
}
