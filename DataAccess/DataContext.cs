using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Currency> Valutes  { get; init; } = null!;
    
}

