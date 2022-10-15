using DCE___Vimukthi_Wijesekera.Entities;
using DCE___Vimukthi_Wijesekera.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DCE___Vimukthi_Wijesekera.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Create(Customer customer)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            string query = $"INSERT INTO Customer VALUES ('{customer.UserId}', '{customer.Username}', '{customer.Email}', '{customer.FirstName}', '{customer.LastName}', '{customer.CreatedOn}', '{customer.IsActive}')";
            SqlCommand cmd = new SqlCommand(query, con);
            var result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Customer customer = new Customer();
                customer.UserId = Guid.Parse(dt.Rows[i]["UserId"].ToString());
                customer.Username = dt.Rows[i]["Username"].ToString();
                customer.Email = dt.Rows[i]["Email"].ToString();
                customer.FirstName = dt.Rows[i]["FirstName"].ToString();
                customer.LastName = dt.Rows[i]["LastName"].ToString();
                customer.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                customer.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                customers.Add(customer);
            }

            return customers;
        }

        public int Update(Customer customer)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            string query = $"UPDATE Customer SET Username = '{customer.Username}', Email = '{customer.Email}', FirstName = '{customer.FirstName}', LastName = '{customer.LastName}', CreatedOn = '{customer.CreatedOn}', IsActive = '{customer.IsActive}' WHERE UserId = '{customer.UserId}'";
            SqlCommand cmd = new SqlCommand(query, con);
            var result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public int Delete(Guid userId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            string query = $"DELETE FROM Customer WHERE UserId = '{userId}'";
            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
    }
}
