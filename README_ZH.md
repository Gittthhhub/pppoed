# 适用于 Windows 的 PPPoEd
管理 PPPoE 会话拨号，重拨，会话守护程序等。


## 功能
* 在系统启动时拨号
* 连接断开时重新拨号
* 无需任何用户登录 Windows 会话
* 用户登录/注销 Windows 会话时连接不会中断
* 作为 Windows 系统服务运行

## 快速开始
1. 安装 ```.NET Core 3.1``` 运行时或 SDK
1. 将项目克隆到 Windows 系统
1. 编辑 ```config.json```使用您从运营商获取的帐户 
1. 直接运行 ```PPPoEd.exe```

## 作为系统服务
1. 首先按照 ```快速开始``` 步骤 1-3 进行操作
1. 打开命令行提示符或 PowerShell
1. 将目录更改为 PPPoEd 项目
1. 运行 ```.\PPPoEd.exe install```
1. 运行 ```net start pppoed```
```
卸载运行：
.\PPPoEd.exe uninstall
```

## 故障排除
**服务仍在运行**    
请查看 PPPoEd 项目目录中的日志文件，所有日志文件名均为 ```log_YYYYMMDD.log```。

**服务已停止**    
直接运行 ```.\PPPoEd.exe```，然后按照错误消息进行解决。或在此处发布问题。

## 开源协议
```
该项目基于 MIT 许可证。
版权所有（c）2020 xRetia Labs
版权所有（c）2020 dfc643
```


-----

## 基于 DotRas 2.0
为.NET语言（如C＃，VB.NET和C ++ CLR项目）提供远程访问服务（RAS）组件。

[![Build Status](https://ci.appveyor.com/api/projects/status/e05n0wuddlcpe3um?svg=true)](https://ci.appveyor.com/project/winnster/dotras)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DotRas&metric=alert_status)](https://sonarcloud.io/dashboard?id=DotRas)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=DotRas&metric=coverage)](https://sonarcloud.io/dashboard?id=DotRas)

私人构建供稿位于：https://www.myget.org/F/winnster/api/v3/index.json