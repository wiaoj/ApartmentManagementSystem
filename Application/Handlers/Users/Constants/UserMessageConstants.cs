using Domain.Entities;

namespace Application.Handlers.Users.Constants;
internal static class UserMessageConstants {
    public static String Created => $"{nameof(User)} has been created.";
    public static String Deleted => $"{nameof(User)} has been deleted.";
    public static String Updated => $"{nameof(User)} has been updated.";
    public static String NotFound => $"{nameof(User)} does not exist.";
    public static String AlredyExist => $"{nameof(User)} alredy exists.";
}