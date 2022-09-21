using Domain.Entities;

namespace Application.Handlers.Bills.Constants;
internal static class BillMessageConstants {
    public static String Created => $"{nameof(Bill)} has been created.";
    public static String Deleted => $"{nameof(Bill)} has been deleted.";
    public static String Updated => $"{nameof(Bill)} has been updated.";
    public static String NotFound => $"{nameof(Bill)} does not exist.";
    public static String AlredyExist => $"{nameof(Bill)} alredy exists.";
}