using Mapster;
using MediaStepTestProject.Dtos;
using MediaStepTestProject.Entities;
using MediatR;

namespace MediaStepTestProject.Commands;

public class AddRangeProductCommand : IRequest
{
    public IEnumerable<ProductDto> ProductDtos { get; set; } = Enumerable.Empty<ProductDto>();

    public class Handler : IRequestHandler<AddRangeProductCommand>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddRangeProductCommand request, CancellationToken cancellationToken)
        {
            var productRangeToAdd = request.ProductDtos.Select(c => c.Adapt<Product>());

            await _context.Products.AddRangeAsync(productRangeToAdd, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

