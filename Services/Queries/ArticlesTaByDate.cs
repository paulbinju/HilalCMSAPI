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
using System.Web;

namespace Services.Queries
{
    public class ArticlesTaByDate : IRequest<IList<ArticleDTO>>
    {
        public string createdDate { get; set; }

    }
    public class ArticlesTaByDateHandler : IRequestHandler<ArticlesTaByDate, IList<ArticleDTO>>
    {

        private readonly IConfiguration _configuration;
        public ArticlesTaByDateHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ArticleDTO>> Handle(ArticlesTaByDate query, CancellationToken cancellationToken)
        {
            string cdate = HttpUtility.UrlDecode(query.createdDate);

            var sql = @"select a.*,at.title as articletype,pub.title as publication,u.name,c.categoryname,sc.subcategoryname  from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join users u on u.userid= a.authorid
                            left join categories c on c.categoryid= a.categoryid
                            left join subcategories sc on sc.subcategoryid=a.subcategoryid 
                            where a.publicationid=1 and createddate between '" + cdate + " 00:00:00' and '" + cdate + " 23:59:59'";



            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleDTO>(sql);
                return result.ToList();
            }
        }
    }

}
