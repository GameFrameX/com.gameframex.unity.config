// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;

namespace GameFrameX.Config.Runtime
{
    /// <summary>
    /// 全局配置管理器。
    /// </summary>
    /// <remarks>
    /// Global configuration manager.
    /// </remarks>
    [UnityEngine.Scripting.Preserve]
    public sealed partial class ConfigManager : GameFrameworkModule, IConfigManager
    {
        private readonly ConcurrentDictionary<string, IDataTable> m_ConfigDatas;

        /// <summary>
        /// 初始化全局配置管理器的新实例。
        /// </summary>
        /// <remarks>
        /// Initializes a new instance of the global configuration manager.
        /// </remarks>
        [UnityEngine.Scripting.Preserve]
        public ConfigManager()
        {
            m_ConfigDatas = new ConcurrentDictionary<string, IDataTable>(StringComparer.Ordinal);
        }

        /// <summary>
        /// 获取全局配置项数量。
        /// </summary>
        /// <remarks>
        /// Gets the number of global configuration items.
        /// </remarks>
        /// <value>全局配置项数量 / Number of global configuration items</value>
        public int Count
        {
            get { return m_ConfigDatas.Count; }
        }


        /// <summary>
        /// 全局配置管理器轮询。
        /// </summary>
        /// <remarks>
        /// Global configuration manager tick.
        /// </remarks>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位 / Logical elapsed time in seconds</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位 / Real elapsed time in seconds</param>
        protected override void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理全局配置管理器。
        /// </summary>
        /// <remarks>
        /// Shuts down and cleans up the global configuration manager.
        /// </remarks>
        protected override void Shutdown()
        {
            RemoveAllConfigs();
        }


        /// <summary>
        /// 检查是否存在指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Checks whether the specified global configuration item exists.
        /// </remarks>
        /// <param name="configName">要检查全局配置项的名称 / Name of the global configuration item to check</param>
        /// <returns>指定的全局配置项是否存在 / Whether the specified global configuration item exists</returns>
        [UnityEngine.Scripting.Preserve]
        public bool HasConfig(string configName)
        {
            return m_ConfigDatas.TryGetValue(configName, out _);
        }


        /// <summary>
        /// 增加指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Adds the specified global configuration item.
        /// </remarks>
        /// <param name="configName">要增加全局配置项的名称 / Name of the global configuration item to add</param>
        /// <param name="configValue">全局配置项的值 / Value of the global configuration item</param>
        [UnityEngine.Scripting.Preserve]
        public void AddConfig(string configName, IDataTable configValue)
        {
            m_ConfigDatas.TryAdd(configName, configValue);
        }

        /// <summary>
        /// 移除指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Removes the specified global configuration item.
        /// </remarks>
        /// <param name="configName">要移除全局配置项的名称 / Name of the global configuration item to remove</param>
        /// <returns>是否移除全局配置项成功 / Whether the global configuration item was removed successfully</returns>
        [UnityEngine.Scripting.Preserve]
        public bool RemoveConfig(string configName)
        {
            return m_ConfigDatas.TryRemove(configName, out _);
        }

        /// <summary>
        /// 获取指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Gets the specified global configuration item.
        /// </remarks>
        /// <param name="configName">要获取全局配置项的名称 / Name of the global configuration item to get</param>
        /// <returns>获取到的全局配置项；如果不存在则返回 null / The retrieved global configuration item; null if not found</returns>
        [UnityEngine.Scripting.Preserve]
        public IDataTable GetConfig(string configName)
        {
            return m_ConfigDatas.TryGetValue(configName, out var value) ? value : null; //GetConfig()
        }

        /// <summary>
        /// 清空所有全局配置项。
        /// </summary>
        /// <remarks>
        /// Removes all global configuration items.
        /// </remarks>
        [UnityEngine.Scripting.Preserve]
        public void RemoveAllConfigs()
        {
            m_ConfigDatas.Clear();
        }
    }
}
