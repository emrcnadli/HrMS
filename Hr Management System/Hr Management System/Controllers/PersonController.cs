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
using Hr_Management_System.Models;

namespace Hr_Management_System.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PersonController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.Include(x=>x.PersonProjects).ThenInclude(a=>a.Project).Include(p=>p.PersonSkills).ThenInclude(p=>p.Skill).ToListAsync());
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

        // GET: Person/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Department = new SelectList(_context.Departments, "Id", "Name");
            var project_list = new SelectList(_context.Projects, "Id", "Name");
            var skill_list = new SelectList(_context.Skills, "Id", "Name");
            var role_list = new SelectList(_context.Roles,"Id", "Name");

            ViewBag.Project = project_list;
            ViewBag.Skill = skill_list;
            ViewBag.Role = role_list;
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
                _context.Persons.Add(person);
                _context.SaveChanges();
            
            
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
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
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
