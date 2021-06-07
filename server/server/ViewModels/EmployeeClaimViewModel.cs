using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.ViewModels
{
    public class EmployeeClaimViewModel
    {
        public long? Id { get; set; }
        public int? EmployeeId { get; set; }
        public string SubscriptionId { get; set; }
        public string Comment { get; set; }
        public string File { get; set; }
        public string FileName { get; set; }
        public byte? Status { get; set; }
    }
}
