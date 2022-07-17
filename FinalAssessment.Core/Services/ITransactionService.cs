using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Services;

namespace FinalAssessment.Core.Services
{
    
    public interface ITransactionService : IService<TransactionApp>
    {

       List<WeeklyReportDto> GetTransactionListBySP();
    }

}

