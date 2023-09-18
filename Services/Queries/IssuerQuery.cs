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
    public class IssueQuery : IRequest<IList<IssueDTO>>
    {
        public int PublicationID { get; set; }
    }
    public class IssueQueryHandler : IRequestHandler<IssueQuery, IList<IssueDTO>>
    {

        private readonly IConfiguration _configuration;


        public IssueQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<IssueDTO>> Handle(IssueQuery query, CancellationToken cancellationToken)
        {
            var sql = "select i.*,l.title as publication from Issues i join Lookups l on i.publicationid=l.lookupid where i.PublicationID=" + query.PublicationID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<IssueDTO>(sql);
                return result.ToList();
            }
        }
    }

}
