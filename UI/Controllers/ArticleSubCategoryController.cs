using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Queries;
using UserInterface.Controllers;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleSubCategoryController : BaseController
    {
        private IGenericRepository<ArticleSubCategory> _ArticleSubCategory;
        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public ArticleSubCategoryController(IGenericRepository<ArticleSubCategory> ArticleSubCategory, IMapper mapper, IConfiguration configuration, IGenericRepository<ArticleExtension> articleExtension)
        {
            _ArticleSubCategory = ArticleSubCategory;
            _mapper = mapper;
            this.configuration = configuration;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new ArticleQuery()));

        [HttpGet("{articleID}")]
        public async Task<IActionResult> CategoriesByArticleId(int articleID) => Ok(await Mediator.Send(new SubCategoryByArticleIdQuery() { articleID = articleID }));
    }
}
