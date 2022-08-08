
using PlanTechShenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanTechShenWebApi.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Client")]
    public class Client
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int UserId { get; set; }
        public string? firstName { get; set; }
        public string? Surname { get; set; }
        public string? EmailAddress { get; set; }
        public string CellphoneNumber { get; set; }

        [ForeignKey("Authentication")]
        public int AuthenticationId { get; set; }

        public Authentication? Authentication { get; set; }

        public ICollection<UserAccount>? UserAccounts { get; set; }
        
    }
}
