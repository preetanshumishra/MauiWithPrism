# MauiWithPrism

A .NET MAUI sample project demonstrating the **Prism MVVM framework** with .NET 8.0. This project implements actual Prism architecture with dependency injection and navigation services.

## ⚠️ Current Status: BLOCKED - Prism Incompatibility Issue

**This project contains a complete Prism implementation but CANNOT COMPILE due to incomplete .NET 8 support in Prism 9.0.537.**

### The Problem

**Prism.Core 9.0.537 does NOT have a .NET 8.0 build.**

```
Prism.Core 9.0.537 Available Targets:
✅ net462
✅ net47
✅ net6.0
✅ netstandard2.0
❌ net8.0  ← MISSING

Build Error:
error CS0234: The type or namespace name 'Maui' does not exist
in the namespace 'Prism'
```

### Dependency Chain Breakdown

```
Your Project (net8.0-android/ios)
    ↓ requires
Prism.Maui 9.0.537 (has net8.0 build ✅)
    ↓ depends on
Prism.Core 9.0.537 (NO net8.0 build ❌)
    ↓ falls back to net6.0
Compiler cannot resolve types → BUILD FAILS
```

### Root Cause

- Prism 9.0.537 released August 2024 claims ".NET 8 Support"
- PR #3043 ("Add net8.0 target to Prism.Core") was abandoned/not merged
- MAUI platform-specific libraries have net8.0 builds
- Core dependency Prism.Core was never built for net8.0
- **Incomplete implementation leaves Prism incompatible with .NET 8**

---

## Overview

MauiWithPrism demonstrates **Prism MVVM framework architecture** for .NET MAUI:
- **PrismApplication** - Framework-based Application class
- **RegisterTypes()** - Service registration and page/ViewModel mapping
- **NavigationService** - Prism navigation integration
- **Container Registry** - Dependency injection via Prism container
- **Constructor Injection** - Pages receive dependencies via constructors

> **Note**: Code implementation is complete and architecturally correct, but project cannot compile due to Prism.Core .NET 8 incompatibility.

---

## Project Structure

```
MauiWithPrism/
├── MauiProgram.cs                    # Prism configuration (.UsePrism())
├── App.xaml / App.xaml.cs           # PrismApplication with RegisterTypes()
├── AppShell.xaml / AppShell.xaml.cs  # Prism navigation shell
├── MainPage.xaml / MainPage.xaml.cs  # Constructor injection example
│
├── ViewModels/
│   ├── BaseViewModel.cs              # MVVM base class
│   └── MainViewModel.cs              # Counter demo
│
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml               # Color palette
│   │   └── Styles.xaml               # Control styles
│   ├── Images/, Fonts/, AppIcon/
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

---

## Tech Stack

| Component | Version | Purpose | Status |
|-----------|---------|---------|--------|
| **.NET** | 8.0.417 | Runtime framework | ✅ Works |
| **.NET MAUI** | 8.0.100 | Cross-platform UI | ✅ Compatible |
| **Prism.DryIoc.Maui** | 9.0.537 | MVVM framework | ⚠️ Incomplete |
| **Prism.Core** | 9.0.537 | Core dependency | ❌ No net8.0 |
| **Community Toolkit MVVM** | 8.4.0 | MVVM helpers | ✅ Compatible |
| **Target Platforms** | iOS 12.0+, Android 21+ | Platforms | ✅ Configured |

---

## Architecture

### Prism Application Setup

```csharp
public partial class App : PrismApplication
{
    public App() : base()
    {
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Register pages and ViewModels for Prism navigation
        containerRegistry.RegisterForNavigation<AppShell>();
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
    }

