using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.DTOs
{
    public class CustomerDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
