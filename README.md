# Introduction
Basic Automation Framework Testing project as part of POC for the Backend Automation.
# Getting Started
1.	Installation process
	* Install [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)
	* Install [Visual Studio Community Edition with the .NET Components](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
	
	Clone Automation Repository locally:
  - from your preferred browser go to project [[Automation Backend](https://github.com/fsejasm/BackendAutomation_Jenkins.git "Automation Backend")] repository
  - Click on _Clone_ button on the top right section
  - From popup menu, under _IDE_ section select _Clone in Visual Studio_ Option
    - ```Note: If you got a "switch apps" prompt message, just click Yes```
  - On ```Local Path``` select the location where you want to download the project and clic on _Clone_ button
* Install Packages from Visual Studio
  - From visual Studio main menu, go to ```Tools > Options > NuGet Package Manager``` menu
  - Under Package Restore options, select ```Allow NuGet to download missing packages``` and click ```OK``` button
  - In Solution Explorer, right click the solution and select ```Restore NuGet Packages```
    - ```Note: If one or more individual packages aren't installed properly, Solution Explorer shows an error icon. Right-click and select Manage NuGet Packages, and then use Package Manager to uninstall and reinstall the affected packages.```
* Install Specflow Extension
  - From visual Studio main menu, go to ```Tools > Extensions and Updates``` menu
  - From Extension and Updates window select ```Online``` menu on the left side
  - Search by ```SpecFlow for Visual Studio``` on the top right search area
  - Click on ```Download``` button near to SpecFlow for Visual Studio Extension
  - Restart Visual Studio in order to the changes take effect
### Configuration
## How to configure the executions
### Default config
Default configuration is done in a config file located in [appsettings.json](./Demo/appsettings.json) located in the root.
### Modify Default Configuration
If you want to execute the tets on different environments, you should modify the appsettings.json sections, there you are able to modify below information:

{
  //<-- SQL Server Data -->
  "UserName": "sa",
  "Password": "sa",
  "SQLServerDataSource": "DESKTOP-G08E3PK\\MSSQLSERVER01",
  "SQLServerCatalog": "Demo",
  //-- Use this setting for DB Windows Authentication -->
  "SQLServerConnectionCredentials": "Integrated Security=True",
  //-- Test Data-->
  "TableName": "Name1",
  "StatusOK": "OK",
  "Status401Unauthorized": "401"
}
...
3.	Latest releases
4.	API references
# Build and Test
###Command Line
To build the project execute:
- MSBuild.exe "Demo.sln"
To run all feature test execute the following command:
- dotnet test
###Visual Studio IDE
* From Visual Studio Press ```F6``` Key
or
* Go to the project from Solution Explorer, right click on ```Demo``` and click on ```Build``` menu
## Running The tests
From visual Studio go to ```Test Explorer``` View and Execute the tests that you want to run
	
# Contribute
### Codding Standards
Please refer to [coddingStandards.md](./docs/CoddingStandards.md)