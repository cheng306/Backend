using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> dco) : base(dco) {}

        public DbSet<Transfer>TransfersList { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
