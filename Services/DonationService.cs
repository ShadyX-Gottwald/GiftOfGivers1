using GiftOfGivers1.Data;
using GiftOfGivers1.Models;

namespace GiftOfGivers1.Services;

public static  class DonationService {


    public static async Task<List<Donation>> GetAllDonations() {


        var emptyList = new List<Donation>();
        var supabase = SupabaseClient.Supabase();

        var result = await supabase.From<Donation>().Get();

        if (result != null) {
            return await Task.FromResult(result.Models.ToList());
        }

        return await Task.FromResult(emptyList);

    }

    public static async Task<List<Donation>> GetAllDonationsByEmail(string email) {


        var emptyList = new List<Donation>();
        var supabase = SupabaseClient.Supabase();

        var result = await supabase.From<Donation>()
            .Where(it => it.Email == email)
            .Get();

        if (result != null) {
            return await Task.FromResult(result.Models.ToList());
        }

        return await Task.FromResult(emptyList);

    }

    public static async Task<List<string>> SplitDonationItems(string email ) {
        var emptyList = new List<string>();
        var supabase = SupabaseClient.Supabase();

        var result = await supabase.From<Donation>()
            .Where(it => it.Email == email)

            .Get();

        if (result != null) { 
            //Get it
            var res = result.Models.First().SeparateItems;
            if (res != null) { 
                var split = res.Split(";");
                if (split.Length > 0) {
                    return await Task.FromResult(split.ToList());
                }
            }
            return await Task.FromResult(emptyList);
        }
        return await Task.FromResult(emptyList);

    }

    public static async Task<List<string>> SplitDonationItemsLast(string email) {


        var emptyList = new List<string>();
        var supabase = SupabaseClient.Supabase();

        var result = await supabase.From<Donation>()
            .Where(it => it.Email == email)
            .Get();

        if (result != null) {
            //Get it
            var res = result.Models.Last().SeparateItems;
            if (res != null) {
                var split = res.Split(";");
                if (split.Length > 0) {
                    return await Task.FromResult(split.ToList());
                }
            }
            return await Task.FromResult(emptyList);
        }
        return await Task.FromResult(emptyList);


    }






}
