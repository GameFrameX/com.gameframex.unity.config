## [2.0.1](https://github.com/gameframex/com.gameframex.unity.config/compare/2.0.0...2.0.1) (2026-10-15)


### Bug Fixes

* **dependencies:** asset 依赖升至 5.0.0 ([d8b68b6](https://github.com/gameframex/com.gameframex.unity.config/commit/d8b68b65835f817fd41bd6e36d0c6fc5c41c5885))

# [2.0.0](https://github.com/gameframex/com.gameframex.unity.config/compare/1.2.1...2.0.0) (2026-10-15)


* feat(module)!: 配置模块薄入口化并迁移接口契约 ([77cf0ba](https://github.com/gameframex/com.gameframex.unity.config/commit/77cf0ba5010d524517bf819f09824ad21624bafa))


### BREAKING CHANGES

* ConfigComponent 序列化字段移除；模块契约全接口化。

## [Unreleased]

### ⚠ BREAKING CHANGES

* **module:** `ConfigComponent` 保留为薄入口（纯转发、无序列化字段），模块经 `GetModule<T>()` / `GameApp.Config` 直达；组件值参数序列化字段移除，编辑期配置入口收敛到代码 Options，Play 期经活视图 / 模块 API 调整

# [2.0.0](https://github.com/gameframex/com.gameframex.unity.config/compare/1.2.1...2.0.0) (2026-10-08)


### ⚠ BREAKING CHANGES

* **module:** 模块契约全接口化：删除 `GameFrameworkModule` 抽象基类，改为 `IGameFrameworkModule` 标记接口 + 可选能力接口

**新契约形态与迁移对照：**

| 旧基类成员 | 新契约 | 迁移方式 |
|---|---|---|
| `: GameFrameworkModule` | `IGameFrameworkModule` | 声明处直接替换（标记接口，可注册进 `GameFrameworkEntry`） |
| `override void Update(float, float)` | `IUpdatableModule` | 真实实现改 `public`；空实现删除（未实现者不再被轮询） |
| `override void Shutdown()` | `IShutdownableModule` | 真实实现改 `public`；空实现删除（未实现者不再被关闭） |
| `override int Priority` | `IPrioritizedModule` | 改 `public int Priority { get; }`；未实现视为 0 |

本包变更：`ConfigManager` 实现 `IShutdownableModule`，删除空 `Update` 覆写。

`GameFrameworkEntry.Update` 仅分派 `IUpdatableModule`；`Shutdown` 按优先级反序仅分派 `IShutdownableModule`；tick 与关闭顺序与旧实现完全一致。能力方法仅由宿主入口调用，业务侧继续通过 `GetModule<IXxxManager>()` 访问模块。

## [1.2.1](https://github.com/gameframex/com.gameframex.unity.config/compare/1.2.0...1.2.1) (2026-07-29)


### Bug Fixes

* **dependencies:** 更新依赖版本以支持新功能 ([b18a4ae](https://github.com/gameframex/com.gameframex.unity.config/commit/b18a4ae80d16f2ccc95840bd8dba457469cca3ca))

# [1.2.0](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.6...1.2.0) (2026-07-03)


### Features

* **config:** 为 ConfigComponent 添加自动注册标记 ([0846b3d](https://github.com/gameframex/com.gameframex.unity.config/commit/0846b3da394ae954b1fdae134463e44736e1045d))

## [1.1.6](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.5...1.1.6) (2026-06-07)


### Bug Fixes

* 补全包规范文件（LICENSE/CHANGELOG/URL 字段/unity 字段） ([9f1c6a2](https://github.com/gameframex/com.gameframex.unity.config/commit/9f1c6a2e4b80fa655f38411aa0d61a5d96907858))

## [1.1.5](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.4...1.1.5) (2026-06-01)


### Bug Fixes

* **config:** 修复 BaseDataTable 缓存失效和计数源错误 ([3a1d199](https://github.com/gameframex/com.gameframex.unity.config/commit/3a1d199dc7aadd51a8e8a0d43fc67d7e0894df9f))

## [1.1.4](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.3...1.1.4) (2026-05-28)


### Bug Fixes

* **ci:** 统一 .github 工作流配置 ([6f26f44](https://github.com/gameframex/com.gameframex.unity.config/commit/6f26f448858edb36b99e0c7cfd0a726ee6741d8f))

## [1.1.3](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.2...1.1.3) (2026-04-13)


### Bug Fixes

* **Config:** 修复缓存初始化标志在空数据表时未设置的问题 ([9a801c2](https://github.com/gameframex/com.gameframex.unity.config/commit/9a801c2dff6352375123537546a1236cbe23526b))

## [1.1.2](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.1...1.1.2) (2026-04-13)


### Performance Improvements

* **Config:** 优化数据表内存分配和查找性能 ([ac0ee7c](https://github.com/gameframex/com.gameframex.unity.config/commit/ac0ee7cbb80a72daef0e3cc65d206e2c1b664d2a))

## [1.1.1](https://github.com/gameframex/com.gameframex.unity.config/compare/1.1.0...1.1.1) (2026-03-04)


### Bug Fixes

* **config:** 为 BaseDataTable 中的公共方法添加 [Preserve] 属性 ([34e3285](https://github.com/gameframex/com.gameframex.unity.config/commit/34e32857e217c45e326d802719f6b266cf3896bd))
* **config:** 为IDataTable接口添加Preserve属性防止代码裁剪 ([e61fdab](https://github.com/gameframex/com.gameframex.unity.config/commit/e61fdab74d66d0bcbf3d4264de15c84a6fcc2748))
* 为配置组件添加Preserve特性防止代码剥离 ([3a7dbb5](https://github.com/gameframex/com.gameframex.unity.config/commit/3a7dbb573e5168fcc568c6d28fca31b9981c13d9))


### Performance Improvements

* **Config:** 优化数据表Count属性的性能 ([6e743fb](https://github.com/gameframex/com.gameframex.unity.config/commit/6e743fb144d61145d89537fbfdf205bd69e3fe89))
* **config:** 缓存FirstOrDefault和LastOrDefault结果以提升性能 ([f568979](https://github.com/gameframex/com.gameframex.unity.config/commit/f5689794dbf57649ba2ac14617f23e255a6eea96))

# [1.1.0](https://github.com/gameframex/com.gameframex.unity.config/compare/1.0.6...1.1.0) (2025-12-23)


### Features

* **数据表:** 添加TryGet方法以安全获取数据 ([b174c47](https://github.com/gameframex/com.gameframex.unity.config/commit/b174c47cfceb42a543fe6dea6c8b581fb368160c))

# Changelog

## [1.0.6](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.6) (2025-06-01)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.5...1.0.6)

## [1.0.5](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.5) (2025-05-31)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.4...1.0.5)

## [1.0.4](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.4) (2025-05-30)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.3...1.0.4)

**Closed issues:**

- Config组件的GetConfig\<T\>存在gc [\#1](https://github.com/GameFrameX/com.gameframex.unity.config/issues/1)

## [1.0.3](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.3) (2024-12-18)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.2...1.0.3)

## [1.0.2](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.2) (2024-05-21)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.1...1.0.2)

## [1.0.1](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.1) (2024-05-21)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/1.0.0...1.0.1)

## [1.0.0](https://github.com/GameFrameX/com.gameframex.unity.config/tree/1.0.0) (2024-04-10)

[Full Changelog](https://github.com/GameFrameX/com.gameframex.unity.config/compare/8eb85e4e97b7d1f11f878462d8eb65a25cfc3297...1.0.0)



\* *This Changelog was automatically generated by [github_changelog_generator](https://github.com/github-changelog-generator/github-changelog-generator)*
