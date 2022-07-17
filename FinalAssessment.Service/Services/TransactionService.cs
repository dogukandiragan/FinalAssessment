using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Repositories;
using FinalAssessment.Core.Services;
using FinalAssessment.Core.UnitOfWork;
using FinalAssessment.Data;
using FinalAssessment.WorkerService;

namespace FinalAssessment.Service.Services
{
    public class TransactionService : Service<TransactionApp>, ITransactionService
    {
        private readonly AppDbContext _context;
        public TransactionService(IGenericRepository<TransactionApp> repository, IUnitOfWork unitOfWork, ITransactionRepository _transactionRepository, AppDbContext context) : base(repository, unitOfWork)
        {

            _context = context;
        }


        //getting top 5 transactions
        public List<WeeklyReportDto> GetTransactionListBySP()
        {
            WeeklyReport wero = new WeeklyReport(_context);
            return wero.GetTopTransactionListWithSP();
        }

    }
}