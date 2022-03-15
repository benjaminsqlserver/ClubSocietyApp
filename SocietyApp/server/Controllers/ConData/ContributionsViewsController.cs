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

  [Route("odata/ConData/ContributionsViews")]
  public partial class ContributionsViewsController : ODataController
  {
    private Data.ConDataContext context;

    public ContributionsViewsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/ContributionsViews
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.ContributionsView> GetContributionsViews()
    {
      var items = this.context.ContributionsViews.AsNoTracking().AsQueryable<Models.ConData.ContributionsView>();
      this.OnContributionsViewsRead(ref items);

      return items;
    }

    partial void OnContributionsViewsRead(ref IQueryable<Models.ConData.ContributionsView> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ContributionID}")]
    public SingleResult<ContributionsView> GetContributionsView(Int64 key)
    {
        var items = this.context.ContributionsViews.AsNoTracking().Where(i=>i.ContributionID == key);
        this.OnContributionsViewsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnContributionsViewsGet(ref IQueryable<Models.ConData.ContributionsView> items);

  }
}
