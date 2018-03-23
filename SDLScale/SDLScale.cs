using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlSerialPort;
using AStores.SDLScale.Interface;
using System.Threading;

namespace AStores.SDLScale
{
    public class ConSDLScale: ISDLScale
    {
        string _comPort;
        int _baud;
        decimal _weight;
        string _unit;
        decimal _tare;
        string _errorMessage = string.Empty;

        ISdlinterface sdlinft = null;


        public ConSDLScale(string cp, int bd)
        {
            _comPort = cp;
            _baud = bd;
            sdlinft = new SdlSX();
        }

        public void InitScale()
        {

            if (sdlinft == null)
            {
                sdlinft = new SdlSX();
                sdlinft.Open(_comPort, _baud);
            }
            else
            {
                sdlinft.Close();
                sdlinft = new SdlSX();
                sdlinft.Open(_comPort, _baud);
            }
        }

        public bool ReadWeight()
        {
            bool brt = sdlinft.StartRead();
            return brt;
        }

        public bool Reset()
        {
            bool brt = sdlinft.SetZero();
            Thread.Sleep(300);
            //MessageBox.Show(brt.ToString());
            return brt;
        }

        public bool SetTare()
        {
            bool brt = sdlinft.SetTare();
            Thread.Sleep(300);
            //            MessageBox.Show(brt.ToString());
            return brt;
        }

        public decimal Weight
        {
            get
            {
                return _weight;
            }
        }

        public string Unit
        {
            get { return _unit; }
        }

        public decimal Tare
        {
            get { return _tare; }
        }

        public string ErrorMessage
        {
            get {
                if (sdlinft.IsZeroWarning)
                    _errorMessage += "报警";
                if (sdlinft.Isoverload)
                    _errorMessage += "超载";

                return _errorMessage;
            }
        }
    }
}
