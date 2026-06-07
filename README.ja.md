<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Config

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

Game Frame X Config は、GameFrameX フレームワークに基づく Unity 設定テーブルパッケージで、設定管理をより簡単かつ効率的にします。

**Config コンポーネント (Config Component)** - 設定テーブル関連のインターフェースを提供します。

## クイックスタート

### インストール

Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：

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

`scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.config": "1.1.5"
  }
}
```


## 使用例

```csharp
// 標準: GameEntry 経由（com.gameframex.unity.entry 非依存）
var configComponent = GameEntry.GetComponent<ConfigComponent>();
configComponent.LoadConfig("ConfigPath");
```

## 依存関係

- `com.gameframex.unity`: GameFrameX コアフレームワーク
- `com.gameframex.unity.asset`: GameFrameX Asset パッケージ
- `com.gameframex.unity.event`: GameFrameX Event パッケージ

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/gameframex/com.gameframex.unity.config
- イシュー: https://github.com/gameframex/com.gameframex.unity.config/issues


## コミュニティとサポート

- QQグループ: 467608841 / 233840761

## 変更履歴

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.config/releases) で変更履歴を確認してください。
## ライセンス

詳細は [LICENSE](LICENSE.md) をご覧ください。
