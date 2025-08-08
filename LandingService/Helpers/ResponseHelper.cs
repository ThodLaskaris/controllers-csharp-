using System;
using LandingService.Models;
using System.Linq;

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
    public static ResponseModel CreateForGetAll(IEnumerable<CreateRequest> items)
{
    var payload = items.Select(item => new CreateRequest
    {
        Id = item.Id,
        Data = item.Data,
        Quantity = item.Quantity,
        ExpiryDate = item.ExpiryDate ?? DateTime.UtcNow.AddYears(1)
    }).ToList();

    return new ResponseModel
    {
        ResponseMessage = "Fetched data for all objects",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = payload
    };
}
public static ResponseModel CreateForGetById(CreateRequest item) {
    var expiry = item.ExpiryDate ?? DateTime.UtcNow.AddYears(1);
    var payloadItem = new CreateRequest {
        Id = item.Id,
        Data = item.Data,
        Quantity = item.Quantity,
        ExpiryDate = expiry
    };
    return new ResponseModel {
        ResponseMessage = $"Fetched data for id {item?.Data}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] { payloadItem }
    };
}
    public static ResponseModel CreateForCreateNew(CreateRequest request) {
      var expiry = request.ExpiryDate ?? DateTime.UtcNow.AddYears(1);
      var payloadRequest = new CreateRequest {
        Id = request.Id,
        Data = request.Data,
        Quantity = request.Quantity,
        ExpiryDate = expiry

      };
      return new ResponseModel {
        ResponseMessage = $"Created data {request.Data} quantity: {request.Quantity}. Expiry: {expiry:yyyyMMddHHmmssfffzzz}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] { payloadRequest}
       };
    }
public static ResponseModel CreateForUpdate(CreateRequest updatedItem) {
    var expiry = updatedItem.ExpiryDate ?? DateTime.UtcNow.AddYears(1);
    var payloadItem = new CreateRequest {
        Id = updatedItem.Id,
        Data = updatedItem.Data,
        Quantity = updatedItem.Quantity,
        ExpiryDate = expiry
    };
    return new ResponseModel {
        ResponseMessage = $"Updated data for id {updatedItem?.Data}",
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        Payload = new[] { payloadItem }
    };
}
  }
}