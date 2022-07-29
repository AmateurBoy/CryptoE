using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
namespace BitExchanger.Controllers
{

    [ApiController]
    public class HomeController : Controller
    {

        public List<TestClass> Test = new List<TestClass>();
        public class TestClass
        {
            public string ccy { get; set; }
            public string base_ccy { get; set; }
            public string buy { get; set; }
            public string sale { get; set; }

        }
        public class ResultClass
        {
            public static string id { get; set; }
            public string name { get; set; }  
            public string value { get; set; }
            public ResultClass()
            {
                id += 1;
            }
        }
        public List<ResultClass> TestR = new List<ResultClass>()
        {
            new()
            {
                name="BTC",
                value = "10000000"

            },
            new()
            {
                name = "ETH",
                value = "10000"

            },
            new()
            {
                name = "DOGE",
                value = "100000"

            },
            new()
            {
                name = "ILUXACOIN",
                value = "20000000"

            },
            new()
            {
                name = "ILUXACOIN228",
                value = "200000000000000"

            }
        };
        
        [HttpGet("/apitest")]
        public IActionResult Index()
        {
            string result = "PrivatBank API <З\n";
            





        //    try
        //        {
        //            string APIURL = $"https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11";
                    
        //            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(APIURL);
        //            httpRequest.Method = "GET";
        //            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
        //            string r = "";
        //            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                r = reader.ReadToEnd();
        //            }
        //        //Test = JsonConvert.DeserializeObject<List<TestClass>>(r);
        //        //foreach (var item in test)
        //        //{
        //        //    rsultclass rsultclass = new rsultclass();
        //        //    rsultclass.name = item.ccy;
        //        //    rsultclass.value = item.buy;
        //        //    testr.add(rsultclass);
        //        //}
        //    }
        //        catch
        //        {
        //            result += $"итерация неудачная ";
        //        }

        //        result += "===================================\n";
            
            
            return Json(TestR);
                
        }

        [HttpGet("/")]
        [HttpGet("/main")]
        public IActionResult Redirect()
        {
            return Redirect("/index.html");
        }

        [HttpPost("/postcurrcy")]      
        public IActionResult Input(IFormCollection i)
       {
            decimal result = 0;
            try
            {
                decimal value = Convert.ToDecimal(i["value"]);
                string nameIn = i["nameIn"];
                string nameOut = i["nameOut"];
                foreach (var item in TestR)
                {

                    if (item.name == nameIn)
                    {
                        foreach (var t in TestR)
                        {
                            if (t.name == nameOut)
                            {
                                result = (Convert.ToDecimal(item.value) / Convert.ToDecimal(t.value)) * value;
                            }
                        }
                    }
                }
            }
            catch
            {
                result = -1;
            }
            
            
            
            //value
            //nameIn
            //nameOut

            return Json(result);
        }
       
        
        [HttpGet("/Result")]
        public string result()
        {
            
            return $"f\n2";
        }

    }
    
}
