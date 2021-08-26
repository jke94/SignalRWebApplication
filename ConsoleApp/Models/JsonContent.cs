namespace ConsoleApp.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;

    public class JsonContent<T> : StringContent
    {
        private List<T> data;

        public JsonContent(IList<T> data)
             : base(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        {
            this.data = (List<T>)data;
        }
    }
}
