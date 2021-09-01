using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Service> Services { get; set; }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(ConfigureServices);
            modelBuilder.Entity<Customer>(ConfigureCustomers);
            modelBuilder.Entity<Room>(ConfigureRooms);
            modelBuilder.Entity<RoomType>(ConfigureRoomTypes);
        }
        private void ConfigureServices(EntityTypeBuilder<Service> builder)
        {
            //Use Fluent API Rules
            builder.ToTable("Services");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.SDESC).HasMaxLength(50);
            builder.Property(s => s.AMOUNT).HasColumnType("money");
            builder.Property(s => s.ServiceDate).HasColumnType("datetime");
            builder.HasOne(s => s.Rooms).WithMany(s => s.Services).HasForeignKey(s => s.ROOMNO);
        }
        private void ConfigureCustomers(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CNAME).HasMaxLength(20);
            builder.Property(c => c.ADDRESS).HasMaxLength(100);
            builder.Property(c => c.PHONE).HasMaxLength(20);
            builder.Property(c => c.EMAIL).HasMaxLength(40);
            builder.Property(c => c.CHECKIN).HasColumnType("datetime");
            builder.Property(c => c.ADVANCE).HasColumnType("money");
            builder.HasOne(c => c.Rooms).WithMany().HasForeignKey(c => c.ROOMNO);   //Roomno is pk of room


        }
        private void ConfigureRooms(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.RoomTypes).WithMany().HasForeignKey(r => r.RTCODE);
        }
        private void ConfigureRoomTypes(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomTypes");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.RTDESC).HasMaxLength(20);
            builder.Property(rt => rt.Rent).HasColumnType("money");


        }
    }
}
