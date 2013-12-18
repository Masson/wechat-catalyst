using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMasson.WechatCatalyst.BaseLib
{
    /// <summary>
    /// 表示一次执行任务的设置参数
    /// </summary>
    public class TaskInfo
    {
        private string _greetingWord;

        public string GreetingWord
        {
            get { return _greetingWord; }
            set { _greetingWord = value; }
        }

        private PeopleEntity.PeopleType _targetPeopleType;

        public PeopleEntity.PeopleType TargetPeopleType
        {
            get { return _targetPeopleType; }
            set { _targetPeopleType = value; }
        }

        private int _maxSendCount = 30;

        public int MaxSendCount
        {
            get { return _maxSendCount; }
            set { _maxSendCount = value; }
        }

        private long _maxTimeout = 5000L;

        public long MaxTimeout
        {
            get { return _maxTimeout; }
            set { _maxTimeout = value; }
        }

        private int _maxRetryTime = 3;

        public int MaxRetryTime
        {
            get { return _maxRetryTime; }
            set { _maxRetryTime = value; }
        }
    }
}
