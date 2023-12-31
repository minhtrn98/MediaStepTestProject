﻿using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Commands;

public class BuyProductCommand : IRequest
{
    public int ProductId { get; set; }

    public class Handler : IRequestHandler<BuyProductCommand>
    {
        private readonly AppDbContext _context;
        private readonly LoginService _loginService;

        public Handler(AppDbContext context, LoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }

        public async Task Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            bool isProductExists = await _context.Products.AnyAsync(p => p.Id == request.ProductId, cancellationToken);
            if (!isProductExists)
            {
                throw new Exception("Product not found!");
            }

            var cusBuyProd = await _context.CustomerProducts
                .FirstOrDefaultAsync(cp => cp.CustomerId == _loginService.UserId
                    && cp.ProductId == request.ProductId
                , cancellationToken);

            if (cusBuyProd != null)
            {
                cusBuyProd.Quantity++;
                await _context.SaveChangesAsync(cancellationToken);
                return;
            }

            await _context.CustomerProducts.AddAsync(new Entities.CustomerProduct
            {
                CustomerId = _loginService.UserId,
                ProductId = request.ProductId,
                Quantity = 1
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
