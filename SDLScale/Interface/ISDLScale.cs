using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDLScale.Interface
{
    public interface ISDLScale
    {
        void InitScale(string comport, int baud);
        bool SingleReadWeight();
        bool Reset();
        bool SetTare();

        decimal Weight { get; }
        string Unit { get; }
        decimal Tare { get; }

        string ErrorMessage { get; }
    }
}
