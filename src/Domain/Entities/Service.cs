using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Service : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    //public double Price { get; set; }

    #region Relationship

    public List<LaundryStore> LaundryStores{ get; set; }

    #endregion Relationship
}