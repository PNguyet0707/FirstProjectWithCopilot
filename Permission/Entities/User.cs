using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeWorld.Entities
{
    [Table("EnterpriceUser")]
    public class User
    {
        public Guid UserId { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
