# cs-codescanning-demo

Minimal C# hello-world application for demonstrating GitHub Code Scanning.

This project intentionally contains one vulnerability: OS command injection
in `Program.cs`, where user input is concatenated into a shell command.
Do not deploy or reuse this code.

The vulnerable flow is a test case for both CodeQL and AI-based code scanning.

## Run

```sh
dotnet run
```
