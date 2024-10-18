using ExampleWeb.Data;
using ExampleWeb.Models.Entitys;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MyDbContext _db;
        protected readonly IValidator<Student> _studentValidator;
        public StudentsController(MyDbContext db, IValidator<Student> studentValidator)
        {
            _db = db;
            _studentValidator = studentValidator;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            var validador = _studentValidator.Validate(student);
            if (validador.IsValid)
            {
                var studentModel = new Students
                {
                    Id = Guid.NewGuid(),
                    Name = student.Name,
                    Email = student.Email,
                    Phone = student.Phone,
                    IsActive = student.IsActive,
                };

                await _db.Students.AddAsync(studentModel);
                await _db.SaveChangesAsync();

                return RedirectToAction("List", "Students");
            }
            //ModelState.AddModelError("", string.Join("\n ", validador.Errors));
            validador.Errors.ForEach(e =>
            {
                ModelState.AddModelError("", e.ErrorMessage);
            });
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var students = await _db.Students.ToListAsync();
            return View(students?.Where(s=>s.IsDelete == false).Select(s => new Student
            {   
                Id = s.Id,
                Name = s.Name, 
                Email = s.Email, 
                Phone = s.Phone,
                IsActive = s.IsActive,
            }).ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if(!string.IsNullOrEmpty(id.ToString()))
            {
                var student = await _db.Students.FirstOrDefaultAsync(s=> s.Id == id);
                if (student != null)
                {
                    return View(new Student
                    {
                        Id=student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Phone = student.Phone,
                        IsActive = student.IsActive
                    });
                }
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            var validador = _studentValidator.Validate(student);
            if (validador.IsValid)
            {
                if (!string.IsNullOrEmpty(student.Id.ToString()))
                {
                    var studentEntity = await _db.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
                    if (studentEntity != null)
                    {
                        studentEntity.Name = student.Name;
                        studentEntity.Email = student.Email;
                        studentEntity.Phone = student.Phone;
                        studentEntity.IsActive = student.IsActive;

                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        return View();
                    }
                }
                return RedirectToAction("List", "Students");
            }
            validador.Errors.ForEach(e =>
            {
                ModelState.AddModelError("", e.ErrorMessage);
            });
            
            return View(student);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                {
                    return View(new Student
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Phone = student.Phone,
                        IsActive = student.IsActive
                    });
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student student)
        {
            if (!string.IsNullOrEmpty(student.Id.ToString()))
            {
                var studentEntity = await _db.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
                if (studentEntity != null)
                {
                    studentEntity.IsDelete = true;

                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List", "Students");
        }
    }
}
