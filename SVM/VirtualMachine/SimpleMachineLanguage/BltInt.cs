using SVM.VirtualMachine;
using System;

namespace SVM.SimpleMachineLanguage
{
    public class BltInt : BaseInstructionWithOperand
    {
        public override void Run()
        {
            try
            {
                if (VirtualMachine.Stack.Count > 1)
                {
                    throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                    this.ToString(), VirtualMachine.ProgramCounter));
                }

                int op = (int)VirtualMachine.Stack.Pop();
                if (Convert.ToInt32(Operands[0]) < op)
                {
                    VirtualMachine.Stack.Push(op);
                    Console.WriteLine("Value is less than integer value on top of the stack!");

                    throw new SvmRuntimeException("Value is less than integer value on top of the stack!");

                }
                else
                {

                    VirtualMachine.Stack.Push(op);
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
