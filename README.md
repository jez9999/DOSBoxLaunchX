# DOSBoxLaunchX

**DOSBoxLaunchX** is a Windows utility that simplifies managing and launching DOSBox-X configurations for classic DOS games. It provides a modern UI for editing DOSBox-X settings, creating shortcuts, and customizing per-game configurations.

## Features

- **Visual Settings Editor:** Modify DOSBox-X configuration settings, (grouped and custom), as well as keyboard mappings directly in the UI.  
- **Shortcut Generation:** Easily create .DLX shortcuts for the desktop, start menu, or anywhere on the file system with specific DOSBox-X settings per shortcut.  
- **Base Dir and Executable:** Quickly set a base directory and executable to get your DOS game/app up and running.  
- **Grouped Settings Binding:** UI controls are automatically bound to LaunchSettings properties.  
- **Free Disk Space Limiting:** Set per-game limits on virtual disk free space using `-freesize`.  
- **Keyboard Mapper Support:** Override base keyboard mappings and warn if an unknown mapping is specified.  
- **Robust Validation:** UI inputs are validated for reserved names, duplicates, and malformed entries.

## Intended Usage

1. Associate DOSBoxLaunchX with `.DLX` files via **Tools | Options** in the main UI.  
2. Configure global and per-game settings using the main UI.  
3. Add custom settings or override keyboard mappings as needed.  
4. Generate shortcuts for your DOS games or apps.  
5. Launch games from Explorer by opening the shortcut files.

## Installation

1. Clone the repository:  
   ```bash
   git clone https://github.com/jez9999/DOSBoxLaunchX
   ```
2. Open the solution in Visual Studio (requires .NET 9 or later).  
3. Build and run `DOSBoxLaunchX.exe`.

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests. Ensure that UI binding, validation, configuration persistence, and existing code style are maintained.

## Author

**jez9999** — [jez9999@gmail.com](mailto:jez9999@gmail.com)
