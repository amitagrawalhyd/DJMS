using DJMS.Common;
using DJMS.Models;
using DJMS.Repository.Bill;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DJMS.DAL.Bills
{
    public class BillService : Repositories.Repository, IBillService
    {
        public IEnumerable<AddressMaster> GetAddresses(string addressKey)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>();

                if (!string.IsNullOrEmpty(addressKey))
                    param.Add(CreateParameter("@pAddress", addressKey));

                return DataContext.Execute<AddressMaster>("dbo.usp_GetAddressDetails", param);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("@pAddress: {0}", addressKey));
                base.LogError(ex, "usp_GetAddressDetails", builder.ToString());
                return null;
            }
        }

        public IEnumerable<BillMaster> GetBills(string customerName, string address, string itemName)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>();

                if (!string.IsNullOrEmpty(address))
                    param.Add(CreateParameter("@pAddress", address));

                if (!string.IsNullOrEmpty(customerName))
                    param.Add(CreateParameter("@pCustomerName", customerName));

                if (!string.IsNullOrEmpty(itemName))
                    param.Add(CreateParameter("@pItemName", itemName));

                return DataContext.Execute<BillMaster>("dbo.usp_GetBillMasterDetails", param);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("customerName: {0}", customerName));
                builder.AppendLine(string.Format("address: {0}", address));
                builder.AppendLine(string.Format("itemName: {0}", itemName));
                base.LogError(ex, "usp_GetBillMasterDetails", builder.ToString());
                return null;
            }
        }

        public IEnumerable<CustomerMaster> GetCustomers(string customerKey)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>();

                if (!string.IsNullOrEmpty(customerKey))
                    param.Add(CreateParameter("@pCustomerName", customerKey));

                return DataContext.Execute<CustomerMaster>("dbo.usp_GetCustomerDetails", param);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("@pCustomerName: {0}", customerKey));
                base.LogError(ex, "usp_GetCustomerDetails", builder.ToString());
                return null;
            }
        }

        public DatabaseOperationResult SaveBill(BillMaster bill)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>()
                {
                    CreateParameter("@pCustomerName", bill.CustomerName),
                    CreateParameter("@pAddress", bill.Address),
                    CreateParameter("@pItems", bill.ItemName),
                    CreateParameter("@pBillId", bill.BillId),
                    CreateParameter("@pWeight", bill.Weight),
                    CreateParameter("@pBillDate", bill.BillDate),
                    CreateParameter("@pIsActive", bill.IsActive)
                };

                if (bill.ID != 0)
                    param.Add(CreateParameter("@pId", bill.ID));

                if (bill.CustomerId != 0)
                    param.Add(CreateParameter("@pCustomerId", bill.CustomerId));


                int? result = 0;
                DataContext.ExecuteNonQuery("dbo.usp_InsertUpdateBill", ref result, param);

                if (result == 1)
                    return GetOperationResult();
                else
                    return GetOperationResult(0, string.Empty);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("pCustomerName: {0}", bill.CustomerName));
                builder.AppendLine(string.Format("pAddress: {0}", bill.Address));
                builder.AppendLine(string.Format("pItems: {0}", bill.ItemName));
                builder.AppendLine(string.Format("pBillId: {0}", bill.BillId));
                builder.AppendLine(string.Format("pWeight: {0}", bill.Weight));
                builder.AppendLine(string.Format("pBillDate: {0}", bill.BillDate));
                builder.AppendLine(string.Format("pIsActive: {0}", bill.IsActive));
                base.LogError(ex, "usp_InsertUpdateBill", builder.ToString());
                return null;
            }
        }
    }
}
