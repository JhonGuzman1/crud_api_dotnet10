using System;
using API_CRUD.Models;

namespace API_CRUD.Data.Repositories;

public interface IItemRepository
{   
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item?> GetItemByIdAsync(long id);
    Task AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(long id);

}
