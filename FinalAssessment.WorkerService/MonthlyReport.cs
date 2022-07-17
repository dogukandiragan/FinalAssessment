using ClosedXML.Excel;
using FinalAssessment.Core.DTOs;
using FinalAssessment.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessment.WorkerService
{

    public class MonthlyReport : BackgroundService
    {
        private readonly AppDbContext _context;
        
        public MonthlyReport(AppDbContext context)
        {
            _context = context;
        }


        //taking customers count by city for monthly report
        public List<MonthlyReportDto> GetCityListWithSP()
        {
            return  _context.Sp_Monthly.FromSqlRaw("exec sp_city_monthly").ToList();
        }

        //getting admins and editors emails
        public  List<string> GetModEmails()
        {
            return  _context.Users.Select(x => x.Email).ToList();
        }


        //creating the report file as excel document
        public string CreateExcelMonthly()
        {

            string savePath = @"/ExcelReports/MonthlyReport" + DateTime.Now.ToShortDateString() + ".xls";

            List<MonthlyReportDto> MonthlyReportData = GetCityListWithSP();
             

            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("Sayfa 1");

                worksheet.Cell("A1").Value = "ŞEHİR";
                worksheet.Cell("B1").Value = "MÜŞTERİ SAYISI";

                int row = 2;
                foreach (MonthlyReportDto mrd in MonthlyReportData)
                {
                    worksheet.Cell(row, 1).SetValue(mrd.City);
                    worksheet.Cell(row, 2).SetValue(mrd.Count);
                    worksheet.Cell(row, 1).DataType = XLDataType.Text;
                    worksheet.Cell(row, 2).DataType = XLDataType.Number;
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
