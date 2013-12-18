using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMasson.WechatCatalyst.BaseLib
{
    /// <summary>
    /// 表示位置信息的类
    /// </summary>
    public class GpsLocationInfo
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        private int _accuracy;

        public int Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        private int _altitude;

        public int Altitude
        {
            get { return _altitude; }
            set { _altitude = value; }
        }

        private int _bearing;

        public int Bearing
        {
            get { return _bearing; }
            set { _bearing = value; }
        }

        private int _latitude;

        public int Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private int _longitude;

        public int Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        private string _addressName;

        public string AddressName
        {
            get { return _addressName; }
            set { _addressName = value; }
        }

        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
}
