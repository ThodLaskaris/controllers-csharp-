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
        Payload = new[] {request}
      };
    }
    public static ResponseModel CreateForDelete(Guid id) {
      return new ResponseModel {
        ResponseMessage = $"Deleted data for id {id}",
        Id = id,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = null
      };
    }
    public static ResponseModel CreateForGetAll(IEnumerable<CreateRequest> items ) {
      return new ResponseModel {
        ResponseMessage = "Fetched data for all objects",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = items
      };
    }
    public static ResponseModel CreateForGetById(CreateRequest item) {
      return new ResponseModel {
        ResponseMessage = $"Fetched data for id {item?.Data}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] {item}
      };
    }
    public static ResponseModel CreateForCreateNew(CreateRequest request) {
      var expiry = request.ExpiryDate ?? DateTime.UtcNow.AddYears(1);
      return new ResponseModel {
        ResponseMessage = $"Created data {request.Data} quantity: {request.Quantity}. Expiry: {expiry}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] { request}
       };
    }
    public static ResponseModel CreateForUpdate(CreateRequest updatedItem) {
      return new ResponseModel {
        ResponseMessage = $"Updated data for id {updatedItem?.Data}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] { updatedItem}
      };
    }
  }
}