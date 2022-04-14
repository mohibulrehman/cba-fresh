using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.SimpleMachineLanguage
{
    public class EquInt : BaseInstructionWithOperand
    {
        public override void Run()
        {
            try
            {
                if (VirtualMachine.Stack.Count < 1)
                {
                    throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                    this.ToString(), VirtualMachine.ProgramCounter));
                }

                int op1 = (int)VirtualMachine.Stack.Pop();
               
                    VirtualMachine.Stack.Push(op1);
                    Console.WriteLine("Value is equal to the integer value on top of the stack!");
            }
            catch (SvmRuntimeException)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }
        }
    }
}
