using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Supplayers.Commands.DeleteSupplayer
{
    public class DeleteSupplayerCommandHandler(
        IUnitOfWork unitOfWork,
        ISupplayerRepository _supplayerRepository)
        : IRequestHandler<DeleteSupplayerCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(DeleteSupplayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplayer = await _supplayerRepository.GetByIdAsync(request.SupplayerId);

                if (supplayer is null)
                {
                    return Error.NotFound(
                        code: "DeleteSupplayerCommandHandler_SupplayerNotFound",
                        description: $"Supplayer with ID {request.SupplayerId} was not found.");
                }

                supplayer.MarkAsDeleted();

                await _supplayerRepository.UpdateAsync(supplayer);
                await unitOfWork.SaveChangesAsync();

                return Done.done.AsNoContent();

            }
            catch(Exception ex)
            {
                return Error.Failure(
                    description: ex.Message,
                    code: "DeleteSupplayerCommandHandler_Failure");
            }
        }
    }
}
