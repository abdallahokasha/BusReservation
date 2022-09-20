using BusReservation.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservation.Data;

public class BusReservationDbContext : DbContext {
    
    public BusReservationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<Ticket> Tickets { get; set; }
    
    public DbSet<Bus> Buses { get; set; }
    
    public DbSet<Seat> Seats { get; set; }
}