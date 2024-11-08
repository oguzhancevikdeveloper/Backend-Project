using BackendProject.Models.Form;
using BackendProject.Repositories.Form;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendProject.Controllers
{
    [Authorize]
    public class FormManagementController(IFormRepository _formRepository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm = "")
        {
            var forms = await _formRepository.GetFormsAsync(searchTerm);
            return View(forms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var form = await _formRepository.GetFormByIdAsync(id);
            if (form == null) return NotFound();
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Form form)
        {
            if (!string.IsNullOrEmpty(form.FieldsJson)) form.Fields = JsonConvert.DeserializeObject<List<FormField>>(form.FieldsJson);

            form.CreatedAt = Convert.ToString(DateTime.Now);
            form.CreatedBy = 1;
            await _formRepository.AddFormAsync(form);

            return RedirectToAction("Index");
        }
    }
}
