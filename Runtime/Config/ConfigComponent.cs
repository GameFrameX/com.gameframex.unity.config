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
using GameFrameX.Runtime;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Config.Runtime
{
    /// <summary>
    /// 全局配置组件。
    /// </summary>
    /// <remarks>
    /// Global configuration component.
    /// </remarks>
    [DisallowMultipleComponent]
    [AddComponentMenu("GameFrameX/Config")]
    public sealed class ConfigComponent : GameFrameworkComponent
    {
        private IConfigManager m_ConfigManager = null;
        private ConcurrentDictionary<Type, string> m_ConfigNameTypeMap = new ConcurrentDictionary<Type, string>();

        /// <summary>
        /// 获取全局配置项数量。
        /// </summary>
        /// <remarks>
        /// Gets the number of global configuration items.
        /// </remarks>
        /// <value>全局配置项数量 / Number of global configuration items</value>
        [Preserve]
        public int Count
        {
            get { return m_ConfigManager.Count; }
        }

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        /// <remarks>
        /// Initializes the game framework component.
        /// </remarks>
        protected override void Awake()
        {
            m_ConfigNameTypeMap.Clear();
            ImplementationComponentType = Utility.Assembly.GetType(componentType);
            InterfaceComponentType = typeof(IConfigManager);
            base.Awake();
            m_ConfigManager = GameFrameworkEntry.GetModule<IConfigManager>();
            if (m_ConfigManager == null)
            {
                Log.Fatal("Config manager is invalid.");
                return;
            }
        }

        /// <summary>
        /// 获取指定类型的全局配置项名称。
        /// </summary>
        /// <remarks>
        /// Gets the name of the global configuration item for the specified type.
        /// </remarks>
        /// <typeparam name="T">配置项的类型 / Type of the configuration item</typeparam>
        /// <returns>类型名称 / Type name</returns>
        [Preserve]
        private string GetTypeName<T>()
        {
            if (m_ConfigNameTypeMap.TryGetValue(typeof(T), out var configName))
            {
                return configName;
            }

            configName = typeof(T).Name;
            m_ConfigNameTypeMap.TryAdd(typeof(T), configName);

            return configName;
        }

        /// <summary>
        /// 获取指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Gets the specified global configuration item.
        /// </remarks>
        /// <typeparam name="T">配置项的类型，必须实现 <see cref="IDataTable"/> 接口 / Type of the configuration item, must implement <see cref="IDataTable"/></typeparam>
        /// <returns>获取到的全局配置项；如果不存在则返回默认值 / The retrieved global configuration item; default value if not found</returns>
        [Preserve]
        public T GetConfig<T>() where T : IDataTable
        {
            if (HasConfig<T>())
            {
                var configName = GetTypeName<T>();
                var config = m_ConfigManager.GetConfig(configName);
                if (config != null)
                {
                    return (T)config;
                }
            }

            return default;
        }

        /// <summary>
        /// 检查是否存在指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Checks whether the specified global configuration item exists.
        /// </remarks>
        /// <typeparam name="T">配置项的类型，必须实现 <see cref="IDataTable"/> 接口 / Type of the configuration item, must implement <see cref="IDataTable"/></typeparam>
        /// <returns>指定的全局配置项是否存在 / Whether the specified global configuration item exists</returns>
        [Preserve]
        public bool HasConfig<T>() where T : IDataTable
        {
            var configName = GetTypeName<T>();
            return m_ConfigManager.HasConfig(configName);
        }

        /// <summary>
        /// 移除指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Removes the specified global configuration item.
        /// </remarks>
        /// <typeparam name="T">配置项的类型，必须实现 <see cref="IDataTable"/> 接口 / Type of the configuration item, must implement <see cref="IDataTable"/></typeparam>
        /// <returns>是否移除全局配置项成功 / Whether the global configuration item was removed successfully</returns>
        [Preserve]
        public bool RemoveConfig<T>() where T : IDataTable
        {
            var configName = GetTypeName<T>();
            return m_ConfigManager.RemoveConfig(configName);
        }

        /// <summary>
        /// 清空所有全局配置项。
        /// </summary>
        /// <remarks>
        /// Removes all global configuration items.
        /// </remarks>
        [Preserve]
        public void RemoveAllConfigs()
        {
            m_ConfigNameTypeMap.Clear();
            m_ConfigManager.RemoveAllConfigs();
        }

        /// <summary>
        /// 增加指定全局配置项。
        /// </summary>
        /// <remarks>
        /// Adds the specified global configuration item.
        /// </remarks>
        /// <param name="configName">全局配置项的名称 / Name of the global configuration item</param>
        /// <param name="dataTable">全局配置项的数据表实例 / Data table instance of the global configuration item</param>
        [Preserve]
        public void Add(string configName, IDataTable dataTable)
        {
            m_ConfigManager.AddConfig(configName, dataTable);
        }
    }
}