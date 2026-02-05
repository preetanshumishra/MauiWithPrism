# MauiWithPrism

A .NET MAUI sample demonstrating MVVM using service locator pattern dependency injection with `Microsoft.Extensions.DependencyInjection`. This project illustrates an alternative approach to MVVM in .NET MAUI by using a static `ServiceProvider` for global service access.

## Overview

MauiWithPrism demonstrates **the service locator approach to MVVM** in .NET MAUI:
- **Service Locator Pattern** - Static `ServiceProvider` for dependency resolution
- **Microsoft.Extensions.DependencyInjection** - Modern DI framework
- **Simple Bootstrapping** - Easy setup for sample applications
- **Global Service Access** - Access services from anywhere without constructor injection
- **Community Toolkit MVVM** - Modern MVVM attributes and source generators

> **Note**: While named "WithPrism", this project uses Microsoft.Extensions.DependencyInjection with a service locator pattern rather than the Prism framework itself. This approach works well for samples and demos.

## Project Structure

```
MauiWithPrism/
├── MauiProgram.cs                    # DI setup with static ServiceProvider
├── App.xaml / App.xaml.cs           # Global resources & styling
├── AppShell.xaml / AppShell.xaml.cs  # Shell-based navigation
├── MainPage.xaml / MainPage.xaml.cs  # Main UI page
│
├── ViewModels/
│   ├── BaseViewModel.cs              # Base with IsBusy, Title
│   └── MainViewModel.cs              # Counter demo
│
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml               # Color palette
│   │   └── Styles.xaml               # 20+ control styles
│   ├── Images/ / Fonts/ / AppIcon/
│   └── Splash/
│
└── Platforms/
    ├── iOS/
    │   ├── AppDelegate.cs
    │   └── Program.cs
    └── Android/
        ├── MainActivity.cs
        └── MainApplication.cs
```

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 10.0 | Runtime framework |
| **.NET MAUI** | 10.0.10 | Cross-platform UI |
| **Community Toolkit MVVM** | 8.4.0 | MVVM generators |
| **Microsoft.Extensions.DependencyInjection** | 10.0.0 | DI container |
| **Target Platforms** | iOS 15.0+, Android 21+ | Supported platforms |

## Architecture

### Service Locator Pattern

Uses a static `ServiceProvider` for global service access:

```csharp
public static class MauiProgram
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    public static MauiApp CreateMauiApp()
    {
        var services = new ServiceCollection();
        services.AddSingleton<AppShell>();
        services.AddSingleton<MainPage>();
        services.AddSingleton<MainViewModel>();

        var app = builder.Build();
        ServiceProvider = app.Services;  // Store globally
        return app;
    }
}
```

### Service Resolution in Views

```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // Resolve from global ServiceProvider
        BindingContext = MauiProgram.ServiceProvider.GetService<MainViewModel>();
    }
}
```

### MVVM Implementation

**BaseViewModel**:
- Inherits from `ObservableObject` (Community Toolkit)
- Provides `IsBusy` and `Title` properties
- Base for all ViewModels

**MainViewModel**:
- `[ObservableProperty]` for automatic notifications
- `[RelayCommand]` for automatic command generation
- Counter and message properties

### Key Differences: Service Locator vs Constructor Injection

| Aspect | Service Locator | Constructor Injection |
|--------|-----------------|----------------------|
| **Dependency Visibility** | Hidden | Explicit |
| **Testability** | Lower | Higher |
| **Simplicity** | More simple | More setup |
| **Best For** | Samples, demos | Production apps |
| **Coupling** | Tight | Loose |

## Key Features

- **Service Locator Pattern** - Global access to registered services
- **Observable Properties** - Via `[ObservableProperty]` attributes
- **Relay Commands** - Via `[RelayCommand]` attributes
- **Theme Support** - Light/dark themes with `AppThemeBinding`
- **Responsive Design** - Mobile-first layouts
- **Accessibility** - Semantic properties
- **Cross-Platform** - iOS and Android support

## Quick Start

### Prerequisites
- .NET 10.0 SDK
- Xcode 15+ (iOS)
- Android SDK 21+ (Android)

### Build & Run

```bash
dotnet restore
dotnet build

# iOS Simulator
dotnet run -f net10.0-ios

# Android Emulator
dotnet run -f net10.0-android

# Production build
dotnet publish -f net10.0-ios -c Release
dotnet publish -f net10.0-android -c Release
```

## MVVM Examples

### Observable Properties
```csharp
[ObservableProperty]
private int counter = 0;

[ObservableProperty]
private string message = "Click me";
```

### Relay Commands
```csharp
[RelayCommand]
private void IncrementCounter()
{
    Counter++;
    Message = $"Clicked {Counter} times";
}
```

### XAML Binding
```xml
<Label Text="{Binding Message}" />
<Button Command="{Binding IncrementCounterCommand}" />
```

## Styling

**Color Palette** (`Resources/Styles/Colors.xaml`):
- **Primary**: #512BD4 (Purple)
- **Secondary**: #DFD8F7 (Light Purple)
- **Tertiary**: #2B0B98 (Dark Purple)
- **Grayscale**: Gray100-Gray950

**Theme Support**:
```xml
<AppThemeBinding Light="White" Dark="#1F1F1F" />
```

## Extending the Project

### Adding Services

1. Define service interface
2. Implement the service
3. Register in `MauiProgram.cs`:
   ```csharp
   services.AddSingleton<IMyService, MyService>();
   ```
4. Resolve in views:
   ```csharp
   var service = MauiProgram.ServiceProvider.GetService<IMyService>();
   ```

### Adding ViewModels

1. Create class inheriting from `BaseViewModel`
2. Use `[ObservableProperty]` and `[RelayCommand]`
3. Register in `MauiProgram.cs`
4. Resolve in code-behind

## Best Practices

1. ✅ Register services once in `MauiProgram.cs`
2. ✅ Use `GetRequiredService` for mandatory services
3. ✅ Handle null returns from `GetService` gracefully
4. ✅ Document service dependencies clearly
5. ✅ Avoid circular dependencies
6. ✅ Use meaningful names for services
7. ✅ Keep service registration organized

## When to Use This Pattern

**Good for**:
- Sample projects
- Proof of concepts
- Simple applications
- Learning MVVM

**Consider alternatives for**:
- Large production apps
- Complex dependencies
- High testability requirements
- Enterprise systems

## Resources

- [Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Community Toolkit MVVM](https://learn.microsoft.com/en-us/windows/communitytoolkit/mvvm/)
- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)

## License

MIT License - See LICENSE file for details.
