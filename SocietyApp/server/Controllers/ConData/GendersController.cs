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

  [Route("odata/ConData/Genders")]
  public partial class GendersController : ODataController
  {
    private Data.ConDataContext context;

    public GendersController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Genders
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Gender> GetGenders()
    {
      var items = this.context.Genders.AsQueryable<Models.ConData.Gender>();
      this.OnGendersRead(ref items);

      return items;
    }

    partial void OnGendersRead(ref IQueryable<Models.ConData.Gender> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{GenderID}")]
    public SingleResult<Gender> GetGender(int key)
    {
        var items = this.context.Genders.Where(i=>i.GenderID == key);
        this.OnGendersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnGendersGet(ref IQueryable<Models.ConData.Gender> items);

    partial void OnGenderDeleted(Models.ConData.Gender item);

    [HttpDelete("{GenderID}")]
    public IActionResult DeleteGender(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Genders
                .Where(i => i.GenderID == key)
                .Include(i => i.Members)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Gender>(Request, items);

            var itemToDelete = items.FirstOrDefault();

            if (itemToDelete == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnGenderDeleted(itemToDelete);
            this.context.Genders.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnGenderUpdated(Models.ConData.Gender item);

    [HttpPut("{GenderID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutGender(int key, [FromBody]Models.ConData.Gender newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Genders
                .Where(i => i.GenderID == key)
                .Include(i => i.Members)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Gender>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnGenderUpdated(newItem);
            this.context.Genders.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Genders.Where(i => i.GenderID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{GenderID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchGender(int key, [FromBody]Delta<Models.ConData.Gender> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Genders.Where(i => i.GenderID == key);

            items = EntityPatch.ApplyTo<Models.ConData.Gender>(Request, items);

            var itemToUpdate = items.FirstOrDefault();

            if (itemToUpdate == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(itemToUpdate);

            this.OnGenderUpdated(itemToUpdate);
            this.context.Genders.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Genders.Where(i => i.GenderID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnGenderCreated(Models.ConData.Gender item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Gender item)
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

            this.OnGenderCreated(item);
            this.context.Genders.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/Genders/{item.GenderID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
