using System;
using Microsoft.EntityFrameworkCore;
using API_CRUD.Models;

namespace API_CRUD.Data.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item?> GetItemByIdAsync(long id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task AddAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var item = await _context.Items.FindAsync(id);
        if(item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
