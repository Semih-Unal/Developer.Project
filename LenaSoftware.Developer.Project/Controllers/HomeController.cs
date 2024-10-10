using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using LenaSoftware.Developer.Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace LenaSoftware.Developer.Project.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFormService formService;

        public HomeController(IFormService formService, ILogger<HomeController> logger)
        {
            this.formService = formService;
            _logger = logger;
        }

        public IActionResult Index(string filter)
        {

            var forms = formService.GetAll(filter);
            return View(forms);
        }
        [HttpPost]
        public IActionResult AddForm(AddForm addForm)
        {
            int currentUserId = Convert.ToInt32(HttpContext.Session.GetString(UserSessionKey));
            Form form = new Form();
            form.Name= addForm.Name;
            form.Description=addForm.Description;
            form.CreatedAt=DateTime.Now;
            form.CreatedBy= currentUserId;
            form.Fields = JsonSerializer.Serialize(addForm.FormFields);
            formService.Add(form);
            return RedirectToAction("Index", "Home");
        }
        [Route("forms/{formId}")]
        public IActionResult Forms(int formId)
        {
            var form = formService.GetForm(formId);
            AddForm viewform = new AddForm();
            viewform.Name = form.Name;
            viewform.Description = form.Description;
            viewform.FormFields = JsonSerializer.Deserialize<List<FormField>>(form.Fields);
            return View(viewform);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
