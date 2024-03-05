using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseEntityModel : IEntity
{
    public int Id { get; set; }
    public ICollection<ValidationError> ValidationErrors { get; set; } = new HashSet<ValidationError>();
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }
}
