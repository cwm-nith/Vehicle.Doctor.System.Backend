using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands.CommandHandlers;

public class DeleteGarageCommandHandler : IRequestHandler<DeleteGarageCommand, bool>
{
    private readonly IGarageRepository _repository;

    public DeleteGarageCommandHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteGarageCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id, request.UserId, cancellationToken);
    }
}