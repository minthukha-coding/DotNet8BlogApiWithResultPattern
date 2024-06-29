using DotNet8BlogApiWithResultPattern.Models;

namespace DotNet8BlogApiWithResultPattern.BlogSamplesList;

public class BlogSimpleList
{
    private static List<BlogModel> _blogs = new()
{
        new BlogModel { Id = 1, Title = "Digital Transformation", Author = "EthanTaylor", Content = "How digital technologies are reshaping businesses and society." },
        new BlogModel { Id = 2, Title = "Journey to the Unknown", Author = "JaneDoe", Content = "Exploring the mysteries of the universe." },
        new BlogModel { Id = 3, Title = "Tech Innovations", Author = "JohnSmith", Content = "The latest advancements in technology and their impact." },
        new BlogModel { Id = 4, Title = "Healthy Living", Author = "AliceJohnson", Content = "Tips and tricks for a healthier lifestyle." },
        new BlogModel { Id = 5, Title = "Travel Diaries", Author = "EmilyClark", Content = "Adventures and experiences from around the world." },
        new BlogModel { Id = 6, Title = "Culinary Delights", Author = "MichaelBrown", Content = "Exploring the art of cooking and delicious recipes." },
        new BlogModel { Id = 7, Title = "Mindfulness and Meditation", Author = "SophiaDavis", Content = "The benefits of mindfulness and how to practice it." },
        new BlogModel { Id = 8, Title = "Financial Freedom", Author = "DavidWilson", Content = "Strategies for achieving financial independence." },
        new BlogModel { Id = 9, Title = "Art and Creativity", Author = "OliviaMartinez", Content = "Inspiring creativity through various forms of art." },
        new BlogModel { Id = 10, Title = "Fitness and Wellbeing", Author = "LiamGarcia", Content = "Effective workouts and tips for staying fit." }
    };
    public static IEnumerable<BlogModel> GetBlogs()
    {
        return _blogs;
    }
    public static BlogModel GetBlog(int blogId)
    {
        return _blogs.FirstOrDefault(i => i.Id == blogId)!;
    }
    public static void UpdateBlog(BlogModel reqModel)
    {
        var findBlog = _blogs.FirstOrDefault(i => i.Id == reqModel.Id)!;
        if (findBlog != null) {
            findBlog.Title = reqModel.Title;
            findBlog.Author = reqModel.Author;
            findBlog.Content = reqModel.Content;
        }
    }
    //public static BlogModel FindBlogByID(int blogId)
    //{
    //    return _blogs.FirstOrDefault(i => i.Id == blogId)!;
    //}
};