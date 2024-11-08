using BackendProject.Models.Form;
using BackendProject.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormField> FormFields { get; set; }

}