using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("MemberListProc", Schema = "dbo")]
  public partial class MemberListProc
  {
    [Key]
    public Int64 MemberID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FullName
    {
      get;
      set;
    }
  }
}
