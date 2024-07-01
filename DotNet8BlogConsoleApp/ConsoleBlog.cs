using DotNet8BlogApiWithResultPattern;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using DotNet8BlogApiWithResultPattern.Shared;
using Shared.Models;

namespace DotNet8BlogConsoleApp;

public class ConsoleBlog
{
    private string _blogEndPoint = "https://localhost:7297/api/blog";
    public async Task Run()
    {
        //await Edit(1007);
        //await Edit(30);
        await Create("mk title", "mk author", "mk content");
        await Read();
        await Delete(8);
        await Edit(3);
    }

    #region Read
    public async Task Read()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(_blogEndPoint);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Result<List<BlogModel>> result = JsonConvert.DeserializeObject<Result<List<BlogModel>>>(jsonResponse);
            foreach (BlogModel item in result.Data)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
    }
    #endregion

    #region Edit
    public async Task Edit(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Result<BlogModel> result = JsonConvert.DeserializeObject<Result<BlogModel>>(jsonResponse);
            Console.WriteLine(result.Data.BlogId);
            Console.WriteLine(result.Data.BlogTitle);
            Console.WriteLine(result.Data.BlogAuthor);
            Console.WriteLine(result.Data.BlogContent);
        }
        else
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
    #endregion

    #region Create
    public async Task Create(string title, string author, string content)
    {
        var Blog = new BlogModel
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string jsonBlog = JsonConvert.SerializeObject(Blog);
        HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync(_blogEndPoint, httpContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Create Blog Success");
        }
        else
        {
            Console.WriteLine("Create Blog Failed");
        }
    }
    #endregion

    #region Update
    public async Task Update(int id, string title, string author, string content)
    {
        var Blog = new BlogModel
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string jsonBlog = JsonConvert.SerializeObject(Blog);
        HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Update Blog Success");
        }
        else
        {
            Console.WriteLine("Update Blog Failed");
        }
    }
    #endregion

    #region Delete
    public async Task Delete(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Delete Blog Success");
        }
        else
        {
            Console.WriteLine("Delete Blog Failed");
        }
    }
    #endregion
}
