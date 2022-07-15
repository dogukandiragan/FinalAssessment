using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;

namespace FinalAssessment.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<CustomerApp>
    {

        bool CheckCustomerPhone(string callnumber);
   

    }

}
