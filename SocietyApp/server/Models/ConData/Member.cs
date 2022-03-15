using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApp.Models.ConData
{
  [Table("Members", Schema = "dbo")]
  public partial class Member
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 MemberID
    {
      get;
      set;
    }


    public ICollection<MemberContribution> MemberContributions { get; set; }
    [ConcurrencyCheck]
    public string FirstName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string MiddleName
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
    public int GenderID
    {
      get;
      set;
    }

    public Gender Gender { get; set; }
    [ConcurrencyCheck]
    public DateTime? DateOfBirth
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ResidentialAddress
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string OfficeAddress
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string MobileNumber1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string WhatsappNumber
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Email
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string MemberPhoto
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? CurrentPositionID
    {
      get;
      set;
    }

    public MemberPosition MemberPosition { get; set; }
  }
}
