using System;
using LandingService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LandingService.Helpers {
  public static class ErrorHelper {
    public static ResponseModel CreateErrorResponse(string message) {
      return new ResponseModel {
        ResponseMessage = $"Error: {message}",
        Id = Guid.Empty,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
      };
    }
  }
}
