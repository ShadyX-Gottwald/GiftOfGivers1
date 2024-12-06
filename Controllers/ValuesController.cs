using GiftOfGivers1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiftOfGivers1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase { 

    Supabase.Client _supabase {  get; set; }
    public ValuesController(Supabase.Client supabase) {
        _supabase = supabase;
    }
    // GET: api/<ValuesController>
    [HttpPost]
    [Route("save-category")]
    public async Task<IActionResult> CommitCategory() { 
        var category = new DisasterCategory() { Id = 1 , Name= "Flood" };
       // await _supabase.From<DisasterCategory>().Insert(category); 

        return Ok(category);
    }




}
