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

  [Route("odata/ConData/MemberPositions")]
  public partial class MemberPositionsController : ODataController
  {
    private Data.ConDataContext context;

    public MemberPositionsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/MemberPositions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.MemberPosition> GetMemberPositions()
    {
      var items = this.context.MemberPositions.AsQueryable<Models.ConData.MemberPosition>();
      this.OnMemberPositionsRead(ref items);

      return items;
    }

    partial void OnMemberPositionsRead(ref IQueryable<Models.ConData.MemberPosition> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{PositionID}")]
    public SingleResult<MemberPosition> GetMemberPosition(int key)
    {
        var items = this.context.MemberPositions.Where(i=>i.PositionID == key);
        this.OnMemberPositionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMemberPositionsGet(ref IQueryable<Models.ConData.MemberPosition> items);

    partial void OnMemberPositionDeleted(Models.ConData.MemberPosition item);

    [HttpDelete("{PositionID}")]
    public IActionResult DeleteMemberPosition(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.MemberPositions
                .Where(i => i.PositionID == key)
                .Include(i => i.Members)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MemberPosition>(Request, items);

            var itemToDelete = items.FirstOrDefault();

            if (itemToDelete == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberPositionDeleted(itemToDelete);
            this.context.MemberPositions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberPositionUpdated(Models.ConData.MemberPosition item);

    [HttpPut("{PositionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMemberPosition(int key, [FromBody]Models.ConData.MemberPosition newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MemberPositions
                .Where(i => i.PositionID == key)
                .Include(i => i.Members)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MemberPosition>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMemberPositionUpdated(newItem);
            this.context.MemberPositions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MemberPositions.Where(i => i.PositionID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{PositionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMemberPosition(int key, [FromBody]Delta<Models.ConData.MemberPosition> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MemberPositions.Where(i => i.PositionID == key);

            items = EntityPatch.ApplyTo<Models.ConData.MemberPosition>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(itemToUpdate);

            this.OnMemberPositionUpdated(itemToUpdate);
            this.context.MemberPositions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MemberPositions.Where(i => i.PositionID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMemberPositionCreated(Models.ConData.MemberPosition item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.MemberPosition item)
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

            this.OnMemberPositionCreated(item);
            this.context.MemberPositions.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/MemberPositions/{item.PositionID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
