using Mapster;
using MediaStepTestProject.Dtos;
using MediaStepTestProject.Entities;
using MediatR;

namespace MediaStepTestProject.Commands;

public class AddRangeShopCommand : IRequest
{
    public IEnumerable<ShopDto> ShopDtos { get; set; } = Enumerable.Empty<ShopDto>();

    public class Handler : IRequestHandler<AddRangeShopCommand>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddRangeShopCommand request, CancellationToken cancellationToken)
        {
            var shopRangeToAdd = request.ShopDtos.Select(c => c.Adapt<Shop>());

            await _context.Shops.AddRangeAsync(shopRangeToAdd, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
