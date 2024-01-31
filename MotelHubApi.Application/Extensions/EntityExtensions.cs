using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public static class EntityExtensions
{
    public static (List<T>, List<int>) UpdateRelated<T, DTO>(this List<T> entities, List<DTO> dtos, IMapper _mapper) 
        where T : IEntity
        where DTO : BaseEntityModel
    {
        var dtoIds = dtos.Select(d => d.Id).ToList();
        var news = _mapper.Map<List<T>>(
                dtos.Where(x => !entities.Select(y => y.Id).Contains(x.Id)).ToList()
                );
        var deletedIds = entities.Where(x => !dtoIds.Contains(x.Id)).Select(x => x.Id).ToList();
        entities.AddRange(news);
        entities.RemoveAll(x => deletedIds.Contains(x.Id));
        return (news, deletedIds);
    }
}
