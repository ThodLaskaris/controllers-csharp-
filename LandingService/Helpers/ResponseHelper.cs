using System;
using LandingService.Models;

namespace LandingService.Helpers {

  public static class ResponseHelper {
    public static ResponseModel Create(string message, CreateRequest request, Guid? id = null) 
    {
      return new ResponseModel {
        ResponseMessage = message,
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = request
      };
    }
  }
}