using System;
using MedicalOffice.DAL.Models.Enums;

namespace MedicalOffice.DAL.Models
{
    public class Patient : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}