# 🎄 Advent of Code

[![License: MIT](https://img.shields.io/badge/License-MIT-blue)](https://github.com/ketantailor/AdventOfCode/blob/main/LICENSE) [![Build](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml/badge.svg?branch=main)](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml)

This repo contains my solutions for the [Advent of Code](https://adventofcode.com/) challenge. All solutions are implemented in C#.

## Years

Year     | Stars
-------- | ----
**2024** | 11⭐
**2022** | 11⭐
**2019** | 11⭐
**2015** | 11⭐

## Usage

Windows PowerShell:
```powershell
$Env:AOC_SESSION = "<session_token>"

cd ~\Git\AdventOfCode
dotnet run --project src\AdventOfCode.ConsoleApp -c release -- 2024
```

Linux Bash:
```bash
export AOC_SESSION="<session_token>"

cd ~/Git/AdventOfCode
dotnet run --project src/AdventOfCode.ConsoleApp -c release -- 2024
```