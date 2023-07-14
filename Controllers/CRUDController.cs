using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StringConverter.Data;
using StringConverter.Models.Domain;
using StringConverter.Models.ViewModel;
using System;
using System.Net.Security;

namespace StringConverter.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly StringConverterDbContext _stringConverterDbContext;
        private readonly HttpClient _httpClient;

        public CRUDController(StringConverterDbContext stringConverterDbContext, IHttpClientFactory httpClientFactory) 
        {
            _stringConverterDbContext = stringConverterDbContext;
            _httpClient = httpClientFactory.CreateClient("StringHttpClient");
        }
      

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
       
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddRequest addRequest)
        {
            var save = new TblConvertString
            {
                DataField = (await TranslateText(addRequest.InputText))!
            };

            _stringConverterDbContext.TblConvertStrings.Add(save);
            _stringConverterDbContext.SaveChanges();
            return RedirectToAction(nameof(GetText));
        } 

        [HttpGet]
        public IActionResult GetText()
        {
            var getData = new GetViewModel();
            var gets = (from get in _stringConverterDbContext.TblConvertStrings
                        select new TblConvertString {  DataField = get.DataField}) ; 
            getData.TblConvertStrings = gets;

            return View(getData);
        }
              
      
        async Task<string?> TranslateText(string text)
        {
            //TranslationResult res= new TranslationResult();
            try
            {
                var result = await _httpClient.GetFromJsonAsync<TranslationResult>($"https://api.funtranslations.com/translate/leetspeak.json?text={text}");

                return result?.Contents?.Translated;
            }
            catch (Exception ex)
            {
            }

            return null;
        }                 
         
    }

    

   
}
