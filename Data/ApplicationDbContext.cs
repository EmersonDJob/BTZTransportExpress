using BTZTransportExpress.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTZTransportExpress.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Abastecimento> Abastecimentos { get; set; }

    }
}
