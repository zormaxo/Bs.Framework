using Bs.Data.Model;
using Bs.Data.Model.BaseModel;
using EntityFramework.DynamicFilters;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Bs.Data.Context
{
    /// <summary>
    /// Database yapısını temsil ediyor
    /// </summary>
    public class BsContext : DbContext
    {
        public BsContext()
            : base("name=EmployeeContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BsContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Department> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Bolge> Bolgeler { get; set; }
        public DbSet<Personel> Personeller { get; set; }

        public override int SaveChanges()
        {
            IEnumerable<DbEntityEntry<BaseEntityModel>> entries = ChangeTracker.Entries<BaseEntityModel>();

            foreach (DbEntityEntry<BaseEntityModel> entry in entries)
            {
                FillBaseProperties(entry);
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
            modelBuilder.Filter("IsDeleted", (BaseEntityModel d) => d.IsDeleted, 0);
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(50));
        }

        private void FillBaseProperties(DbEntityEntry<BaseEntityModel> entry)
        {
            //if (entry.State == EntityState.Added)
            //{
            //    entry.Entity.Guid = BsGuid.GetGuid();
            //}
            if (entry.State == EntityState.Modified)
            {
                long now = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                entry.Entity.LastUpdated = now;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = 1;
                long now = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                entry.Entity.LastUpdated = now;
            }
        }
    }
}