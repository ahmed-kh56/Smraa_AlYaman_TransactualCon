using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smraa_AlYaman.Application.Supplayers.Commands.DeleteSupplayer;

public record DeleteSupplayerCommand(int SupplayerId):IRequest<ResultOf<Done>>;
