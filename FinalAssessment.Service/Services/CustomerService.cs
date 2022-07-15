using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Repositories;
using FinalAssessment.Core.UnitOfWork;
using FinalAssessment.Data;
using FinalAssessment.WorkerService;

namespace FinalAssessment.Service.Services
{
    public class CustomerService : Service<CustomerApp>, ICustomerService
    {
        private AppDbContext _context;

        public CustomerService(IGenericRepository<CustomerApp> repository, IUnitOfWork unitOfWork, ICustomerRepository _customerRepository, AppDbContext context) : base(repository, unitOfWork)
        {
            _context = context;
        }

        public async Task<List<MonthlyReportDto>> GetCityListWithSP()
        {
            MonthlyReport moro = new MonthlyReport(_context);
            return await moro.GetCityListWithSP();
          
        }

    }
}