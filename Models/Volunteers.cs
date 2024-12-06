using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = Supabase.Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Supabase.Postgrest.Attributes.TableAttribute;

namespace GiftOfGivers1.Models;

[Table("volunteers")]
public class Volunteers: BaseModel {

    [Key]
    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("email")]
    public string VolunteerEmail { get; set; }

    [Column("disaster_id")]
    public int DisasterId { get; set; }

}
