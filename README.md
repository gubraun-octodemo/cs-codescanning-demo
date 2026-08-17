# cs-codescanning-demo

Minimal C# hello-world application for demonstrating GitHub Code Scanning.

This project intentionally contains vulnerabilities for demonstrating GitHub
Code Scanning:

- OS command injection in `Program.cs`, where user input is concatenated
  into a shell command. This is a classic tainted-data-flow issue that
  CodeQL's rule-based queries are well suited to detect.
- Broken access control (`ApproveTransfer` in `Program.cs`), where a denied
  authorization check is missing a `return` and execution falls through to
  perform the privileged action anyway. This is a business-logic flaw with
  no dangerous data-flow sink, making it a good example of the kind of
  finding AI-based code scanning can surface by reasoning about intent,
  even where traditional CodeQL queries typically won't flag it.

Do not deploy or reuse this code.

## Run

```sh
dotnet run
```
