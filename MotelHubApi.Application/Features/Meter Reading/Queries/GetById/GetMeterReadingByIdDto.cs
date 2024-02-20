using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetMeterReadingByIdDto : BaseMeterReadingModel
{
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
}
