using GiftOfGivers1.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftOfGivers1.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options
    ) : DbContext(options) {  


    DbSet<DisasterCategory> DisasterCategories { get; set; }  

    DbSet<Disaster> Disasters { get; set; }  

    DbSet<UserProfile> UserProfiles { get; set; }  

    DbSet<Donation> Donations { get; set; } 

    DbSet<Volunteers> Volunteers { get; set; } 


}
