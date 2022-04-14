
using Debugger;
using SVM;
using SVM.VirtualMachine;
using SVM.VirtualMachine.Debug;
using System;

namespace Debuggers
{
    public class Debugger : IDebugger
    {
        // #region TASK 5 - TO BE IMPLEMENTED BY THE STUDENT


        private SvmVirtualMachine virtualMachine = null;
        protected const string VirtualMachineErrorMessage = "A virtual machine error has occurred.";

        public SvmVirtualMachine VirtualMachine
        {
            get
            {
                return virtualMachine;
            }
            set
            {
                if (null == value)
                {
                    throw new SvmRuntimeException(VirtualMachineErrorMessage);
                }

                virtualMachine = value;
            }
        }


        SvmVirtualMachine IDebugger.VirtualMachine { set; get; }

        public void Break(IDebugFrame debugFrame, Action<string> callback)
        {
            SmLDebuggerFrameWindow obj = new SmLDebuggerFrameWindow(callback);
            obj.Show();
            obj.btnContinue.Enabled = true;
            obj.lstCode.Items.Add(debugFrame.CodeFrame);
            obj.lstCode.SelectedItem = debugFrame.CurrentInstruction;
            if (VirtualMachine.Stack.Count > 0)
            {
                foreach (var item in VirtualMachine.Stack)
                {
                    obj.lstStack.Items.Add(item);
                }
            }


        }
    }

}

