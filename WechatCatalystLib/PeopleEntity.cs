using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMasson.WechatCatalyst.BaseLib
{
    /// <summary>
    /// 用来表示某个人的实体类
    /// </summary>
    public class PeopleEntity
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        private string _nickname;

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        private string _region;

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private PeopleType _type;

        public PeopleType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }


        /// <summary>
        /// 用于表示人的类别的枚举
        /// </summary>
        public enum PeopleType
        {
            Unknow = -1,
            Male = 0,
            Female = 1,
            Organization = 2
        }
    }
}
