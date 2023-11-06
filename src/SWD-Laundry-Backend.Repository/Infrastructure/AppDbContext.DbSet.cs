using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Repository.Infrastructure;
public sealed partial class AppDbContext
{
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<StaffTrip> Staff_Trips { get; set; }
    public DbSet<TimeSchedule> TimeSchedules { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LaundryStore> LaundryStores { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderHistory> OrderHistories { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
}
