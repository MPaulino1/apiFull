using ApiFull.Domain.Products;
using ApiFull.Infra.Data;
using IWantApp.Endpoints.Categories;
using Microsoft.AspNetCore.Authorization;

namespace ApiFull.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse (c.Id, c.Name, c.Active ));

        return Results.Ok(response);
    }
}
