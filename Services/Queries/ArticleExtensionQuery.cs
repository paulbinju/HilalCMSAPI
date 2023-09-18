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
    public class ArticleExtensionQuery : IRequest<IList<ArticleExtensionDTO>>
    {
        public int ArticleID { get; set; }
    }
    public class ArticleExtensionQueryHandler : IRequestHandler<ArticleExtensionQuery, IList<ArticleExtensionDTO>>
    {

        private readonly IConfiguration _configuration;
        public ArticleExtensionQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ArticleExtensionDTO>> Handle(ArticleExtensionQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select * from articleextensions where articleid=" + query.ArticleID;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleExtensionDTO>(sql);
                return result.ToList();
            }
        }
    }

}
