using Microsoft.AspNetCore.Mvc;
using Task9ASPNetCore.ViewModels;
using AutoMapper;
using Task9ASPNetCore.Services.Interfaces;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;

namespace Task9ASPNetCore.Controllers
{
    public class GroupController : Controller
    {
        private readonly IServices<GroupDTO> _service;
        private readonly IMapper _mapper;
        private readonly IGroupDeleteCheck _groupDeleteCheck;


        public GroupController(IServices<GroupDTO> services, IMapper mapper, IGroupDeleteCheck groupDeleteCheck)
        {
            _service = services;
            _mapper = mapper;
            _groupDeleteCheck = groupDeleteCheck;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.CourseID = id;

            return View(_mapper.Map<IEnumerable<GroupViewModel>>(await _service.GetAllAsync(id)));
        }
        public IActionResult Create(int courseId)
        {
            return View(new GroupViewModel() { CourseId = courseId });

        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupViewModel model, int courseId)
        {
            ViewBag.CourseID = courseId;

            if (ModelState.IsValid)
            {
                await _service.CreateAsync(_mapper.Map<GroupDTO>(model));

                return RedirectToAction("Index", new { Id = courseId });
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(_mapper.Map<GroupViewModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GroupViewModel model)
        {

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<GroupDTO>(model));

                return RedirectToAction("Index", new { Id = model.CourseId });
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteAsync(int id, int courseId)
        {
            if (await _groupDeleteCheck.GroupDeleteCheck(id))
            {
                await _service.DeleteAsync(id);
            }
            else
            {
                return RedirectToAction("GroupDeleteEror", new { CourseId = courseId });
            }
            return RedirectToAction("Index", new { Id = courseId });
        }

        public IActionResult GroupDeleteEror(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }
    }
}
