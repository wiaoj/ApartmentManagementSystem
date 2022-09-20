using Domain.Entities;

namespace Application.Handlers.PhoneNumbers.Constants;
internal static class PhoneNumberMessageConstants {
    public static String Created => $"{nameof(PhoneNumber)} has been created.";
    public static String Deleted => $"{nameof(PhoneNumber)} has been deleted.";
    public static String Updated => $"{nameof(PhoneNumber)} has been updated.";
    public static String NotFound => $"{nameof(PhoneNumber)} does not exist.";
    public static String AlredyExist => $"{nameof(PhoneNumber)} alredy exists.";
}