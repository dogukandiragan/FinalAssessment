
using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Repositories;
using FinalAssessment.Data;
using FinalAssessment.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessment.Data.Repositories
{

    public class TransactionRepository : GenericRepository<TransactionApp>, ITransactionRepository
    {
        
        public TransactionRepository(AppDbContext context) : base(context)
        {
     
        }

    }
}
