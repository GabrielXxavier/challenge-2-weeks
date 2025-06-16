namespace LibraryApi.Records;

public record PutBookRequest(string Title, string Category, int Value, string Author);