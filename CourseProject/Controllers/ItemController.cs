using CourseProject.BizLogicLayer.ItemServices;
using CourseProject.Core.Helpers;
using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.Repositories.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        public ItemController(IItemService servise)
        {
            _service = servise;
        }

        [HttpGet]
        public IQueryable<Item> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _service.GetById(id);
                if (_service.IsValid)
                    return Ok(result);
                _service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult Create(ItemDlDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                if (_service.IsValid)
                    return Ok();
                _service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult Update(ItemDlDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(dto);
                if (_service.IsValid)
                    return Ok();
                _service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(id);
                if (_service.IsValid)
                    return Ok();
                _service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
