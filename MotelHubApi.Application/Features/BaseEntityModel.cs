using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseEntityModel
{
    public int Id { get; set; }
    public ICollection<ValidationError> ValidationErrors { get; set; } = new HashSet<ValidationError>();
}
