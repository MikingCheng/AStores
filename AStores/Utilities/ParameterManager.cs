using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AStores.Utilities
{
    public class ParameterManager
    {
        private ParameterManager() { }
        static ParameterManager _instance;
        static readonly object sync = new object();

        string _comport = string.Empty;
        int _baud = 0;
        string _demoScale = string.Empty;

        public static ParameterManager Instance
        {
            get
            {
                lock (sync)
                {
                    if (_instance == null)
                    {
                        _instance = new ParameterManager();
                    }

                    return _instance;
                }
            }
        }

        public string ComPort
        {
            get
            {
                if (_comport == string.Empty)
                {
                    _comport = ConfigurationManager.AppSettings["ComPort"];
                }
                return _comport;
            }
            set
            {
                _comport = value;
            }
        }

        public string DemoScale
        {
            get
            {
                if (_demoScale == string.Empty)
                {
                    _demoScale = ConfigurationManager.AppSettings["DemoScale"];
                }
                return _demoScale;
            }
        }

        public int Baud
        {
            get
            {
                if (_baud == 0)
                {
                    _baud = int.Parse( ConfigurationManager.AppSettings["Baud"]);
                }
                return _baud;
            }
            set
            {
                _baud = value;
            }
        }
    }
}
