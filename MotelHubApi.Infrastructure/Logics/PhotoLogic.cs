namespace MotelHubApi.Infrastructure;

public class PhotoLogic : BaseLogic<Photo, IPhotoRepository>, IPhotoLogic
{
    public PhotoLogic(IPhotoRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
