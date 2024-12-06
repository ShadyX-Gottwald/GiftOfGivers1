using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers1.Models;


[Table("disaster_category")]
public class DisasterCategory :BaseModel{

    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("name")]
    public  string Name { get; set; }
}
