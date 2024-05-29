using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using AutoMapper;
using MediatR;
using Hr_Management_System.Features.Projects.Queries.GetAllProjects;
using Hr_Management_System.Features.Roles.Queries.GetAllQueries;
using Hr_Management_System.Features.Departments.Queries.GetDepartmentById;
using Hr_Management_System.Features.Roles.Queries.GetRoleById;
using Hr_Management_System.Models.Role;
using Hr_Management_System.Features.Departments.Command.CreateDepartment;
using Hr_Management_System.Features.Roles.Command.CreateRole;
using Hr_Management_System.Features.Departments.Command;
using Hr_Management_System.Features.Roles.Command.EditRole;
using Hr_Management_System.Features.Departments.Command.DeleteDepartment;
using Hr_Management_System.Features.Roles.Command.DeleteRole;

namespace Hr_Management_System.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RoleController(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Roles.ToListAsync());
            var response = await _mediator.Send(new GetAllRolesQueryRequest());

            return View(response);
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetRoleByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<CreateRoleCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetRoleByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditRoleViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<EditRoleCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetRoleByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var role = await _mediator.Send(new GetRoleByIdQueryRequest() { Id = id });
            if (role != null)
            {
                _mediator.Send(new DeleteRoleCommnand() { Role = role });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
