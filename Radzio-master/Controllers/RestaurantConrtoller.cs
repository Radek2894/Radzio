using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radzio.Entites;
using Radzio.Models;
using Radzio.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Radzio.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantConrtoller : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        
        public RestaurantConrtoller(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _restaurantService.Update(id, dto);
            if(!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantService.Delete(id);
            
            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
                
        }

        [HttpGet] 
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
        
            var restaurantsDtos = _restaurantService.GetAll();
          
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

           
            return Ok(restaurant);
        }
    }
}
