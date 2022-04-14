using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;
using Debugger;
using SVM;
using SVM.VirtualMachine;
using SVM.VirtualMachine.Debug;

namespace Debugger
{
    class ImageLoad : IDebugFrame
    {
        public IInstruction CurrentInstruction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IInstruction> CodeFrame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void showImage(string url)
        {
            Form3 image = new Form3();
            image.displayImage(url);
            image.Show();
        }
    }
}
