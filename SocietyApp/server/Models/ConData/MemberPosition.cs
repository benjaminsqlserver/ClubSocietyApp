using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("MemberPositions", Schema = "dbo")]
  public partial class MemberPosition
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PositionID
    {
      get;
      set;
    }


    public ICollection<Member> Members { get; set; }
    [ConcurrencyCheck]
    public string PositionName
    {
      get;
      set;
    }
  }
}
