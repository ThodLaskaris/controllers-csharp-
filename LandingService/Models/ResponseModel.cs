using System;

namespace LandingService.Models
{
   public class ResponseModel {
    public string? ResponseMessage {get; set;}
    public Guid? Id {get; set;}
    public DateTime? CreatedAt {get; set;}
    public DateTime? UpdatedAt {get; set;}
    public IEnumerable<CreateRequest>? Payload {get; set;}
   }

public class CreateRequest {
public Guid Id {get; set;}
public string Data { get; set; }
public int Quantity {get; set;}
public DateTime? ExpiryDate {get; set;}

   }
}
