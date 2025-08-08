using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LandingService.Helpers;
using LandingService.Models;

namespace LandingService.Controllers {


  [ApiController]
  [Route("api/[controller]")]
  public class LandingController : ControllerBase {
   private static readonly List<CreateRequest> _items = new List<CreateRequest>();

   [HttpPost]
   [Route("create-new")]
   [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status201Created)]

   public Task<IActionResult> CreateNew([FromBody] CreateRequest request) {
    request.Id = Guid.NewGuid();
    _items.Add(request);
    return Task.FromResult(ControllerHelper.HandleCreateNew(request));
   }

   [HttpGet]
   [Route("get-all")]
   [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200Ok)]
    
    public Task<IActionResult> GetAll() {
      return Task.FromResult(ControllerHelper.HandleGetAll(_items));
    }

   [HttpGet]
   [Route("get-by-id/{id:guid}")]
   [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200Ok)]

   public Task<IActionResult> GetById(Guid id) {
    // Waiting to implemnet
   } 

  [HttpPut]
  [Route("updated/{id:guid}")]
  [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200Ok)]

  public Task<IActionResult> Update(Guid id, [FromBody] CreateRequest requestUpdated) {
    return Task.FromResult(ControllerHelper.HandleUpdate(_items, id, requestUpdated));
  }

  [HttpDelete]
  [Route("delete/{id:guid}")]
  [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200Ok)]

  public Task<IActionResult> Delete(Guid id) {
    // waiting to implement.
  }
























   
    }
}