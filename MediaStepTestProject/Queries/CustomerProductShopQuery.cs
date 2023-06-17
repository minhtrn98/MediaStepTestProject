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
            var query = from cus in _context.Customers
                        join cp in _context.CustomerProducts on cus.Id equals cp.CustomerId
                        join pro in _context.Products on cp.ProductId equals pro.Id
                        join shp in _context.Shops on pro.ShopId equals shp.Id
                        orderby cus.FullName, shp.Location descending, pro.Price descending
                        select new CustomerProductShopQueryResponse()
                        {
                            CustomerName = cus.FullName,
                            CustomerEmail = cus.Email,
                            ProductName = pro.Name,
                            ProductPrice = pro.Price,
                            ShopName = shp.Name,
                            ShopLocation = shp.Location
                        };

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
