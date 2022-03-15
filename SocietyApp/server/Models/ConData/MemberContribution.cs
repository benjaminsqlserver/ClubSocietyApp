using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("MemberContributions", Schema = "dbo")]
  public partial class MemberContribution
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 ContributionID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64 MemberID
    {
      get;
      set;
    }

    public Member Member { get; set; }
    [ConcurrencyCheck]
    public DateTime ContributionDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal AmountContributed
    {
      get;
      set;
    }
  }
}
