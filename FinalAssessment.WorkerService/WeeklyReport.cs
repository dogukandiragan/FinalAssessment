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
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(100, stoppingToken);
            }
        }



        public Task<List<WeeklyReportDto>> GetTopTransactionListWithSP()
        {
            return  _context.Sp_Weekly.FromSqlRaw("exec sp_transctions_weekly").ToListAsync();
        }



    }
}
