using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MemberShipTypes MemberShipType { get; set; }
        
        [Display(Name="Membership Type")]
        public byte MemberShipTypesId { get; set; }
        
        [Display(Name = "Date of birth")]
        public DateTime? Birthdate { get; set; }
    }
}