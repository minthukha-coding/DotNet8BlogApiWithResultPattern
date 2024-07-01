namespace DotNet8BlogApiWithResultPattern.Controllers;

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

    [HttpGet("{blogId}")]
    public async Task<IActionResult> GetBlog(int blogId)
    {
        var result = await _blogService.GetBlog(blogId);
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }    

    [HttpPut("{blogId}")]
    public async Task<IActionResult> UpdateBlog(int blogId,BlogModel reqModel)
    {
        reqModel.BlogId = blogId;   
        var result = await _blogService.UpdateBlog(reqModel);
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogModel reqModel)
    {
        var result = await _blogService.CreateBlog(reqModel);
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpDelete("{blogId}")]
    public async Task<IActionResult> DeleteBlog(int blogId)
    {
        var result = await _blogService.DeleteBlogAsync(blogId);
        return result.IsSuccess ? Ok("Delete Blog Success") : BadRequest(result.Error);
    }
}

