using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

Console.Write("Enter a name: ");
var name = Console.ReadLine() ?? "World";
Console.WriteLine($"Hello, {name}");

string username = args.Length > 0 ? args[0] : "test";

using SqlConnection connection =
    new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Trusted_Connection=True;");

string sql = "SELECT * FROM Users WHERE Username = @username";

using SqlCommand command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@username", username);
connection.Open();

using SqlDataReader reader = command.ExecuteReader();
