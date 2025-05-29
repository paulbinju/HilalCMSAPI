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
    public class ArticleCategoryController : BaseController
    {
        private IGenericRepository<ArticleCategory> _articleCategory;
        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public ArticleCategoryController(IGenericRepository<ArticleCategory> articleCategory, IMapper mapper, IConfiguration configuration, IGenericRepository<ArticleExtension> articleExtension)
        {
            _articleCategory = articleCategory;
            _mapper = mapper;
            this.configuration = configuration;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new ArticleQuery()));

        [HttpGet("{articleID}")]
        public async Task<IActionResult> CategoriesByArticleId(int articleID) => Ok(await Mediator.Send(new CategoryByArticleIdQuery() { articleID = articleID }));
    }
}
