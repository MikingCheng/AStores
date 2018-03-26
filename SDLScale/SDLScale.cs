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
        string _errorMessage = string.Empty;

        ISdlinterface sdlinft = null;


        public ConSDLScale(string cp, int bd)
        {
            _comPort = cp;
            _baud = bd;
//            sdlinft = new SdlSX();
        }

        public bool InitScale()
        {
            bool result = false;
            if (sdlinft == null)
            {
                sdlinft = new SdlSX();
                result = sdlinft.Open(_comPort, _baud);
            } 
            else
            {
                sdlinft.Close();
                sdlinft = new SdlSX();
                result = sdlinft.Open(_comPort, _baud);
            }

            return result;
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
                return sdlinft.Weight;
            }
        }

        public string Unit
        {
            get { return sdlinft.Unit; }
        }

        public decimal Tare
        {
            get { return sdlinft.Tare; }
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

        public void Close()
        {
            sdlinft.Close();
        }
    }
}
