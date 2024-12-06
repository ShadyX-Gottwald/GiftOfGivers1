using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers1.Models;

[Table("donations")]
public class Donation: BaseModel {

    [Key]
    [PrimaryKey("id")]
    public int DonationId { get; set; }

    [Column("items_string")]
    public string SeparateItems { get; set; }

    [Column("email")]
    public string Email { get; set; }
    [Column("disaster_id")]
    public int DisasterId { get; set; }
}
