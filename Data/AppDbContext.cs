using System;
using Microsoft.EntityFrameworkCore;
using API_CRUD.Models;

namespace API_CRUD.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();
}
