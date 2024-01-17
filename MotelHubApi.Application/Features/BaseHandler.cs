using System;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public abstract class BaseHandler<TEntity, TCommand, TRepository, TResult> : IRequestHandler<TCommand, TResult>
	where TCommand : IRequest<TResult>
	where TEntity : class, IEntity
	where TRepository : IBaseRepository<TEntity>
{
	protected readonly IUnitOfWork _unitOfWork; 
	protected readonly TRepository _repository;
	protected readonly IMapper _mapper;

    public BaseHandler(IUnitOfWork unitOfWork, TRepository repository, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_repository = repository;
		_mapper = mapper;
	}

	public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
}

