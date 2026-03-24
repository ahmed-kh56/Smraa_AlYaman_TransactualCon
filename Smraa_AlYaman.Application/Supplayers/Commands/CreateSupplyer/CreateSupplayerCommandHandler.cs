using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.CreateSupplyer
{
    public class CreateSupplayerCommandHandler(
        ISupplayerRepository _supplierRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateSupplayerCommand, ResultOf<Supplayer>>
    {

        public async Task<ResultOf<Supplayer>> Handle(CreateSupplayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = new Supplayer(request.Name, request.Phone, (SupplayerScope)request.Scope);
                await _supplierRepository.AddAsync(supplier);
                await _unitOfWork.SaveChangesAsync();
                return supplier.AsCreated();
            }
            catch
            {
                return Error.Failure(
                    code: "Supplier.CreationFailed",
                    description: "Failed to create supplier."
                );
            }

        }
    }
}
