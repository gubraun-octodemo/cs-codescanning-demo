using System.Diagnostics;

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

// Deliberate vulnerability: untrusted input is used to build a file path
// without validation, allowing path traversal outside the intended directory.
Console.Write("Enter a log file name to read: ");
var fileName = Console.ReadLine() ?? "app.log";
var logsDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
var filePath = Path.Combine(logsDirectory, fileName);

if (File.Exists(filePath))
{
    Console.WriteLine(File.ReadAllText(filePath));
}
else
{
    Console.WriteLine($"Log file '{fileName}' not found.");
}
