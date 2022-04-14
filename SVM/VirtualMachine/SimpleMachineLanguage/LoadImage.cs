using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Extensions
{
    public class LoadImage : BaseInstructionWithOperand
    {
        public override void Run()
        {
            if (Operands[0].GetType() != typeof(string))
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }

            VirtualMachine.Stack.Push(Operands[0]);
        }
    }
}
