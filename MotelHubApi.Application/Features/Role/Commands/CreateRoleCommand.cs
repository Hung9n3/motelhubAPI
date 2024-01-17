using System;
using MediatR;

namespace MotelHubApi;

public class CreateRoleCommand : IRequest<Role>
{
	public string Name { get; set; } = string.Empty;
}

internal class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
    {
        this._unitOfWork = unitOfWork;
        this._roleRepository = roleRepository;
    }

    public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {

        Role role = new()
        {
            Name = request.Name,
            NormalizedName = request.Name.ToUpper(),
        };
        var result = await this._roleRepository.AddAsync(role);
        await this._unitOfWork.Save(cancellationToken);
        return result;
    }
}
