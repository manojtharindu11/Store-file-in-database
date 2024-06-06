using Microsoft.EntityFrameworkCore;
using UploadFile.Models;

namespace UploadFile.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserFile> userFiles { get; set; }

    }
}
