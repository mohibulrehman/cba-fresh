using System.Collections;

namespace SVM.VirtualMachine
{
    interface IVirtualMachine
    {
        Stack Stack { get; }
        int ProgramCounter { get; set; }
    }
}
