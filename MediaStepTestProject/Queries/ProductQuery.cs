using MediaStepTestProject.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Queries;

public class ProductQuery : IRequest<IEnumerable<ProductQueryResponse>>
{
    public int? ShopId { get; set; }
    public string? SearchStr { get; set; }

    public class Handler : IRequestHandler<ProductQuery, IEnumerable<ProductQueryResponse>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductQueryResponse>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(c => request.ShopId == null || c.ShopId == request.ShopId)
                .Where(c => request.SearchStr == null || c.Name.Contains(request.SearchStr))
                .AsNoTracking()
                .OrderBy(s => s.Price)
                .Select(p => new ProductQueryResponse()
                {
                    Id = p.Id,
                    ShopId = p.ShopId,
                    Name = p.Name,
                    Price = p.Price,
                    ShopName = p.Shop.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}

public class ProductQueryResponse : ProductDto
{
    public string ShopName { get; set; } = string.Empty;
}
