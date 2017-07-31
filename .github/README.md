# NRuneScape
[![MyGet](https://img.shields.io/myget/nrunescape/vpre/NRuneScape.svg?label=NRuneScape)](https://www.myget.org/feed/Packages/nrunescape) 
[![Build status](https://ci.appveyor.com/api/projects/status/f3hwgo97j5e0psxx/branch/dev?svg=true)](https://ci.appveyor.com/project/AntiTcb/nrunescape/branch/dev)

An unofficial .NET API Wrapper for RuneScape (https://runescape.com / https://oldschool.runescape.com).

Design is heavily based on [Discord.Net](https://github.com/RogueException/Discord.Net). 

## Development Roadmap
- [x] NRuneScape.Rest
- - [x] Grand Exchange
- [x] NRuneScape.OldSchool
- - [x] Hiscores
- [x] NRuneScape.RuneScape3 
- - [x] Hiscores
- - [ ] Bestiary
- - [ ] RuneMetrics
- - [ ] Solomon's 
- - [ ] Website Data

## Installation
### Development (MyGet)
Nightly builds are available on the project's MyGet feed. (<https://www.myget.org/gallery/nrunescape> / `https://www.myget.org/F/nrunescape/api/v3/index.json`)
### Stable (NuGet)
Stable releases are found on NuGet.
You may install the metapackage or, pick and choose the individual components you like.
### Unstable (NuGet)
Unstable pre-release builds will be found on NuGet, displayed by toggling the pre-releases checkbox.


## Compiling
In order to compile NRuneScape, you require:

### Using Visual Studio
- [Visual Studio 2017](https://www.microsoft.com/net/core#windowsvs2017)
- [.NET Core SDK](https://www.microsoft.com/net/download/core)

The .NET Core workload must be selected during Visual Studio installation.

### Using Command Line
- [.NET Core SDK](https://www.microsoft.com/net/download/core)
