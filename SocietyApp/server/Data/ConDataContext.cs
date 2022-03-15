using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using SocietyApp.Models.ConData;

namespace SocietyApp.Data
{
    public partial class ConDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public ConDataContext(IHttpContextAccessor httpAccessor, DbContextOptions<ConDataContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public ConDataContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .HasOne(i => i.Gender)
                  .WithMany(i => i.Members)
                  .HasForeignKey(i => i.GenderID)
                  .HasPrincipalKey(i => i.GenderID);
            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .HasOne(i => i.MemberPosition)
                  .WithMany(i => i.Members)
                  .HasForeignKey(i => i.CurrentPositionID)
                  .HasPrincipalKey(i => i.PositionID);
            builder.Entity<SocietyApp.Models.ConData.MemberContribution>()
                  .HasOne(i => i.Member)
                  .WithMany(i => i.MemberContributions)
                  .HasForeignKey(i => i.MemberID)
                  .HasPrincipalKey(i => i.MemberID);


            builder.Entity<SocietyApp.Models.ConData.ContributionsView>()
                  .Property(p => p.ContributionDate)
                  .HasColumnType("datetime");

            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .Property(p => p.DateOfBirth)
                  .HasColumnType("datetime");

            builder.Entity<SocietyApp.Models.ConData.MemberContribution>()
                  .Property(p => p.ContributionDate)
                  .HasColumnType("datetime");

            builder.Entity<SocietyApp.Models.ConData.ContributionsView>()
                  .Property(p => p.ContributionID)
                  .HasPrecision(19, 0);

            builder.Entity<SocietyApp.Models.ConData.ContributionsView>()
                  .Property(p => p.AmountContributed)
                  .HasPrecision(18, 2);

            builder.Entity<SocietyApp.Models.ConData.Gender>()
                  .Property(p => p.GenderID)
                  .HasPrecision(10, 0);

            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .Property(p => p.MemberID)
                  .HasPrecision(19, 0);

            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .Property(p => p.GenderID)
                  .HasPrecision(10, 0);

            builder.Entity<SocietyApp.Models.ConData.Member>()
                  .Property(p => p.CurrentPositionID)
                  .HasPrecision(10, 0);

            builder.Entity<SocietyApp.Models.ConData.MemberContribution>()
                  .Property(p => p.ContributionID)
                  .HasPrecision(19, 0);

            builder.Entity<SocietyApp.Models.ConData.MemberContribution>()
                  .Property(p => p.MemberID)
                  .HasPrecision(19, 0);

            builder.Entity<SocietyApp.Models.ConData.MemberContribution>()
                  .Property(p => p.AmountContributed)
                  .HasPrecision(18, 2);

            builder.Entity<SocietyApp.Models.ConData.MemberListProc>()
                  .Property(p => p.MemberID)
                  .HasPrecision(19, 0);

            builder.Entity<SocietyApp.Models.ConData.MemberPosition>()
                  .Property(p => p.PositionID)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<SocietyApp.Models.ConData.ContributionsView> ContributionsViews
        {
          get;
          set;
        }

        public DbSet<SocietyApp.Models.ConData.Gender> Genders
        {
          get;
          set;
        }

        public DbSet<SocietyApp.Models.ConData.Member> Members
        {
          get;
          set;
        }

        public DbSet<SocietyApp.Models.ConData.MemberContribution> MemberContributions
        {
          get;
          set;
        }

        public DbSet<SocietyApp.Models.ConData.MemberListProc> MemberListProcs
        {
          get;
          set;
        }

        public DbSet<SocietyApp.Models.ConData.MemberPosition> MemberPositions
        {
          get;
          set;
        }
    }
}
