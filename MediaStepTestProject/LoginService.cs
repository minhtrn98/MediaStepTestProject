using System.Security.Claims;

namespace MediaStepTestProject;

public class LoginService
{
    public LoginService(IHttpContextAccessor httpContextAccessor)
    {
        string? userId;
        if ((userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)) is null)
        {
            return;
        }
        UserId = int.Parse(userId);
    }

    public int UserId { get; }

}
