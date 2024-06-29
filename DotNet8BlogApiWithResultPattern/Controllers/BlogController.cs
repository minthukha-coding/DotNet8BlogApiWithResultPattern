using DotNet8BlogApiWithResultPattern.Models;
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
        public async Task<IActionResult> GetBlogs()
        {
            var result = await _blogService.GetBlogs();
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
        [HttpGet("blogId")]
        public async Task<IActionResult> GetBlog(int blogId)
        {
            var result = await _blogService.GetBlog(blogId);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }    
        [HttpPut("blogId")]
        public async Task<IActionResult> UpdateBlog(BlogModel reqModel)
        {
            var result = await _blogService.UpdateBlog(reqModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}

