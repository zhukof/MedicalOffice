namespace MedicalOffice.DAL.Models
{
    public class Doctor : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        
        public int CabinetId { get; set; }
        public Cabinet Cabinet { get; set; }
        
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        
        public int? RegionId { get; set; }
        public Region Region { get; set; }
    }
}