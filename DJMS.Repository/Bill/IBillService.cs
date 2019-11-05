using DJMS.Common;
using DJMS.Models;
using System.Collections.Generic;

namespace DJMS.Repository.Bill
{
    public interface IBillService
    {
        IEnumerable<AddressMaster> GetAddresses(string addressKey);
        IEnumerable<CustomerMaster> GetCustomers(string customerKey);
        IEnumerable<BillMaster> GetBills(string customerName, string address, string itemName);
        DatabaseOperationResult SaveBill(BillMaster bill);
    }
}
