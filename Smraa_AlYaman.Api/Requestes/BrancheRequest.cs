using Smraa_AlYaman.Application.Branches.Commands.CreateBranch;
using Smraa_AlYaman.Application.Branches.Commands.UpdateBranch;

namespace Smraa_AlYaman.Api.Requestes
{
    public class BrancheRequest
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public CreateBranchCommand ToCreateCommand()
        {
            return new CreateBranchCommand(Name, Address, Phone);
        }
        public UpdateBrancheCommand ToUpdateCommand(int id)
        {
            return new UpdateBrancheCommand(id, Name, Address, Phone);
        }
    }
}
