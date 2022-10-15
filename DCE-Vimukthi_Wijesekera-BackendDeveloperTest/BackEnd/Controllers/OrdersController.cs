using DCE___Vimukthi_Wijesekera.DTOs;
using DCE___Vimukthi_Wijesekera.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [Route("activeordersbycustomer")]
        [HttpGet]
        public ActionResult<List<OrderDTO>> GetActiveOrdersByCustomer(Guid CustomerId)
        {
            List<OrderDTO> orderList = new List<OrderDTO>();
            try
            {
                orderList = _orderRepo.GetActiveOrdersByCustomer(CustomerId);
                return Ok(orderList);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
