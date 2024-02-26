using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseRatingAndReviewModel : BaseEntityModel
{
    public string? Subject { get; set; } = string.Empty;
    public string? Comment { get; set; } = string.Empty;
    public double? Rating { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}
