using System;


namespace LandingService.Helpers {
  public static class LogHelper {
    public static void Log(string message) {
      Console.WriteLine($"[{DateTime.UtcNow}] {message}");
    }
  }
}