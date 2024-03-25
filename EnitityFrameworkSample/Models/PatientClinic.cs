namespace EnitityFrameworkSample.Models
{
    public class PatientClinic
    {
        public int Id { get; set; }
        public virtual Paitent Patient { get; set; }
        public virtual Clinic Clinic { get; set; }  
    }
}
