using FinalAssessment.Core.UnitOfWork;

namespace FinalAssessment.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
