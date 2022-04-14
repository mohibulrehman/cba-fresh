using System.Collections;

namespace SVM.VirtualMachine
{
    public interface IVirtualMachine
    {
        Stack Stack { get; }
        int ProgramCounter { get; set; }
    }
}
