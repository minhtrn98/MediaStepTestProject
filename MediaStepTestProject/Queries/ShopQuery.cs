using Mapster;
using MediaStepTestProject.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Queries;

public class ShopQuery : IRequest<IEnumerable<ShopDto>>
{
    public class Handler : IRequestHandler<ShopQuery, IEnumerable<ShopDto>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShopDto>> Handle(ShopQuery request, CancellationToken cancellationToken)
        {
            return await _context.Shops
                .AsNoTracking()
                .OrderBy(c => c.Location)
                .ProjectToType<ShopDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
