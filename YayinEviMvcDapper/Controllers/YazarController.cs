using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayinEviMvcDapper.Models;

namespace YayinEviMvcDapper.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            return View(DP.ReturnList<YazarModel>("YazarListele"));
        }


        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YazarNo", id);
                return View(DP.ReturnList<YazarModel>("YazarNoSirala", param).FirstOrDefault<YazarModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(YazarModel yazars)
        {
            //view olustururken list olanı seciyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", yazars.YazarNo);
            param.Add("@YazarAd", yazars.YazarAd);
            param.Add("@YazarTür", yazars.YazarTür);

            DP.ExecuteWReturn("YazarEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", id);
            DP.ExecuteWReturn("YazarSil", param);
            return RedirectToAction("Index");
        }




    }
}