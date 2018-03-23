using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlSerialPort;
using SDLScale.Interface;
using System.Threading;

namespace SDLScale
{
    public class SDLScale: ISDLScale
    {
        decimal _weight;
        string _unit;
        decimal _tare;
        string _errorMessage = string.Empty;

        ISdlinterface sdlinft = null;
        public SDLScale()
        {
            sdlinft = new SdlSP();
        }
        public void InitScale(string comport, int baud)
        {

            if (sdlinft == null)
            {
                sdlinft = new SdlSX();
                sdlinft.Open(comport, baud);
            }
            else
            {
                sdlinft.Close();
                sdlinft = new SdlSX();
                sdlinft.Open(comport, baud);
            }
        }

        public bool SingleReadWeight()
        {
            bool brt = sdlinft.StartOneRead();
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
