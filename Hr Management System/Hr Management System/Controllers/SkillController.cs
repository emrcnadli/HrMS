using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using AutoMapper;
using MediatR;
using Hr_Management_System.Features.Roles.Queries.GetAllQueries;
using Hr_Management_System.Features.Skills.Queries.GetAllSkills;
using Hr_Management_System.Features.Departments.Queries.GetDepartmentById;
using Hr_Management_System.Features.Skills.Queries.GetSkillById;
using Hr_Management_System.Models.Skill;
using Hr_Management_System.Features.Departments.Command.CreateDepartment;
using Hr_Management_System.Features.Skills.Command.CreateSkill;
using Hr_Management_System.Features.Departments.Command;
using Hr_Management_System.Features.Roles.Command.EditRole;
using Hr_Management_System.Features.Skills.Command.EditSkill;
using Hr_Management_System.Features.Departments.Command.DeleteDepartment;
using Hr_Management_System.Features.Skills.Command.DeleteSkill;

namespace Hr_Management_System.Controllers
{
    public class SkillController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SkillController(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Skill
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Skills.ToListAsync());
            var response = await _mediator.Send(new GetAllSkillsQueryRequest());

            return View(response);
        }

        // GET: Skill/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetSkillByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Skill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSkillViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<CreateSkillCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Skill/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetSkillByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // POST: Skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditSkillViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<EditSkillCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Skill/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetSkillByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var skill = await _mediator.Send(new GetSkillByIdQueryRequest() { Id = id });
            if (skill != null)
            {
                _mediator.Send(new DeleteSkillCommand() { Skill = skill });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
