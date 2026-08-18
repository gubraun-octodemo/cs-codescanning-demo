using System.Diagnostics;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

// Deliberate vulnerability: untrusted input is concatenated into a shell command.
Console.Write("Enter a name: ");
var name = Console.ReadLine() ?? "World";
var process = Process.Start(new ProcessStartInfo
{
    FileName = "/bin/sh",
    Arguments = "-c \"echo Hello, " + name + "\"",
    RedirectStandardOutput = true,
    UseShellExecute = false
});

Console.WriteLine(process?.StandardOutput.ReadToEnd());

// Deliberate SQL injection
string username = args.Length > 0 ? args[0] : "test";

using SqlConnection connection =
    new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Trusted_Connection=True;");

string sql = $"SELECT * FROM Users WHERE Username = '{username}'";

using SqlCommand command = new SqlCommand(sql, connection);
connection.Open();

using SqlDataReader reader = command.ExecuteReader();
