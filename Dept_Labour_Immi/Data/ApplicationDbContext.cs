using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agency> agencies { get; set; }
        public DbSet<Blacklist> blacklists { get; set; }
        public DbSet<BOD> bODs { get; set; }
        public DbSet<ThaiCompany> thaiCompanies { get; set; }
        public DbSet<DOE> DOEs { get; set; }
        public DbSet<Operation_1> operation_1s { get; set; }
        public DbSet<Operation_2> operation_2s { get; set; }
        public DbSet<Penalty> penalties { get; set; }
        public DbSet<ServiceforThaiWorker> serviceforThaiWorkers { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<ThaiSending> thaiSendings { get; set; }
        public DbSet<InternationalSending> internationalSendings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}