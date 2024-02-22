using FilesCollab.Web.Dependencies.SqlServer.Application;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static FilesCollab.Web.Features.UserManagement.Users.ListUsersResponse;

namespace FilesCollab.Web.Features.UserManagement.Users;

internal static class ListUsers
{
    public static IEndpointRouteBuilder MapListUsersEndpoint(this IEndpointRouteBuilder builder, string uriPath)
    {
        builder.MapGet(uriPath, async Task<Ok<ListUsersResponse>> (
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? username,
            ApplicationContext applicationContext,
            CancellationToken cancellationToken) =>
        {
            var query = applicationContext.User.AsQueryable().AsNoTracking();

            if (string.IsNullOrWhiteSpace(username) is false)
            {
                var trimmedUsername = username.Trim();
                query = query.Where(user => user.Username.Contains(trimmedUsername));
            }

            var users = await query
                .Select(user => new { user.Id, user.Username, TotalItemsCount = query.Count() })
                .Take(pageSize)
                .Skip((pageNumber - 1) * pageSize)
                .OrderBy(user => user.Username)
                .ToArrayAsync(cancellationToken);

            return TypedResults.Ok(new ListUsersResponse
            {
                Users = users.Select(user => new ListUsersResponseUser
                {
                    Id = user.Id,
                    Username = user.Username
                }).ToArray(),
                PageContext = new()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItemsCount = users.FirstOrDefault()?.TotalItemsCount ?? 0
                }
            });
        });

        return builder;
    }
}

internal sealed record ListUsersResponse
{
    public required IReadOnlyCollection<ListUsersResponseUser> Users { get; init; }

    public required ListUsersResponsePageContext PageContext { get; init; }

    public sealed record ListUsersResponseUser
    {
        public required Guid Id { get; init; }

        public required string Username { get; init; }
    }

    public sealed record ListUsersResponsePageContext
    {
        public required int PageNumber { get; init; }

        public required int PageSize { get; init; }

        public required int TotalItemsCount { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NextPageNumber => PageNumber switch
        {
            _ when TotalPagesCount == 0 => null,
            _ when PageNumber > TotalPagesCount => throw new InvalidOperationException("Page number must not be greater than total pages count."),
            _ when PageNumber == TotalPagesCount => null,
            _ => PageNumber + 1
        };

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PreviousPageNumber => PageNumber switch
        {
            < 1 => throw new InvalidOperationException("Page number has to be greater than 0."),
            1 => null,
            _ => PageNumber - 1
        };

        public int TotalPagesCount =>
            TotalItemsCount % PageSize == 0 ?
                TotalItemsCount / PageSize :
                TotalItemsCount / PageSize + 1;
    }
}