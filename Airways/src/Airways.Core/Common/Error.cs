
namespace Airways.Core.Common;
public record Error(string code, string message)
{
    public static Error None = new Error(string.Empty, string.Empty);

    public static Error NullValue = new Error("Error.NullValue", "Null value was provided");
    public static Error DataBaseError = new Error("Error.DataBaseError", "There is some problem with the DataBase");
    public static Error BadRequest = new Error("Error.BadRequest", "Somewhere the query didn't work");
    public static Error NotFound = new Error("Error.NotFound", "NotFound");
    public static Error Unauthorized = new Error("Error.Unauthorized", "Unauthorized");
    public static Error Forbidden = new Error("Error.Forbidden", "Forbidden");
    public static Error Conflict = new Error("Error.Conflict", "Conflict");
    public static Error InternalServerError = new Error("Error.InternalServerError", "Internal Server Error");
    public static Error LoginFaild = new Error("Error.LoginFaild", "Username or Password is incorrect");
    public static Error TechnicalWorks = new Error("Error.TechnicalWorks", "Ushbu Apida texnik ishlar olib borilmoqda");
    public static Error DatabaseError = new Error("Error.DatabaseError", "Database error");
    public static Error InvalidOperation = new Error("Error.InvalidOperation", "Invalid operation");
    public static Error TimeSlotOverlap = new Error("Error.TimeSlotOverlap", "Time slot overlaps with existing appointment");
    public static Error ScheduleHasAppointments = new Error("Error.ScheduleHasAppointments", "Schedule has appointments");
    public static Error TimeSlotNotAvailable = new Error("Error.TimeSlotNotAvailable", "Time slot is not available");

}

