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
    public class ItemPhotoPropertySetsController : Controller{
        private readonly IRepository<ItemPhotoPropertySet> _itemPhotoPropertySetRepository;
        private readonly IMapper _mapper;

        public ItemPhotoPropertySetsController(IRepository<ItemPhotoPropertySet> repository, IMapper mapper) {
            _itemPhotoPropertySetRepository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id) {

            ItemPhotoPropertySet set = _itemPhotoPropertySetRepository.Get(id);

            if (set == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ItemPhotoPropertySetDto>(set));
        }

        [HttpPost]
        public ActionResult<ItemPhotoPropertySetDto> PostItem(ItemPhotoPropertySet set) {

            if (set == null) {
                return BadRequest();
            }

            ItemPhotoPropertySetPostDto postedSet = _mapper.Map<ItemPhotoPropertySetPostDto>(set);
            ItemPhotoPropertySet setModel = _mapper.Map<ItemPhotoPropertySet>(postedSet);

            _itemPhotoPropertySetRepository.Add(setModel);
            _itemPhotoPropertySetRepository.SaveChanges();

            var setDto = _mapper.Map<ItemPhotoPropertySet>(setModel);

            return CreatedAtAction(nameof(GetItem), new { setDto.Id }, setDto);
        }
    }
}
