using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using StringConverter.Data;
using StringConverter.Data.Interfaces;
using StringConverter.Data.Repositories;
using StringConverter.Models.Domain;
using StringConverter.Models.ViewModel;
using System;
using System.Net.Security;
using System.Text.Json;

namespace StringConverter.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly IStringConverterRepository _repository;
        private readonly ITranslateText _translate;

        public CRUDController( IStringConverterRepository repository ,ITranslateText translate) 
        {
            _repository = repository;
            _translate = translate; 
        }
      

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult?> Add(AddRequest addRequest)
        {
            if (ModelState.IsValid)
            {
                var save = new TblConvertString();
                save.DataField = await _translate.TranslateText(addRequest.InputText);

                _repository.Add(save);
                return RedirectToAction(nameof(GetText));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Text Addition Failed");
            }
            return null;
        }

        [HttpGet]

        public async Task<IActionResult?> GetText()
        {
            if (ModelState.IsValid)
            {
                var getData = new GetViewModel();
                FormattableString fetch = $"[dbo].[spcGetTranslatedText]";
                var gets = await _repository.GetAllAsync(fetch);             
                getData.TblConvertStrings = gets;

                return View(getData);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to fetch text");
            }
            return null;
        }
      
    }
   
}
