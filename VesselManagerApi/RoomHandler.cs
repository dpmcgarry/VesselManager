namespace VesselManagerApi;
using libVesselManager;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public static class RoomHandler
{
    public static async Task<Results<Ok<Room[]>, NotFound>> GetAllRooms(VesselManagerContext db)
    {
        var rooms = await db.Rooms.ToArrayAsync();
        return TypedResults.Ok(rooms);
    }
}