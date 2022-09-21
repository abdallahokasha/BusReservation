using BusReservation.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BusReservation.Data;

public class BusReservationDbContext : DbContext {
    
    public BusReservationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<Ticket> Tickets { get; set; }
}