# 🎄 Advent of Code

[![License: MIT](https://img.shields.io/badge/License-MIT-blue)](https://github.com/ketantailor/AdventOfCode/blob/main/LICENSE) [![Build](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml/badge.svg?branch=main)](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml) ![GitHub last commit](https://img.shields.io/github/last-commit/ketantailor/AdventOfCode?label=Last%20Commit)

This repo contains my solutions for the [Advent of Code](https://adventofcode.com/) challenge. All solutions are implemented in C#.

## Years

- [![2024](https://img.shields.io/badge/2024-11_★-ffd700)](https://adventofcode.com/2024)
- [![2022](https://img.shields.io/badge/2022-12_★-ffd700)](https://adventofcode.com/2022)

## Usage

Windows PowerShell:
```powershell
$Env:AOC_SESSION = "<session_token>"

cd ~\Git\AdventOfCode
dotnet run --project src/AdventOfCode.ConsoleApp -c release -- 2024
```

Linux Bash:
```bash
export AOC_SESSION="<session_token>"

cd ~/Git/AdventOfCode
dotnet run --project src/AdventOfCode.ConsoleApp -c release -- 2024
```