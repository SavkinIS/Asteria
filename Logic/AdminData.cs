using Asteria.Interface;
using Asteria.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asteria.Models
{
    /// <summary>
    /// Класс реализует логирование регистрацию и выход из приложения
    /// </summary>
    public class AdminData : IAdminDatacs
    {
        string url;

        
        private HttpClient httpClient { get; set; }

        public AdminData()
        {
            this.url = new UrlString().Url;
            this.httpClient = new HttpClient();
        }

        



        public ActionResult<string> Login(UserLogin user)
        {
            string path = url + @"/log";
            var json = JsonConvert.SerializeObject(user);
            var res = httpClient.PostAsync(
                requestUri: path,
                content: new StringContent(json, Encoding.UTF8,
                mediaType: "application/json")
                ).Result;

            return JsonConvert.SerializeObject(res);
        }

       

        public ActionResult<string> Logout()
        {
            throw new NotImplementedException();
        }

        public ActionResult<string> Registr(UserRegistration user)
        {
            throw new NotImplementedException();
        }
    }
}
