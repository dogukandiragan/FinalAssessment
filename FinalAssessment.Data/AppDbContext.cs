using FinalAssessment.Core.Configuration;
using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessment.Data
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TransactionApp> Transactions { get; set; }
        public DbSet<CustomerApp> Customers { get; set; }
        public DbSet<MonthlyReportDto> Sp_Monthly { get; set; }
        public DbSet<WeeklyReportDto> Sp_Weekly { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
 
         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            builder.Entity<MonthlyReportDto>().HasNoKey();
            builder.Entity<WeeklyReportDto>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}
