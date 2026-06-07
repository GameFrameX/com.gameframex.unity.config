<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Config

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 项目简介

Game Frame X Config 是一个基于 GameFrameX 框架的 Unity 配置表功能包，提供配置功能，使配置功能的使用更加简单高效。

**Config 配置表组件 (Config Component)** - 提供配置表相关的接口。

## 快速开始

### 安装

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.config": "1.1.5"
  }
}
```


## 使用示例

```csharp
// 标准方式：通过 GameEntry（不依赖 com.gameframex.unity.entry）
var configComponent = GameEntry.GetComponent<ConfigComponent>();
configComponent.LoadConfig("ConfigPath");
```

## 依赖项

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.asset`: GameFrameX Asset 资源包
- `com.gameframex.unity.event`: GameFrameX Event 事件包

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/gameframex/com.gameframex.unity.config
- 问题反馈: https://github.com/gameframex/com.gameframex.unity.config/issues

## 开源协议

详细信息请查看 [LICENSE](LICENSE.md) 文件。
