using Fullstack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.Api.Data
{
    public class FullStackDbContext: DbContext
    {
        public FullStackDbContext(DbContextOptions options): base(options) { }

        public DbSet<Employee> Employees {  get; set; }
    }
}

