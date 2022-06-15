using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveApp.Infrastructure.Entities
{
    public sealed class Clinic : BaseEntity<int>
    {
        public Clinic()
        {
            Patients = new HashSet<Patient>();
        }

        //Used when reading CSV
        public Clinic(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<Patient> Patients { get; }
    }
}
