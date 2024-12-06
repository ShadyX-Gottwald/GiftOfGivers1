using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = Supabase.Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Supabase.Postgrest.Attributes.TableAttribute;

namespace GiftOfGivers1.Models;


[Table("disasters")]
public class Disaster: BaseModel {

    [PrimaryKey("id")]
    public int DisasterId { get; set; }
    [Column("disaster_category")]
    public int? DisasterCategory { get; set; }

    [Column("disaster_name")]
    public string DisasterName { get; set; }

    [Column("location")]
    public string Location { get; set; }
}
