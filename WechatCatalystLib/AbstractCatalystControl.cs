using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMasson.WechatCatalyst.BaseLib
{
    /// <summary>
    /// WechatCatalyst的控制器的基类，定义操作接口
    /// </summary>
    public abstract class AbstractCatalystControl
    {
        // 状态
        public abstract int GetStatus();
        public abstract String GetStatusDescription();

        // 设置GPS
        public abstract bool SetGpsLocationInfo(GpsLocationInfo info);
        public abstract GpsLocationInfo GetGpsLocationInfo();
        public abstract bool SetGpsEnable(bool enable);
        public abstract bool IsGpsEnable();

        // 设置Wechat参数
        public abstract bool SetTaskInfo(TaskInfo info);
        public abstract TaskInfo GetTaskInfo();

        // 主控制方法
        public abstract void Prepare();
        public abstract void Launch();
        public abstract void Stop();
    }
}
