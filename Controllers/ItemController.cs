using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_CRUD.Data.Repositories;
using API_CRUD.Models;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(long id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            await _itemRepository.AddAsync(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id,Item item)
        {
            
            var existingItem = await _itemRepository.GetItemByIdAsync(id);
            if (existingItem is null)
                return NotFound();

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;


            await _itemRepository.UpdateAsync(existingItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {

            var existingItem = await _itemRepository.GetItemByIdAsync(id);
            if (existingItem is null)
                return NotFound();

            await _itemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
