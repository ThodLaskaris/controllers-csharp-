using System;
using LandingService.Models;
using LandingService.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace LandingService.Helpers {
  public static class ControllerHelper {
   public static IActionResult Handle<T>(T payload, Func<T, ResponseModel> responseFunc) {
    var response = responseFunc(payload);
    LogHelper.Log(response.ResponseMessage ?? "Action executed");
    return new OkObjectResult(response);
   }

   public static IActionResult HandleCreateNew(CreateRequest request) {
    return Handle(request, ResponseHelper.CreateForCreateNew);
   }
   public static IActionResult HandleGetAll(IEnumerable<CreateRequest> items) {
    return Handle(items, ResponseHelper.CreateForGetAll);
   }
   public static IActionResult HandleGetById(CreateRequest item) {
    return Handle(item, ResponseHelper.CreateForGetById);
   }

   public static IActionResult HandleDelete(Guid id) {
    return Handle(id, ResponseHelper.CreateForDelete);
   }

     public static IActionResult HandleUpdate(List<CreateRequest> items, Guid id, CreateRequest updated) {
      var item = items.Find(x => x.Id == id);
      if (item != null) {
        item.Quantity = updated.Quantity;
        item.ExpiryDate = updated.ExpiryDate;
        item.Data = updated.Data; 
        return Handle(item, ResponseHelper.CreateForUpdate);
    }
    return new NotFoundObjectResult(
      ErrorHelper.CreateErrorResponse($"Item with id {id} not found")
    );
    }
  }
}