# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a console-based Snake game written in C# targeting .NET 8.0. The game follows classic Snake mechanics where players control a snake to collect apples while avoiding walls and self-collision, with progressive difficulty across levels.

## Essential Commands

### Build and Run
```bash
# Run the game
dotnet run

# Build without running
dotnet build

# Build in Release mode
dotnet build -c Release

# Clean build artifacts
dotnet clean
```

### Development Setup
```bash
# Restore NuGet packages
dotnet restore

# Run with hot reload (for development)
dotnet watch run
```

## Architecture Overview

The codebase follows a modular, layered architecture with dependency injection and clear separation of concerns:

### Core Game Flow
- **Entry Point**: `Program.cs` sets up DI container via `GameDependencyConfig` and launches `SnakeGameController`
- **Game Controller**: `Controllers/SnakeGameController.cs` orchestrates the entire game:
  - Runs dual async tasks for rendering (10ms cycle) and input handling
  - Manages game state transitions between menu, play, and end screens
  - Subscribes to Snake entity events (Win/Dead) to handle level progression

### Key Architectural Components

1. **Entity System** (`Entities/`)
   - `GameEntity` abstract base class manages coordinates and events
   - `Snake` implementation handles movement via `SnakeMover` strategy
   - Movement validation through `SnakeChecker` (wall/self collision detection)

2. **Level System** (`Levels/`)
   - `Level` abstract class stores map as 2D string array
   - `DefaultLevelFactory` generates 16x16 grid levels with configurable apple counts
   - Map symbols: `#` (wall), `@` (snake head), `*` (body), `●` (apple), ` ` (empty)

3. **UI Layer** (`UI/`)
   - Facade pattern via `DefaultGameUIFacade` abstracts rendering complexity
   - Separate renderers for Menu, Frame (gameplay), Settings, and EndScreen
   - Color-coded console output with UTF-8 character support

4. **Game Logic** (`Checkers/` and `Spawners/`)
   - `AppleSpawner` generates random apple positions avoiding collisions
   - `AppleChecker` validates collection and plays sound effects
   - `SnakeChecker` determines win/death conditions

5. **Audio System** (`Audio/`)
   - `WavSoundManager` using NAudio library (Windows-only)
   - Sound files in `Game Sounds/` directory for UI navigation and game events

### Dependency Injection Setup
All services are registered as singletons in `GameDependencyConfig.cs`. Key registrations include entity checkers, spawners, UI renderers, level factory, and sound manager.

### Game Loop Mechanics
- 10ms render cycle displaying map, snake, apple, and score
- Snake moves continuously in current direction (WASD controls)
- Apple collection triggers growth and spawns new apple
- Level progression: 5 apples (Level 1), 10 apples (Level 2), +5 per level
- Events trigger UI transitions (win screen, lose screen, menu return)

## Important Implementation Details

### Snake Movement
- `SnakeMover` prevents immediate direction reversal (can't go directly from Up to Down)
- Smart collision detection with both walls and self
- Growth adds new tail segment at previous tail position

### Level Generation
- Default preset has snake starting center-screen, vertically oriented
- `ArrayHelper.Clone2DArray()` duplicates level preset to preserve original
- Each level increases required apple count by 5

### Console Rendering
- `TextScreenPrinter` utility centers text on screen
- `DefaultGameFrameRenderer` calculates center position for map display
- Colors applied per character: Green (snake), Red (apple), White (walls)

### Sound Integration
- NAudio requires Windows OS for WAV playback
- Sounds triggered on: menu navigation, apple collection, level win/loss
- Files must be copied to output directory (configured in .csproj)

## Development Notes

- The project uses nullable reference types (`<Nullable>enable</Nullable>`)
- Thread.Sleep(Timeout.Infinite) in Program.cs keeps console app alive
- CancellationTokenSource manages async task lifecycle during gameplay
- No test project exists currently - consider adding unit tests for game logic