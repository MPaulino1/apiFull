using ApiFull.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace ApiFull.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")] 
    public static async Task <IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query) 
    {
        var results = await query.Execute(page.Value, rows.Value);
        return Results.Ok(results);
    }
}
