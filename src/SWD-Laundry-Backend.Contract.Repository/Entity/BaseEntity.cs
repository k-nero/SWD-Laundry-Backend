using System.ComponentModel.DataAnnotations;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Contract.Repository.Entity
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedTime = LastUpdatedTime = CoreHelper.SystemTimeNow;
        }

        [Key]
        public string Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        //public string? DeletedBy { get; set; }

        public DateTimeOffset? CreatedTime { get; set; }

        public DateTimeOffset? LastUpdatedTime { get; set; }

        //public DateTimeOffset? DeletedTime { get; set; }
    }
}
