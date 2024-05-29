using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Hr_Management_System.Models.Person;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Features.Person.Queries.GetAllPersons;
using AutoMapper;
using MediatR;
using Hr_Management_System.Features.Person.Queries.GetPersonById;
using Hr_Management_System.Features.Person.Coımmand;

namespace Hr_Management_System.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PersonController(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Persons.Include(x => x.PersonProjects).ThenInclude(a => a.Project).Include(p => p.PersonSkills).ThenInclude(p=>p.Skill).Include(x=>x.Department).Include(r=>r.Role).ToListAsync());
            var response = await _mediator.Send(new GetAllPersonsQueryRequest());
            return View(response);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _mediator.Send(new GetPersonByIdQueryRequest() { Id = id });
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Department = new SelectList(_context.Departments, "Id", "Name");
            ViewBag.Project = new SelectList(_context.Projects, "Id", "Name");
            ViewBag.Skill = new SelectList(_context.Skills, "Id", "Name");
            ViewBag.Role = new SelectList(_context.Roles,"Id", "Name");

            ViewBag.Title = "Create";
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonViewModel viewModel)
        {
            

            /*
                Person person = new Person()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DepartmentId = viewModel.DepartmentId,
                    RoleId = viewModel.RoleId,
                    Payment = viewModel.Payment,
                    BirthDay = viewModel.BirthDay,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone
                };
            */
            /*
                foreach (var item in viewModel.ProjectId)
                {
                    person.PersonProjects.Add(new PersonProject()
                    {
                        Person = person,
                        ProjectID = item
                    }); 
                }
                foreach (var item in viewModel.SkillId)
                {
                    person.PersonSkills.Add(new PersonSkill()
                    {
                        Person = person,
                        SkillID = item
                    });
                }
            */
            var response = await _mediator.Send(_mapper.Map<CreatePersonCommand>(viewModel));
                /*
                _context.Persons.Add(person);
                _context.SaveChanges();
            */

            return View(Index);
        }
        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.Persons.
                Include(p => p.PersonProjects).
                ThenInclude(p => p.Project).
                Include(p => p.PersonSkills).
                ThenInclude(p => p.Skill).Include(p=>p.Department).Include(p=>p.Role).FirstOrDefault(p=>p.Id == id);
            
            var departments = _context.Departments.ToList();
            var roles = _context.Roles.ToList();
            var skills = _context.Skills.ToList();
            var projects = _context.Projects.ToList();
            
            var selected_skill = person.PersonSkills.Select(s => s.SkillID).ToList();
            var selected_project = person.PersonProjects.Select(s => s.ProjectID).ToList();

            List<SelectListItem> list_projects = new List<SelectListItem>();
            foreach (var item in projects)
            {
                bool isSelected = selected_project.Contains(item.Id);
                list_projects.Add(new SelectListItem(item.Name, item.Id.ToString(), isSelected));
            }
            ViewBag.Projects_selected = list_projects;

            List<SelectListItem> list_departments = new List<SelectListItem>();

            foreach (var item in departments)
            {
                bool isSelected = person.Department.Name.Equals(item.Name);
                list_departments.Add(new SelectListItem(item.Name, item.Id.ToString(), isSelected));
            }
            ViewBag.Departments_selected = list_departments;

            List<SelectListItem> list_roles = new List<SelectListItem>();

            foreach (var item in roles)
            {
                bool isSelected = person.Role.Name.Equals(item.Name);
                list_roles.Add(new SelectListItem(item.Name, item.Id.ToString(), isSelected));
            }
            ViewBag.Roles_selected = list_roles;
            
            List<SelectListItem> list_skills = new List<SelectListItem>();

            foreach (var item in skills)
            {
                bool isSelected = selected_skill.Contains(item.Id);
                list_skills.Add(new SelectListItem(item.Name, item.Id.ToString(), isSelected));
            }
            ViewBag.Skills_selected = list_skills;
            EditPersonViewModel model = new Models.Person.EditPersonViewModel() {
                Person = person,
                Department = person.Department,
                Role = person.Role,
                Skills = skills,
                Projects = projects,
            };
            if (person == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Payment,BirthDay,Email,Phone")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
