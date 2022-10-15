using DCE___Vimukthi_Wijesekera.DTOs;
using DCE___Vimukthi_Wijesekera.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<OrderDTO> GetActiveOrdersByCustomer(Guid CustomerId)
        {
            List<OrderDTO> orderList = new List<OrderDTO>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();

            string sp = "SP_GetActiveOrdersByCustomer";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@CustomerId", SqlDbType.UniqueIdentifier);
            param.Value = CustomerId;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderDTO orderDto = new OrderDTO();
                orderDto.OrderId = Guid.Parse(dt.Rows[i]["OrderId"].ToString());
                orderDto.ProductId = Guid.Parse(dt.Rows[i]["ProductId"].ToString());
                orderDto.OrderStatus = Convert.ToInt32(dt.Rows[i]["OrderStatus"]);
                orderDto.OrderType = Convert.ToInt32(dt.Rows[i]["OrderType"]);
                orderDto.OrderBy = Guid.Parse(dt.Rows[i]["OrderBy"].ToString());
                orderDto.OrderedOn = Convert.ToDateTime(dt.Rows[i]["OrderedOn"]);
                orderDto.ShippedOn = Convert.ToDateTime(dt.Rows[i]["ShippedOn"]);
                orderDto.IsOrderActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                orderDto.ProductName = dt.Rows[i]["ProductName"].ToString();
                orderDto.UnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]);
                orderDto.SupplierId = Guid.Parse(dt.Rows[i]["SupplierId"].ToString());
                orderDto.ProductCreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                orderDto.IsProductActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                orderDto.SupplierName = dt.Rows[i]["SupplierName"].ToString();
                orderDto.SupplierCreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                orderDto.IsSupplierActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                orderList.Add(orderDto);
            }
            con.Close();

            return orderList;
        }
    }
}
