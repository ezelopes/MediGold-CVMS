using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Models
{
    public class UpdatePatientRequest
    {
        public int Id;
        public string Name { get; set; }
        public DateTime? OutcomeDate { get; set; }
        public string Status { get; set; }

        public UpdatePatientRequest() { }

        public UpdatePatientRequest(int Id, string Name, DateTime OutcomeDate, string Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.OutcomeDate = OutcomeDate;
            this.Status = Status;
        }
    }
}
