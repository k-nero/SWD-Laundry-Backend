using System.ComponentModel.DataAnnotations;

namespace SWD_Laundry_Backend.Contract.Repository.Entity
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedTime = DateTimeOffset.UtcNow;
        }

        [Key]
        public string Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        //public string? DeletedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset? LastUpdatedTime { get; set; }

        //public DateTimeOffset? DeletedTime { get; set; }
    }
}
