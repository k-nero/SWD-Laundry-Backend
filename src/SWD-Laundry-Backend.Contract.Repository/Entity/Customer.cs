using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;

#nullable disable

public class Customer : BaseEntity
{
    //public string Name { get; set; }
    //public string Address { get; set; }

    #region Relationship

    [ForeignKey("Building")]
    public string BuildingID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public Building Building { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public virtual List<Order> Order { get; set; }

    #endregion Relationship

    #region Special Attribute

    //private string _email;

    //private string _phone;

    //public string Email
    //{
    //    get { return _email; }
    //    set
    //    {
    //        _email = new Validate().IsValidEmail(value)
    //            ? value
    //            : throw new ArgumentException("Invalid email.");
    //    }
    //}

    //public string Phone
    //{
    //    get { return _phone; }
    //    set
    //    {
    //        _phone = new Validate().IsValidPhone(value)
    //            ? value
    //            : throw new ArgumentException("Invalid phone (must be 9-10 numbers and start with 09 or 01).");
    //    }
    //}

    #endregion Special Attribute
}