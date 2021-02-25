using FOConstants = FO.Models.Constants.Constants;
using FO.Models.ForClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FO.Models
{
    public class APIReader
    {
        private AllData Data;

        public APIReader()
        {
            Data = GetData();
        }

        public List<Dancer> Dancers => Data.Dancers;

        public List<SHAClasses> GetSHAClasses()
        {
            var content = GetSHAClassesString();

            return JsonConvert.DeserializeObject<List<SHAClasses>>(content);
            //return new List<SHAClasses>();
        }
        public string GetSHAClassesString()
        {
            var content = "";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(FOConstants.DefaultAPIUrl);
                var response = client.GetAsync($"SHAClasses");
                content = response.Result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }
        public Dancer GetDancer(string name, string sername, string patronym) =>
            Data.Dancers.Find(d => d.Person.Name == name && d.Person.Sername == sername && d.Person.Patronym == patronym);
        public AllData GetData() => Data = new AllData();
    }
}
