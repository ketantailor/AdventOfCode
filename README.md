# 🎄 Advent of Code

[![License: MIT](https://img.shields.io/badge/License-MIT-blue)](https://github.com/ketantailor/AdventOfCode/blob/main/LICENSE) [![Build](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml/badge.svg?branch=main)](https://github.com/ketantailor/AdventOfCode/actions/workflows/build.yaml)

This repo contains my solutions for the [Advent of Code](https://adventofcode.com/) challenge. All solutions are implemented in C#.

Year     | Stars&nbsp;
-------- | ----:
**2024** | 11 ⭐
**2022** | 12 ⭐
**2021** | 10 ⭐
**2019** | 4 ⭐
**2015** | 12 ⭐

## Usage

Windows PowerShell:
```powershell
$Env:AOC_SESSION = "<session_token>"

cd ~\Git\AdventOfCode\src
dotnet run --project AdventOfCode.ConsoleApp -c release -- 2024
```

Linux Bash:
```bash
export AOC_SESSION="<session_token>"

cd ~/Git/AdventOfCode/src
dotnet run --project AdventOfCode.ConsoleApp -c release -- 2024

# run unit tests
dotnet test AdventOfCode.slnx --verbosity minimal
```
```


## Notes

This project follows the [automation guidelines](https://www.reddit.com/r/adventofcode/wiki/faqs/automation) on the [/r/adventofcode](https://www.reddit.com/r/adventofcode) community wiki. Specifically:
- Once inputs are downloaded, they are cached locally (InputProvider.GetInput())
- The User-Agent header in InputProvider is set to the name of this repo.
- There is no polling implemented in this repository for which throttling would be required.
