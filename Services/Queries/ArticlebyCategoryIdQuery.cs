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
    public class ArticleByCategoryIdQuery : IRequest<IList<ArticleDTO>>
    {
        public int categoryID { get; set; }

    }
    public class ArticlebySubCategoryIdHandler : IRequestHandler<ArticleByCategoryIdQuery, IList<ArticleDTO>>
    {

        private readonly IConfiguration _configuration;
        public ArticlebySubCategoryIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ArticleDTO>> Handle(ArticleByCategoryIdQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select top 100 a.articleid, a.title,at.title as articletype,pub.title as publication,u.name from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join users u on u.userid= a.authorid
                            left join categories c on c.categoryid= a.categoryid
                            left join subcategories sc on sc.subcategoryid=a.subcategoryid";
            if (query.categoryID != 0)
            {
                sql += " where a.categoryid = " + query.categoryID;
            }
            sql += "  order by a.articleid desc";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleDTO>(sql);
                return result.ToList();
            }
        }
    }

}

