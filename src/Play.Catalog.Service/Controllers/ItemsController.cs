using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Play.Catalog.Service.Dtos;
using System.Threading.Tasks;
using System;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        //list of items
        // private static readonly List<ItemDto> items = new()
        // {
        //     new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
        //     new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
        //     new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        // };

        private readonly ItemsRepository itemsRepository = new();

        //getall items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(item => item.AsDto());
            return items;
        }
        
        //getbyid item
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            //Erreur 404, if id doesn't exist
            if(item == null)
            {
                return NotFound();
            }
            
            return item.AsDto();
        }

        //create a item
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
          
            await itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new {id = item.Id}, item);
        }

        //Update a item
        [HttpPut("{id}")]
        public  async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await itemsRepository.GetAsync(id);

            if(existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();

        }

        //Delete a item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if(item == null)
            {
                return NotFound();
            }
            
            await itemsRepository.RemoveAsync(item.Id);

            return NoContent();
        }
    }
}