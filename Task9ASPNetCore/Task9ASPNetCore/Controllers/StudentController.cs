using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Services.Interfaces;
using Task9ASPNetCore.ViewModels;

namespace Task9ASPNetCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly IServices<StudentDTO> _service;
        private readonly IMapper _mapper;

        public StudentController(IServices<StudentDTO> services, IMapper mapper)
        {
            _service = services;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(int id, int courseId)
        {
            ViewBag.CourseId = courseId;
            ViewBag.GroupId = id;

            return View(_mapper.Map<IEnumerable<StudentViewModel>>(await _service.GetAllAsync(id)));
        }

        public IActionResult Create(int groupId, int courseId)
        {
            ViewBag.CourseId = courseId;

            return View(new StudentViewModel() { GroupId = groupId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model, int CourseId, int groupId)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(_mapper.Map<StudentDTO>(model));

                return RedirectToAction("Index", new { Id = groupId, courseId = CourseId });
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id, int groupId, int CourseId)
        {
            return View(_mapper.Map<StudentViewModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model, int CourseId, int groupId)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<StudentDTO>(model));

                return RedirectToAction("Index", new { Id = model.GroupId, courseId = CourseId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id, int groupId, int CourseId)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction("Index", new { id = groupId, courseId = CourseId });
        }

    }
}
