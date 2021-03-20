using AutoMapper;
using BackendPhotoItemsApp.Dtos;
using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Profiles;
using BackendPhotoItemsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : Controller {

        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemsController(IRepository<Item> repository, IMapper mapper) {
            _itemRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetItems() {

            IEnumerable<Item> items = _itemRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id) {

            Item item = _itemRepository.Get(id);

            if (item == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ItemDto>(item));
        }

        [HttpPost]
        public ActionResult<Item> PostItem(Item item) {

            if (item == null) {
                return BadRequest();
            }

            ItemPostDto postedItem = _mapper.Map<ItemPostDto>(item);
            Item itemModel = _mapper.Map<Item>(postedItem);

            _itemRepository.Add(itemModel);
            _itemRepository.SaveChanges();

            var itemDto = _mapper.Map<ItemDto>(itemModel);

            return CreatedAtAction(nameof(GetItem), new { itemDto.Id }, itemDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ItemPostDto item) {

            Item existingItem = _itemRepository.Get(id);
            if (existingItem == null) {
                return NotFound();
            }

            _mapper.Map(item, existingItem);

            _itemRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id) {
            Item existingItem = _itemRepository.Get(id);

            if (existingItem == null) {
                return NotFound();
            }

            _itemRepository.Remove(existingItem);
            _itemRepository.SaveChanges();

            return NoContent();
        }
    }
}
