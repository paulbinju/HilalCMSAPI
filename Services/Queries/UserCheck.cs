using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services.Queries
{
    public class UserCheckQuery : IRequest<IList<UserDTO>>
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
    }


        public class UserCheckQueryHandler : IRequestHandler<UserCheckQuery, IList<UserDTO>>
        {

            private readonly IConfiguration _configuration;
            public UserCheckQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<UserDTO>> Handle(UserCheckQuery query, CancellationToken cancellationToken)
            {
            var sql = "select * from Users where emailid='" + query.EmailID + "' and password='" + query.Password + "' ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<UserDTO>(sql);
                    return result.ToList();
                }
            }
        }
    
}
