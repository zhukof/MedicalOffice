using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalOffice.DAL.Models.Enums;

namespace MedicalOffice.DAL.Models
{
    [Table(nameof(Patient))]
    public class Patient : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        
        public ICollection<PatientRegionMapping> Regions { get; set; } 
    }
}