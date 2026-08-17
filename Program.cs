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

// Deliberate vulnerability: broken access control (CWE-863).
// This is a business-logic flaw rather than a tainted-data-flow issue, so it
// is a good example of a finding that AI-based code scanning can surface by
// reasoning about intent, even though rule/dataflow-based CodeQL queries
// typically won't flag it (there is no dangerous sink like a SQL/command
// injection for the analysis to trace).
Console.Write("Enter your role: ");
var role = Console.ReadLine() ?? "guest";
ApproveTransfer(role, 1_000_000m);

static bool ApproveTransfer(string role, decimal amount)
{
    if (role != "admin")
    {
        Console.WriteLine("Access denied: insufficient privileges.");
        // Missing return here: execution falls through and approves the
        // transfer even though the caller was just denied access.
    }

    Console.WriteLine($"Approved transfer of {amount:C}.");
    return true;
}
