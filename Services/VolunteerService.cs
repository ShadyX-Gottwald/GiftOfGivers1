using GiftOfGivers1.Data;
using GiftOfGivers1.Models;

namespace GiftOfGivers1.Services;

public static class VolunteerService {

    public static async Task<List<Volunteers>> GetAllVolonteersByEmail(string email) {

        var emailD = "John@GiftOfGivers1128.onmicrosoft.com";
        var emptyList = new List<Volunteers>();
        var supabase = SupabaseClient.Supabase();


        if (email == null || email.Length == 0) {
            return await Task.FromResult(emptyList);
        }
        //Get Categories from Supabase
        var res = await supabase.From<Volunteers>()
           .Where(it => it.VolunteerEmail == email)
            .Get();

        if (res != null) {
            return await Task.FromResult(res.Models.ToList());
        }

        return await Task.FromResult(emptyList);

    }

    public static async Task<List<Volunteers>> GetAllVolonteers() {

        var emptyList = new List<Volunteers> { };
        var supabase = SupabaseClient.Supabase();
        //Get Categories from Supabase
        var res = await supabase.From<Volunteers>()
            .Get();

        if (res != null) {
            return await Task.FromResult(res.Models.ToList());
        }

        return await Task.FromResult(emptyList);

    }

    public static async Task<string> GetPersonVolunteeredToDisasterById(int id) {

        var supabase = SupabaseClient.Supabase();
        var empty = "";

        if (id == 0) {
            throw new ArgumentException("Cannot Be Zeror");
        }
        //Get Categories from Supabase
        var res = await supabase.From<Volunteers>()
           .Where(it => it.DisasterId == id)
            .Get();

        if (res == null) {
            throw new Exception("Disaster Id Does Not Exist");
        }

        var first = res.Models.First();

        if (res != null) {
            return await Task.FromResult(first.VolunteerEmail);
        }

        return await Task.FromResult(empty);

    }


}
