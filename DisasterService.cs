using GiftOfGivers1.Data;
using GiftOfGivers1.Models;

namespace GiftOfGivers1;

public static class DisasterService {

    //Add Disaster To SUpabase

    public static async Task ReportDisaster(Disaster disaster) {
        

        var supabase = SupabaseClient.Supabase();

        var res = await supabase.From<Disaster>().Insert(disaster!); 

    }

    public static async Task<List<Disaster>> GetAllDisasters() {

       
        var emptyList = new List<Disaster>();
            var supabase = SupabaseClient.Supabase();

            var result = await supabase.From<Disaster>().Get();

        if (result != null) {
            return await Task.FromResult(result.Models.ToList());
        }

        return await Task.FromResult(emptyList);

    }

    public static async Task<Disaster> GetDisasterById(int id) { 
        var dummy = new Disaster();
        var supabase = SupabaseClient.Supabase();

        var result = await supabase.From<Disaster>()
            .Where(it => it.DisasterId == id)
            .Get();

        if (result != null) {
            return await Task.FromResult(result.Models.First());
        }

        return dummy;
        
    }

    public static async Task<List<Disaster>> GetJohnsReportedDisasters(string email) {
        var dummy = new List<Disaster>();
        var supabase = SupabaseClient.Supabase();

        if (email != null || email != "") {
            var result = await supabase.From<Disaster>()
           .Where(it => it.DisasterName == email)
           .Get();
                return await Task.FromResult(result.Models);

        }
        else {
            return await Task.FromResult(dummy);
        }

    }


}
