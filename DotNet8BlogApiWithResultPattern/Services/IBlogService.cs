using DotNet8BlogApiWithResultPattern.Models;
using DotNet8BlogApiWithResultPattern.Shared;

namespace DotNet8BlogApiWithResultPattern.Services
{
    public interface IBlogService
    {
        Task<Result<IEnumerable<BlogModel>>> GetBlogsAsync();
    }
}
