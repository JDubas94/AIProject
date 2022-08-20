using AIProject.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using MyProject.Models;
using System;
using System.Security.Claims;

namespace AIProject.Controllers
{
    public class NeuralNetworkHistoryController : Controller
    {
        private readonly NeuralNetworkRepository _neuralNetworkRepository;
       // private readonly UserManager<IdentityUser> _userManager;
        public NeuralNetworkHistoryController(NeuralNetworkRepository neuralNetworkRepository) //UserManager<IdentityUser> userManager)
        {
            this._neuralNetworkRepository = neuralNetworkRepository;
          //  this._userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = _neuralNetworkRepository.GetNeuralNetworksByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
       

        [HttpPost]
        public IActionResult DeleteNauralNetwork(Guid id)
        {
            _neuralNetworkRepository.DeleteNeuralNetworkModel(new NeuralNetworkModel { Id = id });
            return RedirectToAction("Index");
        }

    }
}
