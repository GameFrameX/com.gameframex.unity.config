<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Config

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.config)](https://github.com/GameFrameX/com.gameframex.unity.config/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

Game Frame X Config is a Unity configuration table package based on the GameFrameX framework, providing configuration functionality for easier and more efficient config management.

**Config Component** - Provides configuration table related interfaces.

## Quick Start

### Installation

Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:

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

`scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.config": "1.1.5"
  }
}
```


## Usage Examples

```csharp
// Standard: via GameEntry (no dependency on com.gameframex.unity.entry)
var configComponent = GameEntry.GetComponent<ConfigComponent>();
configComponent.LoadConfig("ConfigPath");
```

## Dependencies

- `com.gameframex.unity`: GameFrameX core framework
- `com.gameframex.unity.asset`: GameFrameX Asset package
- `com.gameframex.unity.event`: GameFrameX Event package

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/gameframex/com.gameframex.unity.config
- Issues: https://github.com/gameframex/com.gameframex.unity.config/issues


## Community & Support

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.config/releases) for changelog.
## License

See [LICENSE](LICENSE.md) for details.
