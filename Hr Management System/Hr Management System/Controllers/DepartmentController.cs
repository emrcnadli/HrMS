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
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Models.Department;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Hr_Management_System.Features.Departments.Queries.GetDepartmentById;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using Hr_Management_System.Features.Departments.Command.CreateDepartment;
using Hr_Management_System.Features.Departments.Command;
using Hr_Management_System.Features.Departments.Command.DeleteDepartment;

namespace Hr_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public DepartmentController(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllDepartmentsQueryRequest());
            
            return View(response);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetDepartmentByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDepartmentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(_mapper.Map<CreateDepartmentCommand>(viewModel));
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(viewModel);
            }
            
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //I need only Id of department, that's why I didn't use mapper
            var response = await _mediator.Send(new GetDepartmentByIdQueryRequest(){Id = id});
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditDepartmentViewModel viewModel)
        {

            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<EditDepartmentCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var department = await _mediator.Send(new GetDepartmentByIdQueryRequest() { Id = id });
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var department = await _mediator.Send(new GetDepartmentByIdQueryRequest() { Id = id });
            if (department != null)
            {
                _mediator.Send(new DeleteDepartmentCommand() { Department=department });
                //_context.Departments.Remove(department);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(Guid id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
