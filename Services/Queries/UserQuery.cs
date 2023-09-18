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
    public class UserQuery : IRequest<IList<UserDTO>>
    {
        

        public class UserQueryHandler : IRequestHandler<UserQuery, IList<UserDTO>> {

            private readonly IConfiguration _configuration;
            public UserQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<UserDTO>> Handle(UserQuery query, CancellationToken cancellationToken)
            {
                var sql = "select * from Users u join Lookups l on u.roleid=l.lookupid";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<UserDTO>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
