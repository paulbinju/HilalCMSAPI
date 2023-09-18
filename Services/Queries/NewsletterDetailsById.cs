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
    public class NewsletterDetailsById : IRequest<IList<NewsletterDetailDTO>>
    {
        public int NewsletterID { get; set; }
    }
    public class NewsletterDetailsByIdHandler : IRequestHandler<NewsletterDetailsById, IList<NewsletterDetailDTO>>
    {

        private readonly IConfiguration _configuration;


        public NewsletterDetailsByIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<NewsletterDetailDTO>> Handle(NewsletterDetailsById query, CancellationToken cancellationToken)
        {
            var sql = @"select i.*,l.title as Category, a.title as ArticleTitle 
                            from NewsletterDetails i 
                            join Lookups l on i.categoryid=l.lookupid 
                            join Articles a on a.articleid=i.articleid
                            where i.newsletterid=" + query.NewsletterID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<NewsletterDetailDTO>(sql);
                return result.ToList();
            }
        }
    }

}
