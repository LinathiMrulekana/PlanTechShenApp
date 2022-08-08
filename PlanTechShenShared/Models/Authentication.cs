using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace PlanTechShenApp.Models
{
    public class Authentication
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int AuthenticationId { get; set; }
        public  string? EmailAddress { get; set; }
        public string? Password { get; set; }

        public DateTime  LastLogin { get; set; }
        public bool Enabled { get; set; }

        public Task Authenticate(object value1, object value2)
        {
            throw new NotImplementedException();
        }
    }

}
