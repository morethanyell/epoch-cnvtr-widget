# Epoch Converter Widget

## Overview
This project is a minimalistic WinForms application written in C#. It is entirely written by ChatGPT. I just gave out instructions. It demonstrates:

- Dynamically positioning a form near the taskbar
- Handling custom mouse events (dragging and double-click to close)
- Converting epoch time to a human-readable date using a TextBox and Label

## Prerequisites
Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)
- A text editor or IDE (e.g., Visual Studio Code, Visual Studio, or any plain text editor)

## How to Build and Run
Follow these steps to build and run the application:

1. Clone the Repository:
```
git clone https://github.com/yourusername/your-repo-name.git
cd your-repo-name
```

2. Build the Project: Using the .NET CLI, navigate to the project folder and run:

```
dotnet build
```

3. Run the Application: After building, you can run the application using:

```
dotnet run
```

4. Create an Executable (Optional): To generate a standalone .exe file, use the following command:

```
dotnet publish -c Release -r win-x64 --self-contained true
```
The .exe file will be located in:

```
./bin/Release/net<version>/win-x64/publish/
```

## Features
- Form Positioning: Automatically centers near the bottom of the screen above the taskbar.
- Draggable Form: Press and hold the mouse to drag the form anywhere.
- Double-Click to Close: Double-clicking the form will close it.
- Epoch to Date Conversion: Enter an epoch time in the text box to see its human-readable equivalent, or an error message for invalid input.

## Notes
- The application doesn't use Visual Studio and is entirely compatible with the .NET CLI.
- Feel free to fork or modify the project to suit your needs!

## Contributing
If you'd like to contribute, feel free to submit a pull request or open an issue with suggestions or improvements.

## License
This project is licensed under the [MIT License](https://mit-license.org/).