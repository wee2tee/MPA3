using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPA3.Model;
using Newtonsoft.Json;
using System.IO;

namespace MPA3.MakeDoc
{
    public class JsonDoc
    {
        private string docnum = null;

        public JsonDoc(string docnum)
        {
            this.docnum = docnum;
        }

        public CreateJsonResult CreateJson()
        {
            try
            {
                JsonModel model = new JsonModel(this.docnum);

                Console.WriteLine(JsonConvert.SerializeObject(model));
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "test.json", JsonConvert.SerializeObject(model, Formatting.Indented), Encoding.UTF8);
                Console.WriteLine(" ==> " + model.ToString());


                return new CreateJsonResult { createSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new CreateJsonResult { createSuccess = false, message = ex.Message };
            }
        }
    }

    public class CreateJsonResult
    {
        public bool createSuccess { get; set; }
        public string message { get; set; }
    }
}
