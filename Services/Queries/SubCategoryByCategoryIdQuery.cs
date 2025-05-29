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
    public class SubCategoryByCategoryIdQuery : IRequest<IList<SubCategoryDTO>>
    {
        public int[] categoryID { get; set; }

    }
    public class SubCategoryByCategoryIdQueryHandler : IRequestHandler<SubCategoryByCategoryIdQuery, IList<SubCategoryDTO>>
    {
        private readonly IConfiguration _configuration;
        public SubCategoryByCategoryIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SubCategoryDTO>> Handle(SubCategoryByCategoryIdQuery query, CancellationToken cancellationToken)
        {
            string CatIDarray = String.Join(",", query.categoryID);
            var sql = "Select * from SubCategories  where CategoryId in (" + CatIDarray + ")";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<SubCategoryDTO>(sql);
                return result.ToList();
            }
        }
    }

}
