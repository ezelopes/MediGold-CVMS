using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Models
{
    public class CovidTrend
    {
        public int Total;
        public DateTime Date { get; set; }

        public CovidTrend() { }

        public CovidTrend(int Total, DateTime InfectionDate)
        {
            this.Total = Total;
            this.Date = InfectionDate;
        }
    }
}
