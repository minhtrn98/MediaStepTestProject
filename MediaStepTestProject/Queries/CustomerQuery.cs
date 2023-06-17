using Mapster;
using MediaStepTestProject.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject.Queries;

public class CustomerQuery : IRequest<IEnumerable<CustomerDto>>
{
    public class Handler : IRequestHandler<CustomerQuery, IEnumerable<CustomerDto>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .ProjectToType<CustomerDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
