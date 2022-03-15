using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace SocietyApp.Controllers.ConData
{
  using Models;
  using Data;
  using Models.ConData;

  public partial class MemberListProcsController : ODataController
  {
    private Data.ConDataContext context;

    public MemberListProcsController(Data.ConDataContext context)
    {
      this.context = context;
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [Route("odata/ConData/MemberListProcsFunc()")]
    public IActionResult MemberListProcs()
    {
        try
        {
            var items = this.context.MemberListProcs.FromSqlRaw("EXEC [dbo].[MemberListProc]").AsNoTracking().ToList().AsQueryable();

            this.OnMemberListProcsInvoke(ref items);

            return Ok(items);
        }
        catch(Exception ex)
        {
            return new ObjectResult(new { message = ex.Message})
            {
                StatusCode = 400
            };
        }
    }

    partial void OnMemberListProcsInvoke(ref IQueryable<Models.ConData.MemberListProc> items);
  }
}
