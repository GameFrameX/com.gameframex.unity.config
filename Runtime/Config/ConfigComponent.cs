﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Config.Runtime
{
    /// <summary>
    /// 全局配置组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Config")]
    public sealed class ConfigComponent : GameFrameworkComponent
    {
        private IConfigManager m_ConfigManager = null;

        /// <summary>
        /// 获取全局配置项数量。
        /// </summary>
        public int Count
        {
            get { return m_ConfigManager.Count; }
        }

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
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
        /// 获取指定全局配置项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetConfig<T>() where T : IDataTable
        {
            if (HasConfig<T>())
            {
                var configName = typeof(T).Name;
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
        /// <returns>指定的全局配置项是否存在。</returns>
        public bool HasConfig<T>() where T : IDataTable
        {
            var configName = typeof(T).Name;
            return m_ConfigManager.HasConfig(configName);
        }

        /// <summary>
        /// 移除指定全局配置项。
        /// </summary>
        /// <returns>是否移除全局配置项成功。</returns>
        public bool RemoveConfig<T>() where T : IDataTable
        {
            var configName = typeof(T).Name;
            return m_ConfigManager.RemoveConfig(configName);
        }

        /// <summary>
        /// 清空所有全局配置项。
        /// </summary>
        public void RemoveAllConfigs()
        {
            m_ConfigManager.RemoveAllConfigs();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="dataTable"></param>
        public void Add(string configName, IDataTable dataTable)
        {
            m_ConfigManager.AddConfig(configName, dataTable);
        }
    }
}