using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Models
{
    public class Patient
    {
        //[JsonPropertyAttribute]
        public int Id;
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public DateTime InfectionDate { get; set; }
        public DateTime? OutcomeDate { get; set; }
        public string Status { get; set; }

        public Patient() { }

        public Patient (int Id, string Name, DateTime DoB, DateTime InfectionDate, DateTime OutcomeDate, string Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.DoB = DoB;
            this.InfectionDate = InfectionDate;
            this.OutcomeDate = OutcomeDate;
            this.Status = Status;
        }

        //public int GetId()
        //{
        //    return this.Id;
        //}
    }
}
