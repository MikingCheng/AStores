using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AStores.Services
{
    public class UpdateScale
    {

        public void StartUpdate()
        {

        }
        Thread t = new Thread(
  delegate () {
      while (_running)
      {
          DoSomething();
          Thread.Sleep(50);
      }
  }
);
        t.Start();
    }
}
