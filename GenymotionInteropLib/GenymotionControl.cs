using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMasson.WechatCatalyst.BaseLib;
using IMasson.WechatCatalyst.BaseLib.Interop;

namespace IMasson.WechatCatalyst.Genymotion
{
    public class GenymotionControl : AbstractCatalystControl
    {
        private ProcessRunner _processRunner = new ProcessRunner();
        private string _statusDescription = null;

        public override int GetStatus()
        {
            throw new NotImplementedException();
        }

        public override string GetStatusDescription()
        {
            return _statusDescription;
        }

        public override bool SetGpsLocationInfo(GpsLocationInfo info)
        {
            throw new NotImplementedException();
        }

        public override GpsLocationInfo GetGpsLocationInfo()
        {
            throw new NotImplementedException();
        }

        public override bool SetGpsEnable(bool enable)
        {
            throw new NotImplementedException();
        }

        public override bool IsGpsEnable()
        {
            throw new NotImplementedException();
        }

        public override bool SetTaskInfo(TaskInfo info)
        {
            throw new NotImplementedException();
        }

        public override TaskInfo GetTaskInfo()
        {
            throw new NotImplementedException();
        }

        public override void Prepare()
        {
            _statusDescription = _processRunner.ExcuteRawToEnd("adb push \"Jars\\wechart_uiauto.jar\" \"/data/local/tmp/\"");
        }

        public override void Launch()
        {
            _statusDescription = _processRunner.ExcuteRawToEnd("adb shell uiautomator runtest wechart_uiauto.jar -c com.imasson.auto.wechatuiauto.UiMainTest");
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
