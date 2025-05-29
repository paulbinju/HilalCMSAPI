using Domain.Models;
using MediatR;
using Services.Interface;

namespace Services.Command
{
    public class ArticleCategoriesDelCommand : IRequest<Int32>
    {
        public int ArticleID { get; set; }
    }
    public class ArticleCategoriesDelCommandHandler : IRequestHandler<ArticleCategoriesDelCommand, Int32>
    {
        private readonly IGenericRepository<ArticleCategory> _articleCategoryRepository;

        public ArticleCategoriesDelCommandHandler(IGenericRepository<ArticleCategory> articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public async Task<int> Handle(ArticleCategoriesDelCommand request, CancellationToken cancellationToken)
        {
            _articleCategoryRepository.DeleteRangeAsync(request.ArticleID, "ArticleID");
            return 0;
        }
    }
}