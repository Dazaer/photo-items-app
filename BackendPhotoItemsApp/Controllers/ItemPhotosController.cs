using AutoMapper;
using BackendPhotoItemsApp.Dtos;
using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult GetAllItemPhotos() {

            IQueryable<ItemPhoto> itemPhotos = _itemPhotoRepository.GetAllWithProperties();
            return Ok(_mapper.Map<IEnumerable<ItemPhotoDto>>(itemPhotos));
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult GetItemPhoto(int id) {

            ItemPhoto itemPhoto = _itemPhotoRepository.Get(id);
            return Ok(_mapper.Map<ItemPhotoDto>(itemPhoto));
        }

        [Route("type")]
        [HttpGet]
        public ActionResult GetItemPhotosByType([FromQuery] int typeId) {

            IQueryable<ItemPhoto> itemPhotos = _itemPhotoRepository.GetAllByType(typeId);
            return Ok(_mapper.Map<IEnumerable<ItemPhotoDto>>(itemPhotos));
        }

        [Route("type-and-item")]
        [HttpGet]
        public ActionResult GetItemPhotosByTypeAndItem([FromQuery] int typeId, [FromQuery] int itemId) {

            IEnumerable<ItemPhoto> itemPhotosByType = _itemPhotoRepository.GetAllByType(typeId);
            IEnumerable<ItemPhoto> itemPhotosByItem = _itemPhotoRepository.GetAllByItem(itemId);

            var intersection = itemPhotosByType.Intersect(itemPhotosByItem);

            return Ok(_mapper.Map<IEnumerable<ItemPhotoDto>>(intersection));
        }

        [Route("{id}/property")]
        [HttpGet]
        public ActionResult GetItemPhotosByProperties([FromQuery] string metalValue, [FromQuery] string shapeValue) {
            IQueryable<ItemPhoto> itemPhotosByMetal = _itemPhotoRepository.GetAllByMetalType(metalValue);
            IQueryable<ItemPhoto> itemPhotosByShape = _itemPhotoRepository.GetAllByShape(shapeValue);

            var intersection = itemPhotosByMetal.Intersect(itemPhotosByShape);

            return Ok(intersection);
        }

        [HttpPost]
        public ActionResult<ItemPhotoDto> PostItemPhoto(ItemPhoto itemPhoto) {

            if (itemPhoto == null) {
                return BadRequest();
            }

            ItemPhotoPostDto postedItemPhoto = _mapper.Map<ItemPhotoPostDto>(itemPhoto);
            ItemPhoto itemPhotoModel = _mapper.Map<ItemPhoto>(postedItemPhoto);

            _itemPhotoRepository.Add(itemPhotoModel);
            _itemPhotoRepository.SaveChanges();

            var itemPhotoDto = _mapper.Map<ItemPhotoDto>(itemPhotoModel);
            return CreatedAtAction(nameof(GetItemPhoto), new { itemPhotoDto.Id }, itemPhotoDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItemPhoto(int id) {
            ItemPhoto existingItemPhoto = _itemPhotoRepository.Get(id);

            if (existingItemPhoto == null) {
                return NotFound();
            }

            _itemPhotoRepository.Remove(existingItemPhoto);
            _itemPhotoRepository.SaveChanges();

            return NoContent();
        }

    }
}
