# PortalExec Project

## Overview

PortalExec is a Windows application developed using the Uno Platform, which allows users to explore directories, list `.lnk` shortcut files, and execute the applications they point to. The project demonstrates handling file system operations, working with shortcut files, and launching external applications from a Uno Platform application.

## Key Features

- **Directory Browsing:** Users can enter a directory path to browse.
- **Listing Shortcuts:** Displays a list of `.lnk` shortcut files in the specified directory.
- **Executing Applications:** Allows users to execute applications by clicking on the listed shortcut files.

## Project Structure

- **PortalExec.Presentation:** Contains the UI and logic for browsing directories, listing shortcut files, and executing applications.
- **PortalExec.DataContracts:** Defines data contracts used across the application.
- **PortalExec.Shared:** Includes shared resources and assets.

## Prerequisites

- Visual Studio 2019 or later with the Uno Platform solution templates installed.
- .NET 6.0 SDK or later.

## Getting Started

1. **Clone the Repository:**

```bash
git clone https://github.com/vmaspad/portalexec.git
```
Open the Solution:
Open PortalExec.sln in Visual Studio.

Restore NuGet Packages:
Right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

Set Startup Project:
Set PortalExec.Windows (or any other head project you wish to run) as the startup project.

Run the Application:
Press F5 to build and run the application.

Usage
Browse Directory: Enter the path of the directory you want to explore in the "Carpeta" field and click "Explorar".
Execute Application: Click "Ejecutar" next to a listed shortcut to launch the application.
Contributing
Contributions are welcome! Please feel free to submit pull requests or open issues to improve the project.
