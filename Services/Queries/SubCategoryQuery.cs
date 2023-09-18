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
    public class SubCategoryQuery : IRequest<IList<SubCategoryDTO>>
    {
        

        public class SubCategoryQueryHandler : IRequestHandler<SubCategoryQuery, IList<SubCategoryDTO>> {

            private readonly IConfiguration _configuration;
            public SubCategoryQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<SubCategoryDTO>> Handle(SubCategoryQuery query, CancellationToken cancellationToken)
            {
                var sql = "select sc.*,l.title as publication,c.categoryname ,a.title as articletype from SubCategories sc join lookups l on sc.publicationid=l.lookupid join lookups a on sc.articletypeid=a.lookupid join categories c on c.categoryid=sc.categoryid";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<SubCategoryDTO>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
