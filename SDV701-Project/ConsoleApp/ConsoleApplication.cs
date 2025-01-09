using AutoMapper;
using BusinessLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using RestAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IClientClient _clientClient;
        private readonly IBookingClient _bookingClient;


        public ConsoleApplication(IClientClient clientClient, IBookingClient bookingClient)
        {
            _clientClient = clientClient;
            _bookingClient = bookingClient;
        }

        public void Run()
        {
            var connectionString = @"Data Source=203.211.98.168,1433;Initial Catalog=SDV701;Persist Security Info=True;User ID=KyrVorga;Password=6+1j&808YzJnEbmku2Ks;Encrypt=True;Trust Server Certificate=True";

            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new ModelContext(optionsBuilder.Options))
            {
                // Ensure the database and tables are created
                context.Database.EnsureCreated();

                // Your code to work with the database goes here
            }
        }


    }


}
