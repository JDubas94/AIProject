using AIProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using MyProject.Interfaces;
using MyProject.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class NeuralNetworkController : Controller
    {
        private NeuralNetworkRepository _neuralNetworkRepository;
        readonly IStreamFileUploadService _streamFileUploadService;
        public NeuralNetworkController(IStreamFileUploadService streamFileUploadService, NeuralNetworkRepository neuralNetworkRepository)
        {
            _streamFileUploadService = streamFileUploadService;
            _neuralNetworkRepository = neuralNetworkRepository;
        }


        [HttpPost]
        public async Task<IActionResult> SaveFileToPhysicalFolder()
        {
            var boundary = HeaderUtilities.RemoveQuotes(
                MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
            ).Value;

            var reader = new MultipartReader(boundary, Request.Body);

            var section = await reader.ReadNextSectionAsync();

            string response = string.Empty;
            try
            {
                if (await _streamFileUploadService.UploadFile(reader, section))
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }
            return View();

        }

        public IActionResult Index(Guid id)
        {
            ViewBag.NNTypes = _neuralNetworkRepository.GetNetworkTypes().ToList();
            NeuralNetworkModel neuralNetworkModel = id == default ? new NeuralNetworkModel() { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) } : _neuralNetworkRepository.GetNeuralNetwork(id);
            return View(neuralNetworkModel);
        }

        [HttpPost]
        public IActionResult Index(NeuralNetworkModel neuralNetworkModel)
        {
            if (ModelState.IsValid)
            {
                _neuralNetworkRepository.SaveNeuralNetworkModel(neuralNetworkModel);
                return RedirectToAction("Index", "NeuralNetworkHistory");
            }

            ViewBag.NNTypes = _neuralNetworkRepository.GetNetworkTypes().ToList();
            return View(neuralNetworkModel);
        }


    }



}



