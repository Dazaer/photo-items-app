using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos.Profiles {
    public class TypeProfile : Profile {
        public TypeProfile() {
            CreateMap<Type, TypeDto>();
        }
    }
}
