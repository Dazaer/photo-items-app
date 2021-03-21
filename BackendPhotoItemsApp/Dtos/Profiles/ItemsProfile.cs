using AutoMapper;
using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Profiles {
    public class ItemsProfile : Profile {
        public ItemsProfile() {
            CreateMap<Item, ItemDto>();
            //CreateMap<ItemPostDto, Item>();
            CreateMap<Item, ItemPostDto>().ReverseMap();
        }
    }
}
