using Microsoft.EntityFrameworkCore;
using ThesisAPI.Converters;
using ThesisAPI.DTOs;
using ThesisAPI.Models;
namespace ThesisAPI.Controllers;

public static class VideoCardEndpoints
{
    public static void MapVideoCardEndpoints (this IEndpointRouteBuilder routes)
    {
        // GET All
        routes.MapGet("/api/VideoCard", async (ThesisContext db) =>
        {
            return (await db.VideoCards.ToListAsync()).ToDto();
        })
        .WithName("GetAllVideoCards")
        .Produces<List<VideoCard>>(StatusCodes.Status200OK);

        // GET Single
        routes.MapGet("/api/VideoCard/{id}", async (int VideoCardId, ThesisContext db) =>
        {
            return await db.VideoCards.FindAsync(VideoCardId)
                is VideoCardEntity model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetVideoCardById")
        .Produces<VideoCardEntity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // PUT
        routes.MapPut("/api/VideoCard/{id}", async (int VideoCardId, VideoCardEntity videoCard, ThesisContext db) =>
        {
            var foundModel = await db.VideoCards.FindAsync(VideoCardId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(videoCard);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateVideoCard")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        // POST
        routes.MapPost("/api/VideoCard/", async (VideoCardEntity videoCard, ThesisContext db) =>
        {
            db.VideoCards.Add(videoCard);
            await db.SaveChangesAsync();
            return Results.Created($"/VideoCards/{videoCard.VideoCardId}", videoCard);
        })
        .WithName("CreateVideoCard")
        .Produces<VideoCardEntity>(StatusCodes.Status201Created);

        // DELETE
        routes.MapDelete("/api/VideoCard/{id}", async (int VideoCardId, ThesisContext db) =>
        {
            if (await db.VideoCards.FindAsync(VideoCardId) is VideoCardEntity videoCard)
            {
                db.VideoCards.Remove(videoCard);
                await db.SaveChangesAsync();
                return Results.Ok(videoCard);
            }

            return Results.NotFound();
        })
        .WithName("DeleteVideoCard")
        .Produces<VideoCardEntity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
