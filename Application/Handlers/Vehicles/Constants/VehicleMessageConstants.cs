using Domain.Entities;

namespace Application.Handlers.Vehicles.Constants;
internal static class VehicleMessageConstants {
    public static String Created => $"{nameof(Vehicle)} has been created.";
    public static String Deleted => $"{nameof(Vehicle)} has been deleted.";
    public static String Updated => $"{nameof(Vehicle)} has been updated.";
    public static String NotFound => $"{nameof(Vehicle)} does not exist.";
    public static String AlredyExist => $"{nameof(Vehicle)} alredy exists.";
}