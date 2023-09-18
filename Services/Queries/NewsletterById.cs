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
    public class NewsletterById : IRequest<IList<NewsletterDTO>>
    {
        public int NewsletterID { get; set; }
    }
    public class NewsletterByIdHandler : IRequestHandler<NewsletterById, IList<NewsletterDTO>>
    {

        private readonly IConfiguration _configuration;


        public NewsletterByIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<NewsletterDTO>> Handle(NewsletterById query, CancellationToken cancellationToken)
        {
            var sql = "select i.*,l.title as publication from Newsletters i join Lookups l on i.publicationid=l.lookupid where i.newsletterid=" + query.NewsletterID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<NewsletterDTO>(sql);
                return result.ToList();
            }
        }
    }

}
