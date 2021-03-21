using AutoMapper;
using BackendPhotoItemsApp.Dtos;
using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackendPhotoItemsApp.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ItemPhotosController : Controller {

        private readonly IItemPhotoRepository _itemPhotoRepository;
        private readonly IMapper _mapper;

        public ItemPhotosController(IItemPhotoRepository repository, IMapper mapper) {
            _itemPhotoRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetItemPhotosByType([FromQuery] int typeId) {

            IEnumerable<ItemPhoto> itemPhotos = _itemPhotoRepository.GetAllByType(typeId);
            //return Ok(items);
            return Ok(_mapper.Map<IEnumerable<ItemPhotoDto>>(itemPhotos));
        }

    }
}
