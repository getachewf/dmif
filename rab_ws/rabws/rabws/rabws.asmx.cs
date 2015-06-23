using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Runtime.InteropServices;

namespace rabws
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://get.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class rabws : System.Web.Services.WebService
    {

        [WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        public float current_rab_pop(float rabpop, float foxpop)
        {
            return rabpop + DllHelper.popinc(rabpop, foxpop);
        }

        [WebMethod]
        public int pop_increase(int rabpop, int foxpop)
        {
            return DllHelper.popgrowth(rabpop, foxpop);
        }

        [WebMethod]
        public float pop_inc(float rabpop, float foxpop)
        {
            return DllHelper.popinc(rabpop, foxpop);
        }

        [WebMethod]
        public int[] pop_list(int initpop, int yr)
        {
            int[] poplst= new int[yr];
            poplst[0] = initpop;

            IntPtr ptr = DllHelper.pop2(initpop, yr);
            for (int j = 1; j < yr; j++)
            {
                poplst[j] = poplst[j-1] + Marshal.ReadInt32(ptr, j * sizeof(Int32));
            };

            return poplst;
        }




    }
}