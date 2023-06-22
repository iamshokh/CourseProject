using CourseProject.BizLogicLayer.CollectionServices;
using CourseProject.Core.Helpers;
using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.Repositories.Collection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionsService _service;
        public CollectionsController(ICollectionsService servise)
        {
            _service = servise;
        }

        [HttpGet]
        public IQueryable<Collections> GetAll()
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
        public IActionResult Create(CollectionsDlDto dto)
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
        public IActionResult Update(CollectionsDlDto dto)
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
