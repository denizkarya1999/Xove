using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xove.Domain.Interfaces;
using Xove.Domain.Models;

namespace Xove.Domain
{
    public class AppDbContext : DbContext
    {
        private readonly IDateTime _dateTime;

        public AppDbContext()
            : base(CreateOptions(null))
        {
        }


        public AppDbContext(DbContextOptions options,
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Partner> Partners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

             modelBuilder.Entity<Partner>().HasData(SeedData.Deniz);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetAuditInfo();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetAuditInfo();

            return base.SaveChanges();
        }

        private void SetAuditInfo()
        {
            foreach (var entry in ChangeTracker.Entries<BaseAudit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.Now;
                        entry.Entity.ModifiedDate = entry.Entity.CreatedDate;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;
                }
            }
        }

        private static DbContextOptions<AppDbContext> CreateOptions(string connName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            if (connName == null)
            {
                optionsBuilder.UseSqlServer(@"Server=EPITEC-27\SQLEXPRESS04;Integrated Security=True;Database=PartnersDB");
            }
            else
            {
                optionsBuilder.UseSqlServer(@"Server=EPITEC-27\SQLEXPRESS04;Integrated Security=True;Database=" + connName);
            }
            return optionsBuilder.Options;
        }

    }
}
