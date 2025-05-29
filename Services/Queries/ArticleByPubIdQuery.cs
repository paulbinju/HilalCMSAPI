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
    public class ArticleByPubId : IRequest<IList<ArticleDTO>>
    {
        public int publicationID { get; set; }
        public int issueID { get; set; }

    }
    public class ArticleByPubIdHandler : IRequestHandler<ArticleByPubId, IList<ArticleDTO>>
    {

        private readonly IConfiguration _configuration;
        public ArticleByPubIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ArticleDTO>> Handle(ArticleByPubId query, CancellationToken cancellationToken)
        {
            var sql = @"select a.*,at.title as articletype,pub.title as publication,u.name  from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join users u on u.userid= a.authorid
                            where a.publicationid=" + query.publicationID + " and a.issueid= " + query.issueID + " order by a.articleid desc";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleDTO>(sql);
                return result.ToList();
            }
        }
    }

}
