using LoanManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Domain
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }

        public DbSet<Member> Member { get; set; }
        public DbSet<MemberLoanDetail> MemberLoanDetail { get; set; }
        public DbSet<MemberLoanInstallment> MemberLoanInstallment { get; set; }
        public DbSet<Districts> District { get; set; }
        public DbSet<Provinces> Province { get; set; }
        public DbSet<Municipalities> Municipality { get; set; }
        public DbSet<LoanDisbrusement> LoanDisbrusement { get; set; }
        public DbSet<LoanDisbrusementDetail> LoanDisbrusementDetail { get; set; }
        public DbSet<LoanCollection> LoanCollection  { get; set; }
        public DbSet<LoanCollectionDetail> LoanCollectionDetail { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionDetail> TransactionDetail { get; set; }

        private void SeedAddress(ModelBuilder builder)
        {
            builder.Entity<Provinces>().HasData(
                new Provinces { Id = 1, Name = "Province No. 1" },
                new Provinces { Id = 2, Name = "Province No. 2" },
                new Provinces { Id = 3, Name = "Bagmati" },
                new Provinces { Id = 4, Name = "Gandaki" },
                new Provinces { Id = 5, Name = "Lumbini" },
                new Provinces { Id = 6, Name = "Karnali" },
                new Provinces { Id = 7, Name = "Sudur-Paschim Province" }
                );
            builder.Entity<Districts>().HasData(
                new Districts { Id = 1, Name = "Bhojpur", ProvinceId = 1 },
                new Districts { Id = 2, Name = "Dhankuta", ProvinceId = 1 },
                new Districts { Id = 3, Name = "Ilam", ProvinceId = 1 },
                new Districts { Id = 4, Name = "Jhapa", ProvinceId = 1 },
                new Districts { Id = 5, Name = "Khotang", ProvinceId = 1 },
                new Districts { Id = 6, Name = "Morang", ProvinceId = 1 },
                new Districts { Id = 7, Name = "Okhaldhunga", ProvinceId = 1 },
                new Districts { Id = 8, Name = "Panchthar", ProvinceId = 1 },
                new Districts { Id = 9, Name = "Sankhuwasabha", ProvinceId = 1 },
                new Districts { Id = 10, Name = "Solukhumbu", ProvinceId = 1 },
                new Districts { Id = 11, Name = "Sunsari", ProvinceId = 1 },
                new Districts { Id = 12, Name = "Taplejung", ProvinceId = 1 },
                new Districts { Id = 13, Name = "Terhathum", ProvinceId = 1 },
                new Districts { Id = 14, Name = "Udayapur", ProvinceId = 1 },

                new Districts { Id = 15, Name = "Bara", ProvinceId = 2 },
                new Districts { Id = 16, Name = "Dhanusa", ProvinceId = 2 },
                new Districts { Id = 17, Name = "Mahottari", ProvinceId = 2 },
                new Districts { Id = 18, Name = "Parsa", ProvinceId = 2 },
                new Districts { Id = 19, Name = "Rautahat", ProvinceId = 2 },
                new Districts { Id = 20, Name = "Saptari", ProvinceId = 2 },
                new Districts { Id = 21, Name = "Sarlahi", ProvinceId = 2 },
                new Districts { Id = 22, Name = "Siraha", ProvinceId = 2 },

                new Districts { Id = 23, Name = "Bhaktapur", ProvinceId = 3 },
                new Districts { Id = 24, Name = "Chitwan", ProvinceId = 3 },
                new Districts { Id = 25, Name = "Dhading", ProvinceId = 3 },
                new Districts { Id = 26, Name = "Dolakha", ProvinceId = 3 },
                new Districts { Id = 27, Name = "Kathmandu", ProvinceId = 3 },
                new Districts { Id = 28, Name = "Kavrepalanchok", ProvinceId = 3 },
                new Districts { Id = 29, Name = "Lalitpur", ProvinceId = 3 },
                new Districts { Id = 30, Name = "Makawanpur", ProvinceId = 3 },
                new Districts { Id = 31, Name = "Nuwakot", ProvinceId = 3 },
                new Districts { Id = 32, Name = "Ramechhap", ProvinceId = 3 },
                new Districts { Id = 33, Name = "Rasuwa", ProvinceId = 3 },
                new Districts { Id = 34, Name = "Sindhuli", ProvinceId = 3 },
                new Districts { Id = 35, Name = "Sindhupalchok", ProvinceId = 3 },

                new Districts { Id = 36, Name = "Baglung", ProvinceId = 4 },
                new Districts { Id = 37, Name = "Gorkha", ProvinceId = 4 },
                new Districts { Id = 38, Name = "Kaski", ProvinceId = 4 },
                new Districts { Id = 39, Name = "Lamjung", ProvinceId = 4 },
                new Districts { Id = 40, Name = "Manang", ProvinceId = 4 },
                new Districts { Id = 41, Name = "Mustang", ProvinceId = 4 },
                new Districts { Id = 42, Name = "Myagdi", ProvinceId = 4 },
                new Districts { Id = 43, Name = "Nawalparasi (Bardaghat Susta Purva)", ProvinceId = 4 },
                new Districts { Id = 44, Name = "Parbat", ProvinceId = 4 },
                new Districts { Id = 45, Name = "Syangja", ProvinceId = 4 },
                new Districts { Id = 46, Name = "Tanahu", ProvinceId = 4 },

                new Districts { Id = 47, Name = "Arghakhanchi", ProvinceId = 5 },
                new Districts { Id = 48, Name = "Banke", ProvinceId = 5 },
                new Districts { Id = 49, Name = "Bardiya", ProvinceId = 5 },
                new Districts { Id = 50, Name = "Dang", ProvinceId = 5 },
                new Districts { Id = 51, Name = "Gulmi", ProvinceId = 5 },
                new Districts { Id = 52, Name = "Kapilvastu", ProvinceId = 5 },
                new Districts { Id = 53, Name = "Nawalparasi (Bardaghat Susta Paschim)", ProvinceId = 5 },
                new Districts { Id = 54, Name = "Palpa", ProvinceId = 5 },
                new Districts { Id = 55, Name = "Pyuthan", ProvinceId = 5 },
                new Districts { Id = 56, Name = "Rolpa", ProvinceId = 5 },
                new Districts { Id = 57, Name = "Purbi Rukum", ProvinceId = 5 },
                new Districts { Id = 58, Name = "Rupandehi", ProvinceId = 5 },

                new Districts { Id = 59, Name = "Dailekh", ProvinceId = 6 },
                new Districts { Id = 60, Name = "Dolpa", ProvinceId = 6 },
                new Districts { Id = 61, Name = "Humla", ProvinceId = 6 },
                new Districts { Id = 62, Name = "Jajarkot", ProvinceId = 6 },
                new Districts { Id = 63, Name = "Jumla", ProvinceId = 6 },
                new Districts { Id = 64, Name = "Kalikot", ProvinceId = 6 },
                new Districts { Id = 65, Name = "Mugu", ProvinceId = 6 },
                new Districts { Id = 66, Name = "Rukum Paschim", ProvinceId = 6 },
                new Districts { Id = 67, Name = "Salyan", ProvinceId = 6 },
                new Districts { Id = 68, Name = "Surkhet", ProvinceId = 6 },

                new Districts { Id = 69, Name = "Achham", ProvinceId = 7 },
                new Districts { Id = 70, Name = "Baitadi", ProvinceId = 7 },
                new Districts { Id = 71, Name = "Bajhang", ProvinceId = 7 },
                new Districts { Id = 72, Name = "Bajura", ProvinceId = 7 },
                new Districts { Id = 73, Name = "Dadeldhura", ProvinceId = 7 },
                new Districts { Id = 74, Name = "Darchula", ProvinceId = 7 },
                new Districts { Id = 75, Name = "Doti", ProvinceId = 7 },
                new Districts { Id = 76, Name = "Kailali", ProvinceId = 7 },
                new Districts { Id = 77, Name = "Kanchanpur", ProvinceId = 7 }
                );
            builder.Entity<Municipalities>().HasData(
                new Municipalities { Id = 1, Name = "BHAKTAPUR MUNICIPALITY", DistrinctId = 23 },
                new Municipalities { Id = 2, Name = "CHANGUNARAYAN MUNICIPALITY", DistrinctId = 23 },
                new Municipalities { Id = 3, Name = "MADHYAPUR THIMI MUNICIPALITY", DistrinctId = 23 },
                new Municipalities { Id = 4, Name = "SURYABINAYAK MUNICIPALITY", DistrinctId = 23 }
                );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        //    SeedAddress(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            //SeedModulesData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();
            //SeedAccountsData.Initialize(builder..ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();
        }
    }
}
