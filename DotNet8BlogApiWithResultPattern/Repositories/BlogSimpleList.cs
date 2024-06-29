using DotNet8BlogApiWithResultPattern.Models;

namespace DotNet8BlogApiWithResultPattern.Repositories;

public class BlogSimpleList
{
    private static List<BlogModel> _blogs = new()
    {
            new BlogModel { BlogId = 1, BlogTitle = "Digital Transformation", BlogAuthor = "EthanTaylor", BlogContent = "How digital technologies are reshaping businesses and society." },
            new BlogModel { BlogId = 2, BlogTitle = "Journey to the Unknown", BlogAuthor = "JaneDoe", BlogContent = "Exploring the mysteries of the universe." },
            new BlogModel { BlogId = 3, BlogTitle = "Tech Innovations", BlogAuthor = "JohnSmith", BlogContent = "The latest advancements in technology and their impact." },
            new BlogModel { BlogId = 4, BlogTitle = "Healthy Living", BlogAuthor = "AliceJohnson", BlogContent = "Tips and tricks for a healthier lifestyle." },
            new BlogModel { BlogId = 5, BlogTitle = "Travel Diaries", BlogAuthor = "EmilyClark", BlogContent = "Adventures and experiences from around the world." },
            new BlogModel { BlogId = 6, BlogTitle = "Culinary Delights", BlogAuthor = "MichaelBrown", BlogContent = "Exploring the art of cooking and delicious recipes." },
            new BlogModel { BlogId = 7, BlogTitle = "Mindfulness and Meditation", BlogAuthor = "SophiaDavis",BlogContent = "The benefits of mindfulness and how to practice it." },
            new BlogModel { BlogId = 8, BlogTitle = "Financial Freedom", BlogAuthor = "DavidWilson", BlogContent = "Strategies for achieving financial independence." },
            new BlogModel { BlogId = 9, BlogTitle = "Art and Creativity", BlogAuthor = "OliviaMartinez", BlogContent = "Inspiring creativity through various forms of art." },
            new BlogModel { BlogId = 10,BlogTitle = "Fitness and Wellbeing", BlogAuthor = "LiamGarcia", BlogContent = "Effective workouts and tips for staying fit." }
        };
    public static IEnumerable<BlogModel> GetBlogs()
    {
        return _blogs;
    }
    public static BlogModel GetBlog(int blogId)
    {
        return _blogs.FirstOrDefault(i => i.BlogId == blogId)!;
    }
    public static void UpdateBlog(BlogModel reqModel)
    {
        var findBlog = _blogs.FirstOrDefault(i => i.BlogId == reqModel.BlogId)!;
        if (findBlog != null)
        {
            findBlog.BlogTitle = reqModel.BlogTitle;
            findBlog.BlogAuthor = reqModel.BlogAuthor;
            findBlog.BlogContent = reqModel.BlogContent;
        }
    }
    public static BlogModel FindBlogByID(int blogId)
    {
        return _blogs.FirstOrDefault(i => i.BlogId == blogId)!;
    }
};