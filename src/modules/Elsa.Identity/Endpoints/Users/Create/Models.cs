namespace Elsa.Identity.Endpoints.Users.Create;

internal class Request
{
    public string Name { get; set; } = default!;
    public string? Password { get; set; }
    public ICollection<string>? Roles { get; set; }
    public string? TenantId { get; set; }
}

internal record Response(
    string Id,
    string Name,
    string Password,
    ICollection<string> Roles,
    string? TenantId,
    string HashedPassword,
    string HashedPasswordSalt
);