using DotNet8BlogApiWithResultPattern.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8BlogApiWithResultPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogsAsync()
        {
            var result = await _blogService.GetBlogsAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
