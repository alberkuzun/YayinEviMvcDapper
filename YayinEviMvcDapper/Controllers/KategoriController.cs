﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayinEviMvcDapper.Models;

namespace YayinEviMvcDapper.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View(DP.ReturnList<KategoriModel>("KategoriListele"));
        }


        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@KategoriNo", id);
                return View(DP.ReturnList<KategoriModel>("KategoriNoSirala", param).FirstOrDefault<KategoriModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(KategoriModel kategoris)
        {
            //view olustururken list olanı seciyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@KategoriNo", kategoris.KategoriNo);
            param.Add("@KategoriAd", kategoris.KategoriAd);
            DP.ExecuteWReturn("KategoriEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KategoriNo", id);
            DP.ExecuteWReturn("KategoriSil", param);
            return RedirectToAction("Index");
        }





    }
}