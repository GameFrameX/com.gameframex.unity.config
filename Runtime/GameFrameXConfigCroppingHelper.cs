using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Config.Runtime
{
    [Preserve]
    public class GameFrameXConfigCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
            // 引用所有核心类型以防止 IL2CPP 代码裁剪
            // Reference all core types to prevent IL2CPP code stripping
            _ = typeof(ConfigManager);
            _ = typeof(IConfigManager);
            _ = typeof(LoadConfigFailureEventArgs);
            _ = typeof(LoadConfigSuccessEventArgs);
            _ = typeof(LoadConfigUpdateEventArgs);
            _ = typeof(IDataTable<>);
            _ = typeof(BaseDataTable<>);
            _ = typeof(ConfigComponent);
        }
    }
}