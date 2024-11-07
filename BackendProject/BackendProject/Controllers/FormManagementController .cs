using BackendProject.Models;
using BackendProject.Repositories.Form;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    [Authorize]
    public class FormManagementController(IFormRepository _formRepository) : Controller
    {
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string searchTerm = "")
        {
            var forms = await _formRepository.GetFormsAsync(searchTerm);
            return View(forms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var form = await _formRepository.GetFormByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Form form)
        {
            form.CreatedAt = Convert.ToString(DateTime.Now);
            form.CreatedBy = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest("Form bilgileri eksik.");
            }



            await _formRepository.AddFormAsync(form);
            return RedirectToAction("Index");
        }
    }
}
