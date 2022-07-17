using ClosedXML.Excel;
using FinalAssessment.Core.DTOs;
using FinalAssessment.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessment.WorkerService
{
    public class WeeklyReport : BackgroundService
    {
        private readonly AppDbContext _context;
        public WeeklyReport(AppDbContext context)
        {
            _context = context;
        }

        //taking customers who have top 5 transactions for weekly report
        public List<WeeklyReportDto> GetTopTransactionListWithSP()
        {
            return  _context.Sp_Weekly.FromSqlRaw("exec sp_transctions_weekly").ToList();
        }

        
        //getting admins email list with stored prosedure
        public Task<List<string>> GetAdminsEmail()
        {
            return _context.Sp_Emails.FromSqlRaw("exec sp_admin_emails").ToListAsync();
        }


        //creating the report file as excel document
        public string CreateExcelWeekly()
        {
            string savePath = @"/ExcelReports/WeeklyReport" + DateTime.Now.ToShortDateString() + ".xls";

            List<WeeklyReportDto> WeeklyReportData = GetTopTransactionListWithSP();

            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("Sayfa 1");

                worksheet.Cell("A1").Value = "İSİM";
                worksheet.Cell("B1").Value = "SOYADI";
                worksheet.Cell("C1").Value = "TELEFON NO";
                worksheet.Cell("D1").Value = "TOPLAM İŞLEM";
                worksheet.Cell("E1").Value = "TOPLAM TUTAR";

                int row = 2;
                foreach (WeeklyReportDto wrd in WeeklyReportData)
                {
                    worksheet.Cell(row, 1).SetValue(wrd.Name);
                    worksheet.Cell(row, 2).SetValue(wrd.Surname);
                    worksheet.Cell(row, 3).SetValue(wrd.CallNumber);
                    worksheet.Cell(row, 4).SetValue(wrd.TotalTransaction);
                    worksheet.Cell(row, 5).SetValue(wrd.TotalPrice);
                    worksheet.Cell(row, 1).DataType = XLDataType.Text;
                    worksheet.Cell(row, 2).DataType = XLDataType.Text;
                    worksheet.Cell(row, 3).DataType = XLDataType.Text;
                    worksheet.Cell(row, 4).DataType = XLDataType.Number;
                    worksheet.Cell(row, 5).DataType = XLDataType.Number;
                    row++;

                }


                workbook.SaveAs(savePath);

            }

            return savePath;

        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }



    }
}
