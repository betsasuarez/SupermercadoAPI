using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.Models;

namespace SupermercadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private static List<Item> _listaSupermercado = new List<Item>
    {
        new Item { Id = 1, Nombre = "Huevo" },
        new Item { Id = 2, Nombre = "Carne" },
        new Item { Id = 3, Nombre = "Pollo" },
        new Item { Id = 4, Nombre = "Arroz" }
    };

        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return _listaSupermercado;
        }

        // GET: api/items/1
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = _listaSupermercado.Find(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/items
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item newItem)
        {
            newItem.Id = _listaSupermercado.Count + 1;
            _listaSupermercado.Add(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        // PUT: api/items/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item updatedItem)
        {
            var existingItem = _listaSupermercado.Find(i => i.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Nombre = updatedItem.Nombre;

            return NoContent();
        }

        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToRemove = _listaSupermercado.Find(i => i.Id == id);

            if (itemToRemove == null)
            {
                return NotFound();
            }

            _listaSupermercado.Remove(itemToRemove);

            return NoContent();
        }
    }
}

