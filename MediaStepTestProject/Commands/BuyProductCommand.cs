using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Commands;

public class BuyProductCommand : IRequest
{
    public int ProductId { get; set; }

    public class Handler : IRequestHandler<BuyProductCommand>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            bool isProductExists = await _context.Products.AnyAsync(p => p.Id == request.ProductId, cancellationToken);
            if (!isProductExists)
            {
                throw new Exception("Product not found!");
            }

            await _context.CustomerProducts.AddAsync(new Entities.CustomerProduct
            {
                CustomerId = 1,
                ProductId = request.ProductId
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
