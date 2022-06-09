
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Services.Interfaces;
using Task9ASPNetCore.ViewModels;

namespace Task9ASPNetCore.Controllers
{
    public class CourseController : Controller
    {
        private readonly IServices<CourseDTO> _service;
        private readonly IMapper _mapper;

        public CourseController(IServices<CourseDTO> services, IMapper mapper) 
        { 
            _service = services;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View(_mapper.Map<IEnumerable<CourseViewModel>>(await _service.GetAllAsync(id)));
        }

        public IActionResult Create()
        { 
            return View(new CourseViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
            
               await _service.CreateAsync(_mapper.Map<CourseDTO>(model));

               return RedirectToAction("Index", "Course");

            }
            return View(model);
        }

        public  async Task<IActionResult> Edit(int id)
        {
            return View(_mapper.Map<CourseViewModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseViewModel model) 
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<CourseDTO>(model));

                return RedirectToAction("Index","Course");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
           await _service.DeleteAsync(id);

           return RedirectToAction("Index", "Course");
        }

    }
}