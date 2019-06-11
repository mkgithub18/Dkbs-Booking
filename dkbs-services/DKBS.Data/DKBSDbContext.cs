using DKBS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DKBS.Data
{
   public class DKBSDbContext :DbContext
    {
        public DKBSDbContext(DbContextOptions<DKBSDbContext> options) : base(options)
        {
        }
        public DbSet<Region> Region { get; set; }

        public DbSet<TableSet> TableSet { get; set; }

        public DbSet<Purpose> Purpose { get; set; }

        public DbSet<TableType> TableType { get; set; }

        public DbSet<PartnerType> PartnerType { get; set; }

        public DbSet<MailLanguage> MailLanguage { get; set; }

        public DbSet<LeadOfOrigin> LeadOfOrigin { get; set; }

        public DbSet<Land> Land { get; set; }

        public DbSet<ITProcedureStatus> ITProcedureStatus { get; set; }

        public DbSet<IndustryCode> IndustryCode { get; set; }

        public DbSet<Flow> Flow { get; set; }

        public DbSet<CrmStatus> CrmStatus { get; set; }

        public DbSet<CoursePackageType> CoursePackageType { get; set; }

        public DbSet<ContactPerson> ContactPerson { get; set; }

        public DbSet<Campaign> Campaign { get; set; }

        public DbSet<CenterType> CenterType { get; set; }

        public DbSet<CenterMatching> CenterMatching { get; set; }

        public DbSet<CauseOfRemoval> CauseOfRemoval { get; set; }

        public DbSet<CancellationReason> CancellationReason { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Partner> Partner { get; set; }

        public DbSet<PartnerCenterDescription> PartnerCenterDescription { get; set; }

        public DbSet<CRMPartner> CRMPartner { get; set; }

        public DbSet<PartnerEmployee> PartnerEmployee { get; set; }

        public DbSet<TownZipCode> TownZipCode { get; set; }

        public DbSet<BookingRoom> BookingRoom { get; set; }

        public DbSet<Provision> Provision { get; set; }

        public DbSet<ProcedureReviewType> ProcedureReviewType { get; set; }

        public DbSet<Procedure> Procedure { get; set; }

        public DbSet<ParticipantType> ParticipantType { get; set; }

        public DbSet<MailGroup> MailGroup { get; set; }

        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<BookingRegion> BookingRegion { get; set; }

        public DbSet<BookingReference> BookingReference { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<BookingArrangementType> BookingArrangementType { get; set; }

        public DbSet<BookingAlternativeService> BookingAlternativeService { get; set; }

        public DbSet<ProcedureInfo> ProcedureInfo { get; set; }

        public DbSet<BookingAndStatus> BookingAndStatus { get; set; }

        public DbSet<ServiceCatalogue> ServiceCatalogue { get; set; }
        public DbSet<ServiceRequestCommunication> ServiceRequestCommunication { get; set; }
        public DbSet<ServiceRequestNote> ServiceRequestNote { get; set; }
        public DbSet<SRConversationItem> SRConversationItem { get; set; }
        public DbSet<Refreshment> Refreshment { get; set; }
        public DbSet<CoursePackageMenue> CoursePackageMenue { get; set; }
        public DbSet<PartnerCenterInfo> PartnerCenterInfo { get; set; }
        public DbSet<PartnerCenterRoomInfo> PartnerCenterRoomInfo { get; set; }
        public DbSet<PartnerInspirationCategoriesUK> PartnerInspirationCategoriesUK { get; set; }
        public DbSet<PartnerInspirationCategoriesDK> PartnerInspirationCategoriesDK { get; set; }
        public DbSet<Provision> provision { get; set; }
        public DbSet<PartnerCoursePackages> PartnerCoursePackages { get; set; }
        public DbSet<PartnerCoursePackageMenue> PartnerCoursePackageMenue { get; set; }
        public DbSet<PartnerCoursePackageFreeServices> PartnerCoursePackageFreeServices { get; set; }
        public DbSet<PartnerCoursePackagePremiumServices> PartnerCoursePackagePremiumServices { get; set; }
        public DbSet<PartnerCoursePackageYearPrice> PartnerCoursePackageYearPrice { get; set; }
        public DbSet<SCPartnerCoursePackageMapping> SCPartnerCoursePackageMapping { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Customer>(cust =>
        //    {
        //        cust.Property(c => c.Name).HasMaxLength(200).HasColumnType("varchar"); // One example for how to define the type for db column
        //        cust.Property(c => c.Address1).HasMaxLength(500);
        //        cust.Property(c => c.Address2).HasMaxLength(500);
        //        cust.Property(c => c.ZipCode).HasMaxLength(50).IsRequired();
        //        cust.Property(c => c.Country).HasMaxLength(50);
        //        cust.Property(c => c.City).HasMaxLength(200);
        //        cust.Property(c => c.CreatedBy).HasMaxLength(100);
        //        cust.Property(c => c.ModifiedBy).HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<Booking>(booking =>
        //    {
        //        booking.Property(e => e.InternalHistory).HasMaxLength(200);
        //    });

        //    modelBuilder.Entity<Booking>().HasOne(b => b.Customer);

        //    modelBuilder.Entity<BookingRegions>(bookingRegion =>
        //    {
        //        bookingRegion.Property(br => br.BookingId).IsRequired();
        //        bookingRegion.Property(br => br.RegionId).IsRequired();
        //    });

        //    modelBuilder.Entity<BookingReference>(bookingReference =>
        //    {
        //        bookingReference.Property(br => br.BookingId).IsRequired();
        //        bookingReference.Property(br => br.CompignId).IsRequired();
        //        bookingReference.Property(br => br.LeadOrignId).IsRequired();
        //        bookingReference.Property(br => br.RefferId).IsRequired();
        //        bookingReference.Property(br => br.Other).HasMaxLength(500).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Campaign>(camp => {
        //        camp.Property(c => c.Name).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<LeadOfOrigin>(leadOrigin => {
        //        leadOrigin.Property(c => c.Name).HasMaxLength(2255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Region>(region => {
        //        region.Property(c => c.Name).HasMaxLength(2255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Room>(room => {
        //        room.Property(r => r.LocalAttraction).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<AlternativeService>(alternativeService => {
        //        alternativeService.Property(service => service.Description).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Flow>(flow => {
        //        flow.Property(f => f.FlowName).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<MailLanguage>(mailLanguage => {
        //        mailLanguage.Property(ml => ml.Language).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<CenterMatching>(centerMatching => {
        //        centerMatching.Property(cm => cm.MatchingCenter).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Purpose>(purpose => {
        //        purpose.Property(p => p.PurposeName).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<ParticipantType>(participantType => {
        //        participantType.Property(pt => pt.ParticipantTypeName).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<TableType>(tableType => {
        //        tableType.Property(t => t.TableTypeName).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Procedure>(procedure => {
        //        procedure.Property(p => p.ProcedureName).HasMaxLength(255).HasColumnType("varchar");
        //        procedure.Property(p => p.LastModifiedBy).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Customer);
        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Booking);
        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Partner);

        //    modelBuilder.Entity<Partner>(partner => {
        //        partner.Property(p => p.PartnerName).HasMaxLength(255);
        //        partner.Property(p => p.EmailId).HasMaxLength(255);
        //        partner.Property(p => p.PhoneNumber).HasMaxLength(255);
        //        partner.Property(p => p.LastModifiedBy).HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Partner>().HasOne(p => p.CenterTypeId);
        //    modelBuilder.Entity<Partner>().HasOne(p => p.PartnerType);




        //}
    }
    
}
