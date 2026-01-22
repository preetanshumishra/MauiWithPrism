# MauiWithPrism

A .NET MAUI sample demonstrating MVVM using the Prism framework with service locator pattern dependency injection.

## Overview

This project demonstrates the Prism framework approach to MVVM in .NET MAUI applications:
- **Prism Framework** - Enterprise-grade MVVM framework with navigation support
- **Service Locator Pattern** - Static `ServiceProvider` for dependency resolution
- **Navigation** - Built-in navigation services for MVVM-style routing
- **Event Aggregation** - Loosely coupled communication between view models

## Tech Stack

- .NET 10.0
- .NET MAUI 10.0.10
- Prism 9.x
- Community Toolkit MVVM 8.4.0

## Quick Start

```bash
# Build the project
dotnet build

# Run on iOS
dotnet run -f net10.0-ios

# Run on Android
dotnet run -f net10.0-android
```

## Key Features

- Prism-based MVVM with automatic view-to-ViewModel registration
- Service locator dependency injection pattern
- Navigation services for page transitions
- Event aggregator for inter-ViewModel communication
- XAML-based UI with Prism behaviors

## License

MIT License - See LICENSE file for details.
