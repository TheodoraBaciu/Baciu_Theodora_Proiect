using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Baciu_Theodora_Proiect.Models;

namespace Baciu_Theodora_Proiect.Data
{
    public class Baciu_Theodora_ProiectContext : DbContext
    {
        public Baciu_Theodora_ProiectContext (DbContextOptions<Baciu_Theodora_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Baciu_Theodora_Proiect.Models.FlowerBox> FlowerBox { get; set; }

        public DbSet<Baciu_Theodora_Proiect.Models.Store> Store { get; set; }

        public DbSet<Baciu_Theodora_Proiect.Models.Category> Category { get; set; }
    }
}
