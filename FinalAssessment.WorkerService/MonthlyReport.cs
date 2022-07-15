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

        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(100, stoppingToken);
            }
        }


        public async Task<List<MonthlyReportDto>> GetCityListWithSP()
        {
            return await _context.Sp_Monthly.FromSqlRaw("exec sp_city_monthly").ToListAsync();
        }



    }
}
