using DJMS.Models;
using System;
using System.Collections.Generic;

namespace DJMS.Repository.Report
{
    public interface IDJMSReport
    {
        IEnumerable<SalesReportByAddress> GetSalesReportByAddress(DateTime startDate, DateTime endDate);
        IEnumerable<SalesByCustomer> GetSalesByCustomer(DateTime startDate, DateTime endDate);
    }
}
