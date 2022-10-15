using DCE___Vimukthi_Wijesekera.DTOs;
using DCE___Vimukthi_Wijesekera.Entities;
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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomersController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CustomerDTO customerDto)
        {
            try
            {
                Customer customer = new Customer();
                customer.UserId = Guid.NewGuid();
                customer.Username = customerDto.Username;
                customer.Email = customerDto.Email;
                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.CreatedOn = customerDto.CreatedOn;
                customer.IsActive = customerDto.IsActive;
                int result = _customerRepo.Create(customer);

                if (result == 1)
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            return BadRequest();
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()

        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = _customerRepo.GetAll();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [Route("update")]
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            try
            {
                int result = _customerRepo.Update(customer);

                if (result == 1)
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }

            return BadRequest();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(Guid userId)
        {
            try
            {
                int result = _customerRepo.Delete(userId);

                if (result == 1)
                {
                    return Ok(new { RemovedCustomerId = userId });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            return BadRequest();
        }
    }
}
