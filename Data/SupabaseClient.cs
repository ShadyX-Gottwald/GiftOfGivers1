namespace GiftOfGivers1.Data;

public static class SupabaseClient {  

    public static Supabase.Client Supabase() {
        //Database Variables 

        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndtYXBjdmF4Y25ia2J3eHR1Z3RoIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzA3MDI0MzYsImV4cCI6MjA0NjI3ODQzNn0.b1BnqEIawvPY6003xS390GRGWUfBAb7-llPzG1stG5U";

        var url = "https://wmapcvaxcnbkbwxtugth.supabase.co";

        var options = new Supabase.SupabaseOptions {
            AutoConnectRealtime = true,
            AutoRefreshToken = true,

        };

        var supabase = new Supabase.Client(url, key, options); 
        return supabase;
    }

}
