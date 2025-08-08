using System;
using LandingService.Models;
using LandingService.Helpers;
using Microsoft.AspNetCore.Mvc;



namespace LandingService.Controllers {
  // public static class ControllerHelper {
  //   public static IActionResult HandleAction(string logMessage, string responseMessage) {
  //     LogHelper.Log(logMessage);
  //     return new OkObjectResult(ResponseHelper.Create(responseMessage));

  //   }

  public static class ControllerHelper {
    public static IActionResult HandleCreateNew(CreateRequest request) {
      var expiry = request.ExpiryDate ?? 
    }
  }
}
  
