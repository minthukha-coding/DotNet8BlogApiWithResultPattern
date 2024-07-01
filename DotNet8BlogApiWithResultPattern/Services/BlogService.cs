namespace DotNet8BlogApiWithResultPattern.Services;

public class BlogService : IBlogService
{
    private readonly BlogRepository _blogRepository;

    public BlogService(BlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    #region UseWithBlogRepository

    public async Task<Result<IEnumerable<BlogModel>>> GetBlogs()
    {
        var blogs = await _blogRepository.GetBlogs();
        if (blogs == null || !blogs.Any())
        {
            return Result.Failure<IEnumerable<BlogModel>>("No blogs found.");
        }
        return Result.Success(blogs);
    }

    public async Task<Result<BlogModel>> GetBlog(int blogId)
    {
        var blog = await _blogRepository.GetBlog(blogId);
        if (blog == null)
        {
            return Result.Failure<BlogModel>($"Blog with BlogID {blogId} is not found");
        }
        return Result.Success(blog);
    }

    public async Task<Result<BlogModel>> UpdateBlog(BlogModel reqModel)
    {
        if (reqModel == null)
        {
            return Result.Failure<BlogModel>("ReqModel is required");
        }
        await _blogRepository.UpdateBlogAsync(reqModel);
        return Result.Success(reqModel);
    }

    public async Task<Result<BlogModel>> CreateBlog(BlogModel reqModel)
    {
        if (reqModel == null)
        {
            return Result.Failure<BlogModel>("ReqModel is required");
        }

        var createdBlog = await _blogRepository.CreateBlog(reqModel);

        if (createdBlog == null)
        {
            return Result.Failure<BlogModel>("Failed to create blog");
        }

        return Result.Success(createdBlog);
    }

    public async Task<Result<bool>> DeleteBlogAsync(int blogId)
    {
        var existingBlog = await _blogRepository.GetBlog(blogId);
        if (existingBlog == null)
        {
            return Result.Failure<bool>($"Blog with BlogID {blogId} not found");
        }

        await _blogRepository.DeleteBlogAsync(blogId);

        var deletedBlog = await _blogRepository.GetBlog(blogId);
        if (deletedBlog != null)
        {
            return Result.Failure<bool>($"Failed to delete blog with ID {blogId}");
        }

        return Result.Success(true);
    }


    #endregion

    #region UseWithBlogSimpleList

    //public Task<Result<IEnumerable<BlogModel>>> GetBlogs()
    //{
    //    var blog = BlogSimpleList.GetBlogs();
    //    if (blog == null || !blog.Any())
    //    {
    //        return Task.FromResult(Result.Failure<IEnumerable<BlogModel>>("No blogs found."));
    //    }
    //    return Task.FromResult(Result.Success(blog));
    //}
    //public Task<Result<BlogModel>> GetBlog(int blogId)
    //{
    //    var blog = BlogSimpleList.GetBlog(blogId);
    //    if(blog == null)
    //    {
    //        return Task.FromResult(Result.Failure<BlogModel>($"Blog with BlogID {blogId} is not found"));
    //    }
    //    return Task.FromResult(Result.Success(blog));
    //}
    //public Task<Result<BlogModel>> UpdateBlog(BlogModel reqModel)
    //{
    //    if(reqModel == null)
    //    {
    //        return Task.FromResult(Result.Failure<BlogModel>("ReqModel is required"));
    //    }
    //    BlogSimpleList.UpdateBlog(reqModel);
    //    return Task.FromResult(Result.Success(reqModel));
    //}

    #endregion

}