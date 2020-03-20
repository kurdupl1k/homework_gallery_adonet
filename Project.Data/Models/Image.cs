using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Models
{
  [Table("tblImages")] 
  public class Image
  {
    [Key] public int Id { get; set; }
    [Required, StringLength(500)] public string Source { get; set; }
    [ForeignKey("UserOf")] public int UserId { get; set; }

    public virtual User UserOf { get; set; }
  }
}