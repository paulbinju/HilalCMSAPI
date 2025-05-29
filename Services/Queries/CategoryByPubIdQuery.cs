using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Services.DTO;

namespace Services.Queries
{
    public class CategoryByPubIdQuery : IRequest<IList<CategoryDTO>>
    {
        public int publicationID { get; set; }

    }
    public class CategoryByPubIdHandler : IRequestHandler<CategoryByPubIdQuery, IList<CategoryDTO>>
    {
        private readonly IConfiguration _configuration;
        public CategoryByPubIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IList<CategoryDTO>> Handle(CategoryByPubIdQuery query, CancellationToken cancellationToken)
        {
            var sql = @"Select * from Categories where PublicationID=" + query.publicationID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CategoryDTO>(sql);
                return result.ToList();
            }
        }
    }
}