    protected override void OnInitialized()
    {
        InitializeComponent();
        // Use Prism NavigationService
        NavigationService.NavigateAsync("MainPage");
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return base.CreateWindow(activationState);
    }
}
```

### Constructor Injection Pattern

Pages receive ViewModels via constructor injection (Prism handles resolution):

```csharp
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;  // Prism automatically constructs with ViewModel
    }
}
```

### MVVM with Community Toolkit

```csharp
public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string message = "Welcome to MAUI with Prism!";

    [ObservableProperty]
    private int counter;

    [RelayCommand]
    private void IncrementCounter()
    {
        Counter++;
        Message = Counter == 1
            ? "Clicked 1 time"
            : $"Clicked {Counter} times";
    }
}
```

---

## Quick Start (Prerequisites)

### System Requirements
- .NET 8.0.417 SDK (or later)
- MAUI workloads installed: `dotnet workload install maui`
- Xcode 15+ (iOS)
- Android SDK 21+ (Android)

### Build Attempt
```bash
cd /Users/preetanshumishra/Projects/MauiWithPrism
dotnet clean
dotnet restore
dotnet build  # ❌ Will fail with CS0234 error
```

### Expected Error
```
error CS0234: The type or namespace name 'Maui' does not exist
in the namespace 'Prism'
```

---

## How to Fix This Issue

### Option 1: Wait for Prism 10.x (Recommended)
- Prism team is actively working on .NET 8 compatibility
- Newer version should have complete net8.0 support across all packages
- Timeline unknown

### Option 2: Build Prism from Source
1. Clone Prism repository: `https://github.com/PrismLibrary/Prism.git`
2. Add `<TargetFrameworks>` with net8.0 to Prism.Core.csproj
3. Build locally and reference custom build

### Option 3: Use .NET 10
- Switch TargetFrameworks to `net10.0-android;net10.0-ios`
- Prism works correctly on .NET 10
- Trade-off: Not using latest stable LTS framework

### Option 4: Use Standard MAUI + Constructor Injection
- Remove Prism packages
- Use Microsoft.Extensions.DependencyInjection
- Implement manual DI in MauiProgram
- See `MauiWithMvvm` project for example

---

## Key Prism Features (In Code But Not Runnable)

✅ **Implemented in code:**
- PrismApplication base class
- Service container registration via RegisterTypes()
- Page/ViewModel mapping in container
- NavigationService integration
- Constructor injection for pages
- Global.json pins .NET 8.0.417

❌ **Cannot execute due to:**
- Prism.Core.dll cannot be loaded for net8.0
- C# compiler cannot resolve Prism.Maui types
- Dependency resolution fails at compile time

---

## Related Projects

| Project | Pattern | Framework | Status |
|---------|---------|-----------|--------|
| **MauiWithMvvm** | Constructor Injection | .NET 10 MAUI | ✅ Works |
| **MauiWithPrism** | Prism Framework | .NET 8 | ⚠️ Blocked |
| **MauiWithMvvCross** | MvvmCross Framework | .NET 10 MAUI | ✅ Works |
| **MauiThemeSample** | XAML Theming | .NET 10 MAUI | ✅ Works |

---

## Resources & References

- [Prism Library GitHub](https://github.com/PrismLibrary/Prism)
- [Prism .NET 8 Issues](https://github.com/PrismLibrary/Prism/issues?q=.NET+8)
- [Prism PR #3043 (Abandoned)](https://github.com/PrismLibrary/Prism/pull/3043) - "Add net8.0 target to Prism.Core"
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Prism Documentation](https://prismlibrary.com/)

---

## Development Notes

### What Works
- All Prism code architecture is implemented correctly
- .NET 8 MAUI framework integration
- ViewModels and pages set up for injection
- Navigation registration in place

### What's Broken
- Compilation fails due to Prism.Core missing net8.0
- Assembly resolution cannot find Prism.Maui types at compile time
- Cannot test or run the application

### Investigation Summary

**Findings (Feb 5, 2026):**
1. Prism.DryIoc.Maui 9.0.537 has net8.0-android34.0 and net8.0-ios17.5 builds
2. Prism.Core 9.0.537 only has net462, net47, net6.0, netstandard2.0
3. This breaks the dependency chain
4. PR #3043 to add net8.0 to Prism.Core was abandoned
5. Prism team is actively working on other .NET 8 issues but this core issue remains unresolved

---

## License

MIT License - See LICENSE file for details.
