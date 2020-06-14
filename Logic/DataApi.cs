using Asteria.Interface;
using Asteria.Models.Admin;
using Asteria.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asteria.Models
{
    public class DataApi : IData
    {
        string urlClient = @"https://localhost:5001/api/clients/";
        string urlRecord = @"https://localhost:5001/api/records/";
       
        string url;

        string token = Program.token;


        private HttpClient httpClient { get; set; }
        public DataApi()
        {
            
            this.url = new UrlString().Url;
            this.httpClient = new HttpClient();
            if (!string.IsNullOrWhiteSpace(token))
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", token);
                  //  new System.Net.Http.Headers.AuthenticationHeaderValue("Cookie", token);
            }
        }

        #region Client
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var res = httpClient.GetStringAsync(urlClient).Result;

            return JsonConvert.DeserializeObject<List<Client>>(res);
        }

        public ActionResult<Client> GetClients(int id)
        {
            var res = httpClient.GetStringAsync(urlClient + @"/" + id).Result;

            return JsonConvert.DeserializeObject<Client>(res);
        }

        public void AddClient(Client client)
        {
            var json = JsonConvert.SerializeObject(client);
            var res = httpClient.PostAsync(
                requestUri: urlClient,
                content: new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        public string PutClient(Client new_client, long id)
        {
            var json = JsonConvert.SerializeObject(new_client);


            var res = httpClient.GetStringAsync(urlClient + @"/" + id).Result;
            var qres = httpClient.PutAsync(urlClient + @"/" + id, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8,
                mediaType: "application/json"));

            return JsonConvert.DeserializeObject<string>(res);
        }

        public Client DelClient(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Record


        public ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date)
        {
            try
            {


                var dt = DataHelpercs.ConvertToDate(date);
               
                var res = httpClient.GetStringAsync(urlRecord + @"GetRecords/" + dt.ToShortDateString() ).Result;

                return JsonConvert.DeserializeObject<List<RecordsDTO>>(res);
            }
            catch (Exception e)
            {
                List<RecordsDTO> res = new List<RecordsDTO>();
                res.Add(new RecordsDTO { ClientName = e.Message });

                return res;
            }
        }

        public ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date, string spec)
        {
            try
            {

           
            var dt = DataHelpercs.ConvertToDate(date);

            int specId = GetSpecialists().Value.Where(s => (s.Name == spec)).FirstOrDefault().Id;
            var res = httpClient.GetStringAsync(urlRecord + @"GetRecords/" + dt.ToShortDateString() + @"/SpecID/" + specId).Result;

           

            return JsonConvert.DeserializeObject<List<RecordsDTO>>(res);
            }
            catch(Exception e)
            {
                List<RecordsDTO> res = new List<RecordsDTO>();
                res.Add( new RecordsDTO { ClientName = e.Message} );
              
                return res;
            }
        }

        public ActionResult<IEnumerable<Record>> GetRecords()
        {
            var res = httpClient.GetStringAsync(urlRecord).Result;

            return JsonConvert.DeserializeObject<List<Record>>(res);
        }

        //GetRecords/{date}/SpecID/{specID}/Time/{time}
        public ActionResult<IEnumerable<Record>> GetRecords(DateTime dt, int specId)
        {
            var res = httpClient.GetStringAsync(urlRecord + @"GetRecords/" + dt.ToShortDateString()+@"/SpecID/" +specId+@"/Time/" + dt.ToShortTimeString()).Result;
            return JsonConvert.DeserializeObject<List<Record>>(res);
        }

        public ActionResult<Record> GetRecords(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRecord(Record record)
        {
            string curenturl = url + @"Records/";
            var res = httpClient.PostAsync(
                requestUri: curenturl,
                content: new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        public string PutRecord(RecordsDTO newRecord, long id)
        {
            var sId = GetSpecialists(newRecord.SpecName);//
            var c = sId.Value.Where(s => (s.Name == newRecord.SpecName)).FirstOrDefault().Id;
            
            var newRec = new Record(newRecord.Id, newRecord.Clientid,
                //меняем специалиста по его  id 
                c,
                //
                newRecord.Date, newRecord.Time, newRecord.TypeWork, newRecord.Price);

            string curenturl = url + @"/Records/"+id;
            var res = httpClient.PutAsync(
                requestUri: curenturl,
                content: new StringContent(JsonConvert.SerializeObject(newRec), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;

            return res.StatusCode.ToString();

        }

        public Record DelRecord(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Specialist
        public ActionResult<IEnumerable<Specialist>> GetSpecialists()
        {
            string curenturl = url + @"/Specialists/";
            var res = httpClient.GetStringAsync(curenturl).Result;
            return JsonConvert.DeserializeObject<List<Specialist>>(res);
        }

        public ActionResult<IEnumerable<Specialist>> GetSpecialists(string namespec)
        {
            string curenturl = url + @"/Specialists/";
            var res = httpClient.GetStringAsync(curenturl).Result;
            return JsonConvert.DeserializeObject<List<Specialist>>(res);
        }

        public ActionResult<Specialist> GetSpecialists(int id)
        {
            string curenturl = url + @"/Specialists/" + id;
              var res = httpClient.GetStringAsync(curenturl).Result;
                return JsonConvert.DeserializeObject<Specialist>(res);
        }

        public void AddSpecialist(Specialist specialist)
        {

           /* var res = httpClient.PostAsync(
                requestUri: urlClient,
                content: new StringContent(JsonConvert.SerializeObject(specialist), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;*/

            var json = JsonConvert.SerializeObject(specialist);


            //var res = httpClient.GetStringAsync(url + @"/Specialists/").Result;
            var qres = httpClient.PostAsync(url + @"/Specialists/", new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8,
                mediaType: "application/json"));

         
        }


        public string PutSpecialist(Specialist newSpecialist, long id)
        {
            throw new NotImplementedException();
        }

        public Specialist DelSpecialist(int id)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Admin
        public ActionResult<string> Login(UserLogin user)
        {
            string path = url + @"adminS/log";
            var json = JsonConvert.SerializeObject(user);
            HttpResponseMessage res = httpClient.PostAsync(
                requestUri: path,
                content: new StringContent(json, Encoding.UTF8,
                mediaType: "application/json")
                ).Result;

            try
            {
                var t = res.Headers.ToList();
                var to = res.Headers.GetValues("Set-Cookie").FirstOrDefault();
                Program.token = to.ToString();
                

            }
            catch { }
            return JsonConvert.SerializeObject(res);
        }



        public  void Logout()
        {
            string path = url + @"/admin/out/";
            var res = httpClient.PostAsync(path, null);
        }

        public ActionResult<string> Registr(UserRegistration user)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
