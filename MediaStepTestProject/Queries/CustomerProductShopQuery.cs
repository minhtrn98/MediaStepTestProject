using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Queries;

public class CustomerProductShopQuery : IRequest<IEnumerable<CustomerProductShopQueryResponse>>
{
    public class Handler : IRequestHandler<CustomerProductShopQuery, IEnumerable<CustomerProductShopQueryResponse>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerProductShopQueryResponse>> Handle(
            CustomerProductShopQuery request, CancellationToken cancellationToken)
        {
            // check 30 cust
            if (await _context.Shops.CountAsync(cancellationToken) < 3
                || await _context.Customers.CountAsync(cancellationToken) < 30
                || await _context.Products.CountAsync(cancellationToken) < 3003)
                return Enumerable.Empty<CustomerProductShopQueryResponse>();


            var query = _context.Customers
                    .Join(_context.CustomerProducts, cus => cus.Id, cp => cp.CustomerId, (cus, cp) => new { cus, cp })
                    .Join(_context.Products, temp => temp.cp.ProductId, pro => pro.Id, (temp, pro) => new { temp.cus, temp.cp, pro })
                    .Join(_context.Shops, temp => temp.pro.ShopId, shp => shp.Id, (temp, shp) => new { temp.cus, temp.cp, temp.pro, shp })
                    .OrderBy(x => x.cus.FullName)
                    .ThenByDescending(x => x.shp.Location)
                    .ThenByDescending(x => x.pro.Price)
                    .Select(x => new CustomerProductShopQueryResponse()
                    {
                        CustomerName = x.cus.FullName,
                        CustomerEmail = x.cus.Email,
                        ProductName = x.pro.Name,
                        ProductPrice = x.pro.Price,
                        ShopName = x.shp.Name,
                        ShopLocation = x.shp.Location
                    });

            return await query.ToListAsync(cancellationToken);
        }
    }
}

public class CustomerProductShopQueryResponse
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string ShopName { get; set; } = string.Empty;
    public string? ShopLocation { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
}
