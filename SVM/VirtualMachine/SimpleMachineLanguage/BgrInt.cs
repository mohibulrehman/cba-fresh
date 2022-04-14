using SVM.VirtualMachine;
using System;

namespace SVM.SimpleMachineLanguage
{
    public class BgrInt : BaseInstructionWithOperand
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

                int operand = (int)VirtualMachine.Stack.Pop();
                if (Convert.ToInt32(Operands[0]) > operand)
                {
                    VirtualMachine.Stack.Push(operand);
                    Console.WriteLine("The Value is greater than the Integer value on top of the stack!");

                    throw new SvmRuntimeException("The Value is greater than the Integer value on top of the stack!");
                }
                else {

                    VirtualMachine.Stack.Push("");
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
