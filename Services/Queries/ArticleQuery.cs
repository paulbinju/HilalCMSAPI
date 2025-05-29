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
    public class ArticleQuery : IRequest<IList<ArticleDTO>>
    {
        

        public class ArticleQueryHandler : IRequestHandler<ArticleQuery, IList<ArticleDTO>> {

            private readonly IConfiguration _configuration;
            public ArticleQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<ArticleDTO>> Handle(ArticleQuery query, CancellationToken cancellationToken)
            {
                var sql = @"select a.*,at.title as articletype,pub.title as publication,u.name from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join users u on u.userid= a.authorid
                            order by a.articleid desc";

                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ArticleDTO>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
