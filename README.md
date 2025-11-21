# MauiWithPrism

A .NET MAUI mobile application demonstrating MVVM (Model-View-ViewModel) architecture with Dependency Injection and clean architecture principles.

## Features

- **MVVM Architecture**: Clean separation of concerns using the Community Toolkit MVVM framework
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection for managing application dependencies
- **Service Locator Pattern**: Static ServiceProvider for elegant service resolution
- **Observable Properties**: Automatic UI updates using the MVVM Toolkit's `[ObservableProperty]` attribute
- **Relay Commands**: Type-safe command implementation with `[RelayCommand]` attribute
- **Multi-Platform Support**: Runs on Android and iOS
- **Counter Functionality**: Interactive counter demo with dynamic message updates

## Project Structure

```
MauiWithPrism/
├── ViewModels/
│   ├── BaseViewModel.cs          # Abstract base class for all ViewModels
│   └── MainViewModel.cs          # ViewModel for MainPage with counter logic
├── MainPage.xaml                 # Main UI page
├── MainPage.xaml.cs              # Code-behind with service resolution
├── App.xaml                      # Application resources
├── App.xaml.cs                   # App startup with DI resolution
├── AppShell.xaml                 # Navigation shell
├── MauiProgram.cs                # DI configuration and app startup
├── LICENSE                       # MIT License
└── README.md                     # This file
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2022, Visual Studio Code, or JetBrains Rider
- Android SDK (for Android builds)
- Xcode (for iOS builds on macOS)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build for all platforms
dotnet build

# Build for specific platform
dotnet build -f net10.0-android
dotnet build -f net10.0-ios
```

### Running the Application

```bash
# Run on Android emulator
dotnet run -f net10.0-android

# Run on iOS simulator
dotnet run -f net10.0-ios
```

## MVVM Implementation

### BaseViewModel

The `BaseViewModel` class serves as the foundation for all ViewModels in the application:

```csharp
[ObservableProperty]
private bool isBusy;

[ObservableProperty]
private string title = string.Empty;
```

### MainViewModel

The `MainViewModel` demonstrates:

- Observable properties for data binding
- Relay commands for user interactions
- Counter functionality with dynamic message updates

```csharp
[ObservableProperty]
private string _message = "Welcome to MAUI with Prism!";

[ObservableProperty]
private int _counter;

[RelayCommand]
private void IncrementCounter()
{
    Counter++;
    Message = Counter == 1
        ? "Clicked 1 time"
        : $"Clicked {Counter} times";
}
```

## Dependency Injection

Services are registered and configured in `MauiProgram.cs`:

```csharp
var services = new ServiceCollection();

services.AddSingleton<AppShell>();
services.AddSingleton<MainPage>();
services.AddSingleton<MainViewModel>();

var serviceProvider = services.BuildServiceProvider();
MauiProgram.ServiceProvider = serviceProvider;
```

The static `ServiceProvider` allows for elegant service resolution throughout the application:

```csharp
// In App.xaml.cs
var appShell = MauiProgram.ServiceProvider.GetRequiredService<AppShell>();

// In MainPage.xaml.cs
BindingContext = MauiProgram.ServiceProvider.GetRequiredService<MainViewModel>();
```

## Architecture Patterns

### Service Locator Pattern

This project uses the Service Locator pattern for resolving dependencies:

```csharp
public static IServiceProvider ServiceProvider { get; private set; }
```

This approach provides flexibility and simplicity for MAUI applications, though constructor injection (as seen in MauiWithMvvm) is also a valid pattern.

## Technologies Used

- **.NET MAUI**: Cross-platform mobile framework
- **Community Toolkit MVVM**: MVVM implementation with source generators
- **Microsoft.Extensions.DependencyInjection**: Dependency injection container
- **C# 13**: Latest language features

## Supported Platforms

- Android 21.0+
- iOS 15.0+

## License

MIT License - See LICENSE file for details

## Author

Preetanshu Mishra
