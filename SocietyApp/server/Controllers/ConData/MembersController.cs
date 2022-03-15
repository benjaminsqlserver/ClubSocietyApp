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

  [Route("odata/ConData/Members")]
  public partial class MembersController : ODataController
  {
    private Data.ConDataContext context;

    public MembersController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Members
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Member> GetMembers()
    {
      var items = this.context.Members.AsQueryable<Models.ConData.Member>();
      this.OnMembersRead(ref items);

      return items;
    }

    partial void OnMembersRead(ref IQueryable<Models.ConData.Member> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MemberID}")]
    public SingleResult<Member> GetMember(Int64 key)
    {
        var items = this.context.Members.Where(i=>i.MemberID == key);
        this.OnMembersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMembersGet(ref IQueryable<Models.ConData.Member> items);

    partial void OnMemberDeleted(Models.ConData.Member item);

    [HttpDelete("{MemberID}")]
    public IActionResult DeleteMember(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Members
                .Where(i => i.MemberID == key)
                .Include(i => i.MemberContributions)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Member>(Request, items);

            var itemToDelete = items.FirstOrDefault();

            if (itemToDelete == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberDeleted(itemToDelete);
            this.context.Members.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberUpdated(Models.ConData.Member item);

    [HttpPut("{MemberID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMember(Int64 key, [FromBody]Models.ConData.Member newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Members
                .Where(i => i.MemberID == key)
                .Include(i => i.MemberContributions)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Member>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberUpdated(newItem);
            this.context.Members.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Members.Where(i => i.MemberID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,MemberPosition");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MemberID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMember(Int64 key, [FromBody]Delta<Models.ConData.Member> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Members.Where(i => i.MemberID == key);

            items = EntityPatch.ApplyTo<Models.ConData.Member>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(itemToUpdate);

            this.OnMemberUpdated(itemToUpdate);
            this.context.Members.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Members.Where(i => i.MemberID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,MemberPosition");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberCreated(Models.ConData.Member item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Member item)
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

            this.OnMemberCreated(item);
            this.context.Members.Add(item);
            this.context.SaveChanges();

            var key = item.MemberID;

            var itemToReturn = this.context.Members.Where(i => i.MemberID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Gender,MemberPosition");

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
