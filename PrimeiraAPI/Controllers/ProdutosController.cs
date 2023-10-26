using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Models;
using Microsoft.AspNetCore.Http;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class ProdutosController : ControllerBase
    {
        private List<Produto> _produtos = new List<Produto> {
            new Produto
            {
                Id = 1,
                Nome = "Carne bovina kg"
            },
            new Produto
            {
                Id = 2,
                Nome = "Sabão em pó"
            }
        };

        [HttpGet]
        [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            return Ok(_produtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(int id)
        {
            return Ok(_produtos.Find(p => p.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Produto produto)
        {
            return CreatedAtAction("Get", new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            return NoContent();
        }
    }
}
