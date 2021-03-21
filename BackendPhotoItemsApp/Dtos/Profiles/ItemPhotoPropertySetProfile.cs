using AutoMapper;
using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos.Profiles {
    public class ItemPhotoPropertySetProfile : Profile {
        public ItemPhotoPropertySetProfile() {
            CreateMap<ItemPhotoPropertySet, ItemPhotoPropertySetDto>();
            CreateMap<ItemPhotoPropertySet, ItemPhotoPropertySetPostDto>().ReverseMap();
        }
    }
}
