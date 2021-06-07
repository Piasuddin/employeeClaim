using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class EmployeeClaim
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public string SubscriptionId { get; set; }
        public string Comment { get; set; }
        public byte Status { get; set; }
        public string File { get; set; }
        public Employee Employee { get; set; }
    }
}
