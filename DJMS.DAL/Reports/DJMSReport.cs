using DJMS.Models;
using DJMS.Repository.Report;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DJMS.DAL.Reports
{
    public class DJMSReport : Repositories.Repository, IDJMSReport
    {
        public IEnumerable<SalesByCustomer> GetSalesByCustomer(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>()
                {
                    CreateParameter("@pStartDate", startDate),
                    CreateParameter("@pEndDate", endDate)
                };
                return DataContext.Execute<SalesByCustomer>("dbo.usp_Report_GetSalesReportByCustomer", param);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("@pStartdate: {0}", startDate));
                builder.AppendLine(string.Format("@pEndDate: {0}", endDate));
                base.LogError(ex, "usp_Report_GetSalesReportByCustomer", builder.ToString());
                return null;
            }
        }

        public IEnumerable<SalesReportByAddress> GetSalesReportByAddress(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>()
                {
                    CreateParameter("@pStartDate", startDate),
                    CreateParameter("@pEndDate", endDate)
                };
                return DataContext.Execute<SalesReportByAddress>("dbo.usp_Report_GetSalesReportByAddress", param);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("@pStartdate: {0}", startDate));
                builder.AppendLine(string.Format("@pEndDate: {0}", endDate));
                base.LogError(ex, "usp_Report_GetSalesReportByAddress", builder.ToString());
                return null;
            }
        }
    }
}
