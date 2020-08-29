# PPPoEd for Windows
Manage PPPoE session dial-up, re-dial, session daemon etc.    
LANGUAGE: [简体中文](http://fanyi.baidu.com/transpage?query=https%3A%2F%2Fgitlab.com%2Fdfc643%2Fpppoed%2F-%2Fraw%2Fmaster%2FREADME.md&from=auto&to=zh&source=url&render=1) 

## Function
* Dial up on system boot
* Re-dial when connection disconnected
* No need any user to sign-in Windows session
* Connection will not break when user sign-in/out Windows session
* Run as Windows system service

## Quick Start
1. Install ```.NET Core 3.1``` runtime or sdk
1. Clone the project to your Windows system
1.  Edit ```config.json``` with your account from ISP
1.  Run ```PPPoEd.exe``` directly

## As System Service
1. Following ```Quick Start``` steps 1-3 first
1. Open Command-Line Prompt or PowerShell
1. Change directory into PPPoEd project
1. Run ```.\PPPoEd.exe install```
1. Run ```net start pppoed```
```
For Uninstall run:
.\PPPoEd.exe uninstall
```

## Troubleshooting
**Service still running**    
Please view the log file in PPPoEd project directory, all the log file names ```log_YYYYMMDD.log```.

**Service has been stopped**    
Run ```.\PPPoEd.exe``` directly, and following the error message to resolve it. or post a issue here.

## License
```
The Project is based on the MIT License.
Copyright (c) 2020 xRetia Labs
Copyright (c) 2020 dfc643
All rights reserved.
 ```


-----

## Based on DotRas 2.0
Provides remote access service (RAS) components for .NET languages like C#, VB.NET, and C++ CLR projects.

[![Build Status](https://ci.appveyor.com/api/projects/status/e05n0wuddlcpe3um?svg=true)](https://ci.appveyor.com/project/winnster/dotras)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DotRas&metric=alert_status)](https://sonarcloud.io/dashboard?id=DotRas)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=DotRas&metric=coverage)](https://sonarcloud.io/dashboard?id=DotRas)

The private build feed is located at: https://www.myget.org/F/winnster/api/v3/index.json
