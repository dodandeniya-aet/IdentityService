using AuthService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<User>(options)
{
}