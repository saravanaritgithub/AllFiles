using Entites.Enums;
using Entites.Models;
using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //foreign key
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public bool Istaxexempt { get; set; }
        public string NewsLetter { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public CustomerRolesEnum CustomerRolesEnum { get; set; }
        //foreign key
        public int VendorId { get; set; }
        public Vendors Vendors { get; set; }
        public bool Active { get; set; }
        public string AdminComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}