namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class Building : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }

    #region Relationship
    public List<Customer> Customers { get; set; }
    public List<Staff_Trip> Staff_Trips { get; set; }
    #endregion
}