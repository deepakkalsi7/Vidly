using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {   [Key]
        [Column("CustomerID")]
        public int Id { get; set; }
        [Column("CustomerName")]
        [Required]

        public string Name { get; set; }
        [DisplayName("Date of Birth")]
        [AgeRule]

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}