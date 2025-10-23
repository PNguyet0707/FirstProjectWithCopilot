using Microsoft.EntityFrameworkCore;
using System.Data;
using MemeWorld.Entities;
namespace MemeWorld.Data
{
    public class PermissionContext : DbContext 
    {
        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options)
        {
            
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
