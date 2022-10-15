using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public Guid OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public bool IsOrderActive { get; set; }

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime ProductCreatedOn { get; set; }
        public bool IsProductActive { get; set; }

        public string SupplierName { get; set; }
        public DateTime SupplierCreatedOn { get; set; }
        public bool IsSupplierActive { get; set; }
    }
}
