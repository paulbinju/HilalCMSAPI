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
            var sql = @"select a.Dateline,a.Byline,a.Slug,a.Title,a.ArticleBody,a.FeaturedImageURL,a.FeaturedImageCaption
      ,a.Tags,a.CreatedDate,a.CountryID,a.ArticleTypeID,a.PublicationID,a.AuthorID,ac.CategoryID,asubc.subcategoryid as SubCategoryID
      ,a.IssueID,a.ShowInTA,a.ShowInMAG,a.RefNo,a.LookupID,a.UserID,a.Published,a.PublishedDate
      ,a.PREmails,at.title as articletype,pub.title as publication,u.name,aut.title as author,con.title as country
                            from articles a
                            left join Lookups at on at.lookupid= a.articletypeid
                            left join Lookups pub on pub.lookupid= a.publicationid
                            left join Lookups aut on aut.lookupid= a.authorid
                            left join users u on u.userid= a.authorid
                            left join Lookups con on con.lookupid= a.countryid
							left join ArticleCategories ac on ac.articleid= a.articleid
							left join ArticleSubCategories asubc on asubc.articleid= a.articleid
                            where a.articleID=" + query.articleID;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ArticleDTO>(sql);
                return result.ToList();
            }
        }
    }

}
