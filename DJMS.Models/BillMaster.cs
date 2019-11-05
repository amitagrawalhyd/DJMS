using System;

namespace DJMS.Models
{
    public class BillMaster
    {
        public Int64 ID { get; set; }
        public Int64 BillId { get; set; }
        public Int64 CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ItemName { get; set; }
        public decimal Weight { get; set; }
        public DateTime BillDate { get; set; }
        public bool IsActive { get; set; }
    }
}
