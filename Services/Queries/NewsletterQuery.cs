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
    public class NewsletterQuery : IRequest<IList<NewsletterDTO>>
    {
        public int PublicationID { get; set; }
    }
    public class NewsletterQueryHandler : IRequestHandler<NewsletterQuery, IList<NewsletterDTO>>
    {

        private readonly IConfiguration _configuration;


        public NewsletterQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<NewsletterDTO>> Handle(NewsletterQuery query, CancellationToken cancellationToken)
        {
            var sql = "select top 100 i.*,l.title as publication from Newsletters i join Lookups l on i.publicationid=l.lookupid where i.PublicationID=" + query.PublicationID + " order by i.newsletterid desc";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<NewsletterDTO>(sql);
                return result.ToList();
            }
        }
    }

}
