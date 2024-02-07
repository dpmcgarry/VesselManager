namespace VesselManagerApi;

public static class EnumEndpoints
{
    public static async Task<IResult> GetAllTodos()
    {
        return TypedResults.Ok(new List<String> { "Foo", "Bar" });
    }
}

