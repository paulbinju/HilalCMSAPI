using Domain.Models;
using MediatR;
using Services.Interface;

namespace Services.Command
{
    public class ArticleSubCategoriesDelCommand : IRequest<Int32>
    {
        public int ArticleID { get; set; }
    }
    public class ArticleSubCategoriesDelCommandHandler : IRequestHandler<ArticleSubCategoriesDelCommand, Int32>
    {
        private readonly IGenericRepository<ArticleSubCategory> _ArticleSubCategoryRepository;

        public ArticleSubCategoriesDelCommandHandler(IGenericRepository<ArticleSubCategory> ArticleSubCategoryRepository)
        {
            _ArticleSubCategoryRepository = ArticleSubCategoryRepository;
        }

        public async Task<int> Handle(ArticleSubCategoriesDelCommand request, CancellationToken cancellationToken)
        {
            _ArticleSubCategoryRepository.DeleteRangeAsync(request.ArticleID, "ArticleID");
            return 0;
        }
    }
}