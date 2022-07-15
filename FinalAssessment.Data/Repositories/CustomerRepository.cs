
using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Repositories;
using FinalAssessment.Data;
using FinalAssessment.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessment.Data.Repositories
{

    public class CustomerRepository : GenericRepository<CustomerApp>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context =  context;
        }



        //checking is phone number existed
        public  bool CheckCustomerPhone(string callNumber)
        {
            if (_context.Customers.Where(x => x.CallNumber == callNumber).FirstOrDefault() != null)
            {  return true; }
            return false;
        }




 
    }
}
