using App.Model.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProductService _produtoService;

        public ProdutosController(IProductService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{code}")]
        public Product Get(string code)
        {
            return _produtoService.GetProduct(code);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _produtoService.AddProduct(value);
        }

        [HttpDelete("{code}")]
        public void Delete(string code)
        {
            _produtoService.DeleteProduct(code);
        }
    }
}