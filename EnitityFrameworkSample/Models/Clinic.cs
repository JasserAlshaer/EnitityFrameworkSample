namespace EnitityFrameworkSample.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public virtual List<PatientClinic> PatientClinics { get; set; }
    }
}
