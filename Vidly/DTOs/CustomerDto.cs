using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        
        //[AgeRule]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        public byte MembershipTypeId { get; set; }

    }
}