using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Services;
using Microsoft.AspNetCore.Identity;
using Spire.Xls;
using System.Data;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly UserManager<UserApp> _userManager;
        public Worker(ILogger<Worker> logger, UserManager<UserApp> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        Random rnd = new Random();
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                DataTable dt = new DataTable();
                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets[0];

                //List<UserApp> users = _userManager.Users.ToList();

                //dt.Columns.Add("UserName");
                //dt.Columns.Add("Email");
                //dt.Columns.Add("PhoneNumber");
                //foreach (UserApp ua in users)
                //{
                //    dt.Rows.Add(ua.UserName, ua.Email, ua.PhoneNumber);

                //}

                sheet.InsertDataTable(dt, true, 1, 1);







                book.SaveToFile("test.xls");
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}