using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Red Fox", ImageUrl="https://example.com/red-fox-image.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Blue Jay", ImageUrl="https://example.com/blue-jay-image.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Green Frog", ImageUrl="https://example.com/green-frog-image.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Yellow Finch", ImageUrl="https://example.com/yellow-finch-image.jpg"},
        });

        // Seed data with UserProfile
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@doe.com"
        });

        // Seed data with Reservation
        modelBuilder.Entity<Reservation>().HasData(new Reservation
        {
            Id = 1,
            CampsiteId = 1,    // Foreign key pointing to the Campsite
            UserProfileId = 1, // Foreign key pointing to the UserProfile
            CheckinDate = DateTime.Now,
            CheckoutDate = DateTime.Now.AddDays(3),
        });
    }
}