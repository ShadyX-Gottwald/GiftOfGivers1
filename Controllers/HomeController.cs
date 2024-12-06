using GiftOfGivers1.Data;
using GiftOfGivers1.Models;
using GiftOfGivers1.Utils;
using Librame.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfGivers1.Controllers;


public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }

    [Route("/Privacy")]
    public IActionResult Privacy() {
        return View();
    }

   
    public async Task<IActionResult> ReportDisaster() {

        //Get Categories from Supabase 

        //Database Variables 
        var supabase = SupabaseClient.Supabase();

        //Get Categories from Supabase
        var res = await supabase.From<DisasterCategory>()
            .Get();

        ViewData["model"] = new Disaster();

       
        ViewData["categories"] = res.Models;


       
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SaveDisaster(Disaster disaster) {

        //Get Categories from Supabase 
        //Save to Supabase

        if (disaster == null) {
            RedirectToAction("Index");
        }


         await DisasterService.ReportDisaster(disaster);

        return RedirectToAction("ReportDisaster");
    }

    [HttpGet]
    public async Task<IActionResult> ViewAllDisasters() { 

        var list = new List<Disaster>();
        //Get All Disasters from DB
        var result  =  await DisasterService.GetAllDisasters()!;


        if (result == null || result.IsEmpty()) RedirectToAction("ReportDisaster");


        return View();

    }


    [HttpGet]
    public async Task<IActionResult> DisasterDetails([FromForm] int DisasterId) {

        var list = new List<Disaster>();
        //Get All Disasters from DB

        var result = await DisasterService.GetDisasterById(NavUtils.ClickedId);
       
        TempData["id"] = DisasterId;

        if (result == null) {
            RedirectToAction("ReportDisaster");
        }

       


        return View();

    }



}




