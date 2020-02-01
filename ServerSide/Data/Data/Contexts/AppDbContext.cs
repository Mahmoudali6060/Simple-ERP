using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Data.Entities.Shared;
using Data.Entities.Debit;
using Data.Entities.Credit;

namespace Data.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Debit entities
        public DbSet<DebitBorrow> DebitBorrows { get; set; }
        public DbSet<DebitCurrent> DebitCurrents { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Safe> Safes { get; set; }
        public DbSet<Station> Stations { get; set; }

        //Credit entities
        public DbSet<CreditBorrow> CreditBorrows { get; set; }
        public DbSet<CreditCurrent> CreditCurrents { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Reaper> Reapers { get; set; }
        public DbSet<ReaperDetail> ReaperDetails { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Selector> Selectors { get; set; }

        //Shared entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

    }

}
