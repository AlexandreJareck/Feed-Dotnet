﻿using Feed.Business.Interfaces;
using System.Security.Claims;

namespace Feed.Api.Extensions;

public class AspNetUser : IUser
{
    private readonly IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor?.HttpContext?.User?.Identity?.Name!;

    public Guid GetUserId()
    {
        return IsAuthenticated() ? Guid.Parse(_accessor?.HttpContext?.User?.GetUserId()!) : Guid.NewGuid();
    }

    public string GetUserEmail()
    {
        return IsAuthenticated() ? _accessor?.HttpContext?.User?.GetUserEmail()! : "";
    }

    public IEnumerable<Claim> GetClaimsIdentity()
    {
        return _accessor?.HttpContext?.User?.Claims!;
    }

    public bool IsAuthenticated()
    {
        return _accessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }

    public bool IsInRole(string role)
    {
        return _accessor?.HttpContext?.User?.IsInRole(role) ?? false;
    }
}

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
        return claim?.Value!;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if(principal == null)
            throw new ArgumentNullException(nameof(principal));

        var claim = principal.FindFirst(ClaimTypes.Email);
        return claim?.Value!;
    }
}
