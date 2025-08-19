using App.Application.UseCases.Product.GetById;
using App.Application.UseCases.Product.Register;
using App.Application.UseCases.Product.Update;
using App.Communication.Requests;
using App.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ProductsBaseController
    {
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsById(
            [FromServices] IGetProductByIdUseCase useCase,
            [FromRoute] string code)
        {
            var result = await useCase.Execute(code);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status201Created )]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterProductUseCase usecase,
            [FromBody] RequestProductJson request)
        {
            var result = await usecase.Execute(request);
            return Created(string.Empty, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProduct(
            [FromServices] IUpdateProductUseCase useCase,
            [FromBody] RequestProductJson request)
        {
            await useCase.Execute(request);
            return NoContent();
        }

    }
}
