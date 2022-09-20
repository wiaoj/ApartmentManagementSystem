using Domain.Entities;

namespace Application.Handlers.Apartments.Constants;
internal static class ApartmentMessageConstants {
    public static String Created => $"{nameof(Apartment)} has been created.";
    public static String Deleted => $"{nameof(Apartment)} has been deleted.";
    public static String Updated => $"{nameof(Apartment)} has been updated.";
    public static String NotFound => $"{nameof(Apartment)} does not exist.";
    public static String AlredyExist => $"{nameof(Apartment)} alredy exists.";
}