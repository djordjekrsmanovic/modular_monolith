using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Infrastructure.Database.Constants
{
    public class DatabaseConnectioParams {

        private IConfiguration _configuration;

        public DatabaseConnectioParams(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration["DatabaseParams:ConnectionString"];

    }

}
