using GiftOfGivers1.Models;
using GiftOfGivers1.Services;
using Librame.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiftOfGivers1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationsController : Controller {
    // GET: api/<DonationsController>

    [HttpGet]
    public async Task<IActionResult> ViewAllDisasters() {

        var list = new List<Disaster>();
        //Get All Disasters from DB
        var result = await DonationService.GetAllDonations()!;


        if (result == null || result.IsEmpty()) RedirectToAction("ReportDisaster");


        return View();

    }

    [HttpGet]
    public async Task<IActionResult> ViewDonationsByEmail(string email) {

        var list = new List<Disaster>();

        if (email == null || email.IsEmpty() || email.IsDigit()) {
            RedirectToAction("Index");
        }
        //Get All Disasters from DB
        var result = await DonationService.GetAllDonationsByEmail(email!);


        if (result == null || result.IsEmpty()) RedirectToAction("ReportDisaster");


        return View();

    }


}
