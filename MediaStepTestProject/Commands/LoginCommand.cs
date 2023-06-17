using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediaStepTestProject.Commands;

public class LoginCommand : IRequest<string>
{
    public string Email { get; set; } = null!;

    public class Handler : IRequestHandler<LoginCommand, string>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra tính hợp lệ của địa chỉ email và xác định vai trò
            if (request.Email.Equals("admin@mail.com", StringComparison.OrdinalIgnoreCase))
            {
                return GenerateJwtToken(request.Email, "admin");
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == request.Email, cancellationToken);

            if (customer is null)
            {
                throw new Exception("User not found!");
            }

            return GenerateJwtToken(request.Email, "customer", customer.Id);
        }

        private string GenerateJwtToken(string email, string role, int cusId = 0)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, cusId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(
                "FakeIssuer",
                "FakeAudience",
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
