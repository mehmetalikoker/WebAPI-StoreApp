using AutoMapper;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Mappings
{
    public class RequestMessagesToEntities
    {
        public static void Map(AutoMapper.IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.CreateMap<UserCreateRequest, User>();
        }
    }
}
