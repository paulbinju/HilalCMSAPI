using Dapper;
using Domain.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository;
using Services.DTO;

namespace Services.Queries
{
    public class CategoryByArticleIdQuery : IRequest<IList<ArticleCategory>>
    {
        public int articleID { get; set; }

    }
    public class CategoryByArticleIdHandler : IRequestHandler<CategoryByArticleIdQuery, IList<ArticleCategory>>
    {
        private readonly IConfiguration _configuration;
        public CategoryByArticleIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IList<ArticleCategory>> Handle(CategoryByArticleIdQuery query, CancellationToken cancellationToken)
        {
            int articleID = query.articleID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connection);
                using (var dbContext = new AppDbContext(optionsBuilder.Options))
                {
                    var result = dbContext.ArticleCategories.Where(c => c.ArticleID == articleID).ToList();
                    return (IList<ArticleCategory>)result;
                }
            }
        }
    }
}