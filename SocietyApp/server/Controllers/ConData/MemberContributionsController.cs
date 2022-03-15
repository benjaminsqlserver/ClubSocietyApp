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

  [Route("odata/ConData/MemberContributions")]
  public partial class MemberContributionsController : ODataController
  {
    private Data.ConDataContext context;

    public MemberContributionsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/MemberContributions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.MemberContribution> GetMemberContributions()
    {
      var items = this.context.MemberContributions.AsQueryable<Models.ConData.MemberContribution>();
      this.OnMemberContributionsRead(ref items);

      return items;
    }

    partial void OnMemberContributionsRead(ref IQueryable<Models.ConData.MemberContribution> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ContributionID}")]
    public SingleResult<MemberContribution> GetMemberContribution(Int64 key)
    {
        var items = this.context.MemberContributions.Where(i=>i.ContributionID == key);
        this.OnMemberContributionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMemberContributionsGet(ref IQueryable<Models.ConData.MemberContribution> items);

    partial void OnMemberContributionDeleted(Models.ConData.MemberContribution item);

    [HttpDelete("{ContributionID}")]
    public IActionResult DeleteMemberContribution(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.MemberContributions
                .Where(i => i.ContributionID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MemberContribution>(Request, items);

            var itemToDelete = items.FirstOrDefault();

            if (itemToDelete == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberContributionDeleted(itemToDelete);
            this.context.MemberContributions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberContributionUpdated(Models.ConData.MemberContribution item);

    [HttpPut("{ContributionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMemberContribution(Int64 key, [FromBody]Models.ConData.MemberContribution newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MemberContributions
                .Where(i => i.ContributionID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MemberContribution>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberContributionUpdated(newItem);
            this.context.MemberContributions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MemberContributions.Where(i => i.ContributionID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Member");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ContributionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMemberContribution(Int64 key, [FromBody]Delta<Models.ConData.MemberContribution> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MemberContributions.Where(i => i.ContributionID == key);

            items = EntityPatch.ApplyTo<Models.ConData.MemberContribution>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(itemToUpdate);

            this.OnMemberContributionUpdated(itemToUpdate);
            this.context.MemberContributions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MemberContributions.Where(i => i.ContributionID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Member");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberContributionCreated(Models.ConData.MemberContribution item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.MemberContribution item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMemberContributionCreated(item);
            this.context.MemberContributions.Add(item);
            this.context.SaveChanges();

            var key = item.ContributionID;

            var itemToReturn = this.context.MemberContributions.Where(i => i.ContributionID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Member");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
