using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.VirtualMachine.Debug
{
    class FrameDebug : IDebugFrame
    {
        public IInstruction CurrentInstruction { set; get; }

        public List<IInstruction> CodeFrame { set; get; }

        public void showImage(string url)
        {
            //Show image via dialog
        }
    }
}
