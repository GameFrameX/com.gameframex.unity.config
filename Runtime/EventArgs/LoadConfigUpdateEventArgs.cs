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

using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;

namespace GameFrameX.Config.Runtime
{
    /// <summary>
    /// 加载全局配置更新事件。
    /// </summary>
    /// <remarks>
    /// Event raised when loading global configuration progress is updated.
    /// </remarks>
    public sealed class LoadConfigUpdateEventArgs : GameEventArgs
    {
        /// <summary>
        /// 加载全局配置更新事件编号。
        /// </summary>
        /// <remarks>
        /// The event ID for load global configuration update.
        /// </remarks>
        /// <value>事件编号 / Event ID</value>
        public static readonly string EventId = typeof(LoadConfigUpdateEventArgs).FullName;

        /// <summary>
        /// 初始化加载全局配置更新事件的新实例。
        /// </summary>
        /// <remarks>
        /// Initializes a new instance of the load global configuration update event.
        /// </remarks>
        public LoadConfigUpdateEventArgs()
        {
            ConfigAssetName = null;
            Progress = 0f;
            UserData = null;
        }

        /// <summary>
        /// 获取加载全局配置更新事件编号。
        /// </summary>
        /// <remarks>
        /// Gets the event ID for load global configuration update.
        /// </remarks>
        /// <value>事件编号 / Event ID</value>
        public override string Id
        {
            get { return EventId; }
        }

        /// <summary>
        /// 获取全局配置资源名称。
        /// </summary>
        /// <remarks>
        /// Gets the global configuration asset name.
        /// </remarks>
        /// <value>全局配置资源名称 / Global configuration asset name</value>
        public string ConfigAssetName { get; private set; }

        /// <summary>
        /// 获取加载全局配置进度。
        /// </summary>
        /// <remarks>
        /// Gets the loading progress of the global configuration.
        /// </remarks>
        /// <value>加载进度，范围为 0.0 到 1.0 / Loading progress, ranging from 0.0 to 1.0</value>
        public float Progress { get; private set; }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        /// <remarks>
        /// Gets the user custom data.
        /// </remarks>
        /// <value>用户自定义数据 / User custom data</value>
        public object UserData { get; private set; }

        /// <summary>
        /// 创建加载全局配置更新事件。
        /// </summary>
        /// <remarks>
        /// Creates a load global configuration update event.
        /// </remarks>
        /// <param name="dataAssetName">全局配置资源名称 / Global configuration asset name</param>
        /// <param name="progress">加载进度，范围为 0.0 到 1.0 / Loading progress, ranging from 0.0 to 1.0</param>
        /// <param name="userData">用户自定义数据 / User custom data</param>
        /// <returns>创建的加载全局配置更新事件 / The created load global configuration update event</returns>
        public static LoadConfigUpdateEventArgs Create(string dataAssetName, float progress, object userData)
        {
            LoadConfigUpdateEventArgs loadConfigUpdateEventArgs = ReferencePool.Acquire<LoadConfigUpdateEventArgs>();
            loadConfigUpdateEventArgs.ConfigAssetName = dataAssetName;
            loadConfigUpdateEventArgs.Progress = progress;
            loadConfigUpdateEventArgs.UserData = userData;
            return loadConfigUpdateEventArgs;
        }

        /// <summary>
        /// 清理加载全局配置更新事件。
        /// </summary>
        /// <remarks>
        /// Clears the load global configuration update event.
        /// </remarks>
        public override void Clear()
        {
            ConfigAssetName = null;
            Progress = 0f;
            UserData = null;
        }
    }
}