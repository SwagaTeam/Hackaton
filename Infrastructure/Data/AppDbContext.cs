using Microsoft.EntityFrameworkCore;

namespace HackUbrir.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
}