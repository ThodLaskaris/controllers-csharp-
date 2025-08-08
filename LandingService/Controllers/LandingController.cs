using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LandingService.Helpers;
using LandingService.Models;

namespace LandingService.Controllers {


  [ApiController]
  [Route("api/[controller]")]
  public class LandingController : ControllerBase {

    [HttpPost]
    [Route("create-new")]
    [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status201Created)]
    public Task<IActionResult> CreateNew([FromBody] CreateRequest request) {
      var expiry = request.ExpiryDate ?? DateTime.UtcNow.AddYears(1);
      return Task.FromResult(ControllerHelper.HandleAction(
        $"New objected created with data: {request.Data}, quantity: {request.Quantity}, expiry: {expiry}",
        $"Created data {request.Data} qty: {request.Quantity}, expiry: {expiry}"
      ));
    }

    [HttpGet]
    [Route("get-all")]
    [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
    public Task<IActionResult> GetAll()  {
    
      return Task.FromResult(ControllerHelper.HandleAction("Fetching data..", "Fetched data for all objects"));
    }

    [HttpGet]
    [Route("get-by-id/{id:guid}")]
    [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
    public Task<IActionResult> GetById(Guid id) {
      return Task.FromResult(ControllerHelper.HandleAction("$fecthed id {id}", $"Fetched data for id {id}"));
    }

    [HttpPut]
    [Route("update/{id:guid}")]
    [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
    public Task<IActionResult> Update(Guid id, [FromBody] string data) {
      return Task.FromResult(ControllerHelper.HandleAction($"Updated object for id: {id} with data: {data}",
      $"Updated data for id {id}"));
    } 

    [HttpDelete]
    [Route("delete/{id:guid}")]
    [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
    public Task<IActionResult> Delete(Guid id) {
      return Task.FromResult(ControllerHelper.HandleAction($"Deleted object with id: {id}",
      $"Deleted data for id {id}"));
    }
    }
  }
