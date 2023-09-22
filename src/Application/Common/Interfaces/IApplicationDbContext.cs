using SWD_Laundry_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Domain.Common;

namespace SWD_Laundry_Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    //DbSet<Customer> Customers { get; }
    //DbSet<Building> Buildings { get; }
    //DbSet<ApplicationUser> ApplicationUsers { get; }
    //DbSet<LaundryStore> LaundryStores { get; }
    //DbSet<Order> Orders { get; }
    //DbSet<OrderHistory> OrdersHistory { get; }
    //DbSet<PaymentMethod> PaymentMethods { get; }
    //DbSet<Staff_Trip> Staff_Trips { get; }
    //DbSet<Staff> Staffs { get; }
    //DbSet<Transaction> Transactions { get; }
    //DbSet<Wallet> Wallets { get; }


    DbSet<T> Get<T>() where T : BaseAuditableEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}