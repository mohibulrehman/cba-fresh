﻿namespace SVM.SimpleMachineLanguage
{
    #region Using directives
    using System;
    using SVM.VirtualMachine;
    #endregion
    /// <summary>
    /// Implements the SML Decr  instruction
    /// Decrements the integer value stored on top of the stack, 
    /// leaving the result on the stack
    /// </summary>
    public class Decr : BaseInstruction
    {
        #region TASK 3 - TO BE IMPLEMENTED BY THE STUDENT
        #endregion
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

                VirtualMachine.Stack.Push(op1 - 1);
            }
            catch (InvalidCastException)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }
        }
    }
}
