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

            var countsOfPhotosByType = itemPhotosByType.GroupBy(itemPhoto => itemPhoto).ToDictionary(itemPhoto => itemPhoto.Key, itemPhoto => itemPhoto.Count());

            IList<ItemPhoto> matched = new List<ItemPhoto>();

            foreach (ItemPhoto itemPhoto in itemPhotosByItem) {
                // The count.
                int count;

                // If the item is found in a.
                if (countsOfPhotosByType.TryGetValue(itemPhoto, out count)) {
                    // This is positive.
                    Debug.Assert(count > 0);

                    // Add the item to the list.
                    matched.Add(itemPhoto);

                    // Decrement the count.  If
                    // 0, remove.
                    if (--count == 0)
                        countsOfPhotosByType.Remove(itemPhoto);
                }
            }

            return Ok(_mapper.Map<IEnumerable<ItemPhotoDto>>(matched));
        }

    }
}
