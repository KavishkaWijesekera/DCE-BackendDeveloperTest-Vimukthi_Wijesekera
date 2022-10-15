using DCE___Vimukthi_Wijesekera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetActiveOrdersByCustomer(Guid CustomerId);
    }
}
