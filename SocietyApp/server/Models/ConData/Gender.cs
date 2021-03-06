using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("Genders", Schema = "dbo")]
  public partial class Gender
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderID
    {
      get;
      set;
    }


    public ICollection<Member> Members { get; set; }
    [ConcurrencyCheck]
    public string GenderName
    {
      get;
      set;
    }
  }
}
