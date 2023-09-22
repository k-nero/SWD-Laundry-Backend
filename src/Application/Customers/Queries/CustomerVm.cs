using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Application.Customers.Queries;
public class CustomerVm : IMapFrom<Customer>
{
    public int BuildingID { get; set; }

    public string ApplicationUserID { get; set; }

    public Building Building { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public virtual List<Order> Order { get; set; }

}
