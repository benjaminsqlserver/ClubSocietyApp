using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("ContributionsView", Schema = "dbo")]
  public partial class ContributionsView
  {
    [Key]
    public Int64 ContributionID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FirstName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Surname
    {
      get;
      set;
    }
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
