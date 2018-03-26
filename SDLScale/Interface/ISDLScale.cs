using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStores.SDLScale.Interface
{
    public interface ISDLScale
    {
        bool InitScale();
        bool ReadWeight();
        bool Reset();
        bool SetTare();

        decimal Weight { get; }
        string Unit { get; }
        decimal Tare { get; }

        string ErrorMessage { get; }

        void Close();
    }
}
