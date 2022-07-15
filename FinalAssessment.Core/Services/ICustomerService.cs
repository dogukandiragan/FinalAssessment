using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Services;

namespace FinalAssessment.Service.Services
{
    public interface ICustomerService : IService<CustomerApp>
    {
         
        Task<List<MonthlyReportDto>> GetCityListWithSP();


    }


}