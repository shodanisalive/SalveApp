using System;

namespace SalveApp.Infrastructure.Entities
{
    public sealed class Patient : BaseEntity<int>
    {
        public Patient()
        {

        }

        //Used when reading CSV
        public Patient(int clinicId, string firstName, string lastName, DateTime dateOfBirth) : base()
        {
            ClinicId = clinicId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int ClinicId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Clinic Clinic { get; }
    }
}
