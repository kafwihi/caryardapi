using CarYardApi.Models;
using CarYardApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarYardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _bookService;

        public CarsController(CarService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get() =>
            _bookService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCar")]
        public ActionResult<Car> Get(string id)
        {
            var car = _bookService.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        public ActionResult<Car> Create(Car book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetCar", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Car bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}