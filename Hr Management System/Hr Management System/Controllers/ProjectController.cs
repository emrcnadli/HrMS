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
using Hr_Management_System.Features.Projects.Queries.GetProjectById;
using Hr_Management_System.Models.Project;
using Hr_Management_System.Features.Projects.Command.CreateProject;
using Hr_Management_System.Features.Projects.Command.EditProject;
using Hr_Management_System.Features.Projects.Command.DeleteProject;

namespace Hr_Management_System.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjectController(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Projects.ToListAsync());
            var response = await _mediator.Send(new GetAllProjectsQueryRequest());

            return View(response);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var response = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            var response = await _mediator.Send(new GetProjectByIdQueryRequest() { Id = id });
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<CreateProjectCommand>(viewModel));
                //_context.Add(viewModel);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _mediator.Send(new GetProjectByIdQueryRequest()
            {
                Id = id
            });
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditProjectViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(_mapper.Map<EditProjectCommand>(viewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _mediator.Send(new GetProjectByIdQueryRequest() { Id=id});
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var project = await _mediator.Send(new GetProjectByIdQueryRequest(){Id = id });
            if (project != null)
            {
                _mediator.Send(new DeleteProjectCommand(){ Project = project});
            
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
