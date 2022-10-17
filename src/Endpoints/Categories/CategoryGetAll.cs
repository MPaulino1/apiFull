using ApiFull.Domain.Products;
using ApiFull.Infra.Data;

namespace ApiFull.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(categories => new CategoryResponse { Id = c.Id, Name = c.Name, Active = categories.Active });

        return Results.Ok(response);
    }
}
