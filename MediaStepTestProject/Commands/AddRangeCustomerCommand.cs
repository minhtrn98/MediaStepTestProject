using Mapster;
using MediaStepTestProject.Dtos;
using MediaStepTestProject.Entities;
using MediatR;

namespace MediaStepTestProject.Commands;

public class AddRangeCustomerCommand : IRequest
{
    public IEnumerable<CustomerDto> CustomerDtos { get; set; } = Enumerable.Empty<CustomerDto>();

    public class Handler : IRequestHandler<AddRangeCustomerCommand>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddRangeCustomerCommand request, CancellationToken cancellationToken)
        {
            // check any email exists



            var customerRangeToAdd = request.CustomerDtos.Select(c => c.Adapt<Customer>());

            await _context.Customers.AddRangeAsync(customerRangeToAdd, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

