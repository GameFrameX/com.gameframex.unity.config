<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Config

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

Game Frame X Config 是一個基於 GameFrameX 框架的 Unity 配置表功能包，提供配置功能，使配置功能的使用更加簡單高效。

**Config 配置表元件 (Config Component)** - 提供配置表相關的介面。

## 快速開始

### 系統需求

- Unity 2019.4 或更高版本
- GameFrameX 框架 1.1.1 或更高版本

### 安裝

任選以下方式之一：

1. 直接在 `manifest.json` 的檔案中的 `dependencies` 節點下添加以下內容：
   ```json
   {"com.gameframex.unity.config": "https://github.com/AlianBlank/com.gameframex.unity.config.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.config.git
   ```

3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 使用範例

```csharp
// 標準方式：透過 GameEntry（不依賴 com.gameframex.unity.entry）
var configComponent = GameEntry.GetComponent<ConfigComponent>();
configComponent.LoadConfig("ConfigPath");
```

## 依賴項

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.asset`: GameFrameX Asset 資源包
- `com.gameframex.unity.event`: GameFrameX Event 事件包

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/gameframex/com.gameframex.unity.config
- 問題回報: https://github.com/gameframex/com.gameframex.unity.config/issues

## 開源協議

詳細資訊請查看 [LICENSE](LICENSE.md) 檔案。
