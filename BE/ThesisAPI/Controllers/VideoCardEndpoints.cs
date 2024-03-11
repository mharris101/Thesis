﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        routes.MapGet("/api/VideoCards", async ([FromQuery] int? page, [FromQuery] int? pageSize, ThesisContext db) =>
        {
            page ??= 1;
            pageSize ??= 10;
            var skip = (page.Value - 1) * pageSize.Value;

            var entities = await db.VideoCards.Skip(skip).Take(pageSize.Value).ToListAsync();

            return entities.ToDto();
        })
        .WithName("GetAllVideoCards")
        .Produces<List<VideoCard>>(StatusCodes.Status200OK);

        // GET Single
        routes.MapGet("/api/VideoCards/{id}", async (int id, ThesisContext db) =>
        {
            return await db.VideoCards.FindAsync(id)
                is VideoCardEntity model
                    ? Results.Ok(model.ToDto())
                    : Results.NotFound();
        })
        .WithName("GetVideoCardById")
        .Produces<VideoCard>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // PUT
        routes.MapPut("/api/VideoCards/{id}", async (int id, VideoCard videoCard, ThesisContext db) =>
        {
            var videoCardEntity = await db.VideoCards.FindAsync(id);

            if (videoCardEntity is null)
            {
                return Results.NotFound();
            }

            videoCardEntity.VideoCardDesc = videoCard.VideoCardDesc;

            db.Update(videoCardEntity);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateVideoCard")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        // POST
        routes.MapPost("/api/VideoCards/", async (VideoCard videoCard, ThesisContext db) =>
        {
            var entity = videoCard.ToEntity();
            db.VideoCards.Add(entity);
            await db.SaveChangesAsync();
            return Results.Created($"/VideoCards/{videoCard.VideoCardId}", entity.ToDto());
        })
        .WithName("CreateVideoCard")
        .Produces<VideoCard>(StatusCodes.Status201Created);

        // DELETE
        routes.MapDelete("/api/VideoCards/{id}", async (int id, ThesisContext db) =>
        {
            if (await db.VideoCards.FindAsync(id) is VideoCardEntity videoCard)
            {
                try
                {
                    db.VideoCards.Remove(videoCard);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException)
                {
                    if (ex.InnerException.Message.ToLower().Contains("reference constraint"))
                    {
                        return Results.Conflict(new { message = "Unable to delete. Its dependencies must first be deleted." });
                    }
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                return Results.NoContent();
            }

            return Results.NotFound();
        })
        .WithName("DeleteVideoCard")
        .Produces<VideoCardEntity>(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
