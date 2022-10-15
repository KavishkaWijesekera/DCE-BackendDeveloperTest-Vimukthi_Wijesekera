using DCE___Vimukthi_Wijesekera.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        int Create(Customer customer);
        List<Customer> GetAll();
        int Update(Customer customer);
        int Delete(Guid userId);
    }
}
