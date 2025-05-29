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
    public class SubCategoryByArticleIdQuery : IRequest<IList<ArticleSubCategory>>
    {
        public int articleID { get; set; }

    }
    public class SubCategoryByArticleIdHandler : IRequestHandler<SubCategoryByArticleIdQuery, IList<ArticleSubCategory>>
    {
        private readonly IConfiguration _configuration;
        public SubCategoryByArticleIdHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IList<ArticleSubCategory>> Handle(SubCategoryByArticleIdQuery query, CancellationToken cancellationToken)
        {
            int articleID = query.articleID;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connection);
                using (var dbContext = new AppDbContext(optionsBuilder.Options))
                {
                    var result = dbContext.ArticleSubCategories.Where(c => c.ArticleID == articleID).ToList();
                    return (IList<ArticleSubCategory>)result;
                }
            }
        }
    }
}