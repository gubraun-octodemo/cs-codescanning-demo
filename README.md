# cs-codescanning-demo

Minimal C# hello-world application for demonstrating GitHub Code Scanning.

This project intentionally contains vulnerabilities for testing GitHub Code
Scanning, both CodeQL-based and AI-based detection:

1. **OS command injection** (CWE-78) in `Program.cs`, where user input is
   concatenated into a shell command.
2. **Path traversal** (CWE-22) in `Program.cs`, where user input is combined
   into a file path without validation, allowing access to files outside the
   intended `logs` directory (e.g. via `../` sequences).

Do not deploy or reuse this code.

## Run

```sh
dotnet run
```
