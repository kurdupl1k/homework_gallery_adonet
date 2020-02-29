using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Models
{
  [Table("tblUsers")]
  public class User
  {
    [Key] public int Id { get; set; }
    [Required, StringLength(100)] public string Login { get; set; }
    [Required, StringLength(100)] public string Password { get; set; }

    public virtual ICollection<Image> Images { get; set; }
  }
}