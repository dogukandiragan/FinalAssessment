using ClosedXML.Excel;
using FinalAssessment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment.Shared
{
    public class ExcelCreator  
    {
 

        public string CreateExcelMonthly( List<MonthlyReportDto> MonthlyReportData)
        {
            
            string savePath = @"/ExcelReports/MonthlyReport" + DateTime.Now.ToShortDateString() + ".xls";


            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("Sayfa 1");

                worksheet.Cell("A1").Value = "ŞEHİR";
                worksheet.Cell("B1").Value = "MÜŞTERİ SAYISI";

                int row = 2;
                foreach(MonthlyReportDto mrd in MonthlyReportData)
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


        public string CreateExcelWeekly(List<WeeklyReportDto> WeeklyReportData)
        {
            string savePath = @"/ExcelReports/WeeklyReport" + DateTime.Now.ToShortDateString() + ".xls";

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

    }
}
