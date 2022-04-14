using SVM.VirtualMachine;
using System;

namespace SVM.SimpleMachineLanguage
{
    public class NotEqu : BaseInstruction
    {
        public override void Run()
        {
            try
            {
                if (VirtualMachine.Stack.Count < 2)
                {
                    throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                    this.ToString(), VirtualMachine.ProgramCounter));
                }

                int op1 = (int)VirtualMachine.Stack.Pop();
                int op2 = (int)VirtualMachine.Stack.Pop();
                if(op1 != op2)
                {
                    VirtualMachine.Stack.Push(op1);
                    VirtualMachine.Stack.Push(op2);
                    Console.WriteLine("Both items on the stack top are not equal!");
                }
            }
            catch (InvalidCastException)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }
        }
    }
}
