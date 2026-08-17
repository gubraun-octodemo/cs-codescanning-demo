using System.Diagnostics;

Console.WriteLine("Hello, World!");

// Deliberate vulnerability: untrusted input is concatenated into a shell command.
Console.Write("Enter a name: ");
var name = Console.ReadLine() ?? "World";
var shellCommand = "echo Hello, " + name;
var process = Process.Start(new ProcessStartInfo
{
    FileName = "/bin/sh",
    Arguments = "-c \"" + shellCommand + "\"",
    RedirectStandardOutput = true,
    UseShellExecute = false
});

Console.WriteLine(process?.StandardOutput.ReadToEnd());
