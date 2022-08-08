using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanTechShenWebApi.Models
{
    public class UserAccount
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int UserAccountId { get; set; }
        public string? Username { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Client")] 
        public int UserId { get; internal set; }
    }
}
