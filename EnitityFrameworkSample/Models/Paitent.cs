﻿namespace EnitityFrameworkSample.Models
{
    public class Paitent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; } 
        public virtual Login Login { get; set; }
        public virtual List<PatientClinic> PatientClinics { get; set; } 
    }
}
