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
    public class CategoryQuery : IRequest<IList<CategoryDTO>>
    {
        

        public class CategoryQueryHandler : IRequestHandler<CategoryQuery, IList<CategoryDTO>> {

            private readonly IConfiguration _configuration;
            public CategoryQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<CategoryDTO>> Handle(CategoryQuery query, CancellationToken cancellationToken)
            {
                var sql = "select c.*,l.title as publication from Categories c join lookups l on c.publicationid=l.lookupid";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<CategoryDTO>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
