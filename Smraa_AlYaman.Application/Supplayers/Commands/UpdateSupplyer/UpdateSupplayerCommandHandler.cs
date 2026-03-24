using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.UpdateSupplyer
{
    public class UpdateSupplayerCommandHandler(
        ISupplayerRepository _supplierRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateSupplayerCommand, ResultOf<Supplayer>>
    {

        public async Task<ResultOf<Supplayer>> Handle(UpdateSupplayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = await _supplierRepository.GetByIdAsync(request.Id);
                if (supplier is null)
                {
                    return Error.NotFound(
                        code: "Supplier.NotFound",
                        description: $"Supplier with Id {request.Id} was not found."
                    );
                }
                supplier.Update(
                    name: request.Name,
                    phone: request.Phone,
                    scope:(SupplayerScope?)request.Scope
                    );

                await _unitOfWork.SaveChangesAsync();
                return supplier.AsDone();
            }
            catch(DomainException ex)
            {
                return Error.Failure(
                    code: ex.Code,
                    description: ex.Message
                );
            }
            catch(Exception ex)
            {
                return Error.Failure(
                    code: "UpdateSupplayerCommandHandler.Handle_Failure",
                    description: ex.Message
                );
            }

        }
    }
}
