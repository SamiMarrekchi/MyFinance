using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFinanceWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public String Welcome()
        {
            return "This is my Welcome Message";
        }
        public String WelcomeYou(String name,int numTimes=1)
        {
            return "My Name is "+name+" my numTimes is "+numTimes;
        }
        [Route("WelcomeYou2/{name}/{ID:int}")]
        public String WelcomeYou2(String name, int ID = 1)
        {
            return "My Name is " + name + " my ID is " + ID;
        }

    }
}