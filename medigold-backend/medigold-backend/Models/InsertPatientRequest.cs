using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Models
{
    public class InsertPatientRequest
    {
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public DateTime InfectionDate { get; set; }

        public InsertPatientRequest() { }

        public InsertPatientRequest(string Name, DateTime DoB, DateTime InfectionDate)
        {
            this.Name = Name;
            this.DoB= DoB;
            this.InfectionDate= InfectionDate;
        }
    }
}
