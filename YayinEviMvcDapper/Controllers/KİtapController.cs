using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayinEviMvcDapper.Models;

namespace YayinEviMvcDapper.Controllers
{
    public class KİtapController : Controller
    {
        // GET: Kİtap
        public ActionResult Index()
        {
            return View(DP.ReturnList<KitapModel>("KitapListele"));
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@KitapNo", id);
                return View(DP.ReturnList<KitapModel>("KitapNoSirala", param).FirstOrDefault<KitapModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(KitapModel kitaps)
        {
            //view olustururken list olanı seciyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", kitaps.KitapNo);
            param.Add("@KitapAd", kitaps.KitapAd);
            param.Add("@KategoriNo", kitaps.KategoriNo);
            param.Add("@YazarNo", kitaps.YazarNo);
            param.Add("@YayınEviNo", kitaps.YayınEviNo);

            DP.ExecuteWReturn("KitapEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", id);
            DP.ExecuteWReturn("KitapSil", param);
            return RedirectToAction("Index");
        }


    }
}