using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StringConverter.Models.Domain;
using StringConverter.Models.Dto;

namespace StringConverter.Data
{
    public class StringConverterDbContext: IdentityDbContext<IdentityUser>
    {
        public StringConverterDbContext(DbContextOptions options):base(options)
        {


        }

        public virtual DbSet<TblConvertString> TblConvertStrings { get;set; }  
        public virtual DbSet<TblConvertStringDto> TblConvertStringDtos { get;set; }  
        //public  virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>(entity => entity.HasKey(p=>p.usaId));
            modelBuilder.Entity<TblConvertString>(entity => entity.HasKey(e => e.UserIDpk));
            modelBuilder.Entity<TblConvertStringDto>().HasNoKey();
        }
       


    }
}
