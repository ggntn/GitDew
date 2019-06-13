using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models.db;
using TestStore.ViewModel;

namespace TestStore.Repo
{
    public class DevRepo
    {
        private readonly NorthwindContext context;
        private readonly IConfiguration configuration;

        public DevRepo(NorthwindContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public List<Shippers> GetListDATA()
        {
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("xxContext")))
                {
                    var xx = connection.Query<Shippers>("GetShipper");
                    return xx.ToList();
                }

            }
            catch (Exception ex)
            {
                return new List<Shippers>();
            }
        }
    }
}
