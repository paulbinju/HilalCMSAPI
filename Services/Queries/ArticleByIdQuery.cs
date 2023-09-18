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
    public class ArticleByIdQuery : IRequest<IList<ArticleDTO>>
    {
        public int articleID { get; set; }

    }
    public class ArticleByIdQueryHandler : IRequestHandler<ArticleByIdQuery, IList<ArticleDTO>>
    {

        private readonly IConfiguration _configuration;
        public ArticleByIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ArticleDTO>> Handle(ArticleByIdQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select 
                            a.*,at.title as articletype,pub.title as publication,u.name,c.categoryname,sc.subcategoryname,aut.title as author,con.title as country
                            from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join Lookups aut on aut.lookupid= a.authorid
                            left join users u on u.userid= a.authorid
                            left join categories c on c.categoryid= a.categoryid
                            left join Lookups con on con.lookupid= a.countryid
                            left join subcategories sc on sc.subcategoryid=a.subcategoryid where a.articleID=" + query.articleID;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleDTO>(sql);
                return result.ToList();
            }
        }
    }

}
