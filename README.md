# MauiWithPrism

A .NET MAUI sample app using Prism with a page-first navigation setup.

## Current Status

- Project target frameworks: `net10.0-android;net10.0-ios`
- Prism setup: `Prism.DryIoc.Maui` (`9.0.537`)
- Navigation style: Page-first (`CreateWindow("MainPage")`)
- Build status: Android and iOS local builds pass

## Tech Stack

- .NET SDK: `10.0.102` (pinned in `global.json`)
- .NET MAUI:
  - `Microsoft.Maui.Controls` `10.0.30`
  - `Microsoft.Maui.Essentials` `10.0.30`
- Prism: `Prism.DryIoc.Maui` `9.0.537`
- MVVM helpers: `CommunityToolkit.Mvvm` `8.4.0`

## Architecture

- `MauiProgram.cs`
  - Configures Prism using `UsePrism(new DryIocContainerExtension(), ...)`
  - Registers navigation: `MainPage` + `MainViewModel`
  - Sets startup navigation: `prism.CreateWindow("MainPage")`
- `App.xaml` / `App.xaml.cs`
  - Standard MAUI `Application`
  - App resources and merged dictionaries
- `MainPage.xaml`
  - Uses compiled bindings (`x:DataType="viewModels:MainViewModel"`)

## Project Structure

```text
MauiWithPrism/
├── MauiProgram.cs
├── App.xaml
├── App.xaml.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── ViewModels/
│   ├── BaseViewModel.cs
│   └── MainViewModel.cs
├── Platforms/
│   ├── Android/
│   └── iOS/
├── Resources/
│   ├── AppIcon/
│   ├── Fonts/
│   ├── Images/
│   ├── Splash/
│   └── Styles/
├── .github/workflows/build.yml
├── MauiWithPrism.csproj
└── global.json
```

## Prerequisites

- .NET 10 SDK
- MAUI workloads
  - `dotnet workload install maui`
- macOS + Xcode for iOS builds
- Android SDK for Android builds

## Build Commands

From project root (`MauiWithPrism`):

```bash
# Restore Android target
dotnet restore -p:TargetFramework=net10.0-android

# Android build
dotnet build MauiWithPrism.csproj -c Release -f net10.0-android -p:RuntimeIdentifier=android-x64

# iOS simulator build
dotnet build MauiWithPrism.csproj -c Release -f net10.0-ios -p:RuntimeIdentifier=iossimulator-arm64
```

## CI

GitHub Actions workflow: `.github/workflows/build.yml`

- Runner: `macos-26`
- Installs .NET 10 preview + MAUI Android workload
- Builds Android target:
  - `dotnet restore -p:TargetFramework=net10.0-android`
  - `dotnet build --configuration Release --framework net10.0-android --no-restore`

## Notes

- This sample currently uses Prism's DryIoc container integration for MAUI.
- Shell files were removed to keep the app purely page-first.
- Prism has license terms (Community/Commercial). Review Prism licensing before production use.

## License

MIT License (see `LICENSE`).
