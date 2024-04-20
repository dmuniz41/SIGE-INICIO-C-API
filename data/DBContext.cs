using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.data
{
    public class DBContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=INICIODB;User Id=sa;Password=Dmt41971109;MultipleActiveResultSets=true;Encrypt=false");
        }
    }
}