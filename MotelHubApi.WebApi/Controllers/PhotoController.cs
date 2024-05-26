using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class PhotoController : ApiControllerBase<Photo, IPhotoLogic>
{
    public PhotoController(IPhotoLogic logic) : base(logic)
    {
    }
}
