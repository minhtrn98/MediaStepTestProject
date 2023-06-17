using Mapster;
using MediaStepTestProject.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Queries;

public class ProductQuery : IRequest<IEnumerable<ProductDto>>
{
    public int? ShopId { get; set; }
    public string? SearchStr { get; set; }

    public class Handler : IRequestHandler<ProductQuery, IEnumerable<ProductDto>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(c => request.ShopId == null || c.ShopId == request.ShopId)
                .Where(c => request.SearchStr == null || c.Name.Contains(request.SearchStr))
                .AsNoTracking()
                .ProjectToType<ProductDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
