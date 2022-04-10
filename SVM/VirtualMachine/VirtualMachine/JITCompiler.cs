﻿namespace SVM.VirtualMachine
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    #endregion
    /// <summary>
    /// Utility class which generates compiles a textual representation
    /// of an SML instruction into an executable instruction instance
    /// </summary>
    internal static class JITCompiler
    {
        #region Constants
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Public methods
        #endregion

        #region Non-public methods
        internal static IInstruction CompileInstruction(string opcode)
        {
            IInstruction instruction = null;

            #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT

            foreach (Type entity in SvmVirtualMachine.instructionsList)
            {
                if (entity.Name.ToUpper() == opcode.ToUpper())
                {
                    instruction = (IInstruction)Activator.CreateInstance(entity);
                    return instruction;
                }
            }

            #endregion

            return instruction;
        }

        internal static IInstruction CompileInstruction(string opcode, params string[] operands)
        {
            IInstructionWithOperand instruction = null;

            #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT

            foreach (Type entity in SvmVirtualMachine.instructionsList)
            {
                if (entity.Name.ToUpper() == opcode.ToUpper())
                {
                    instruction = (IInstructionWithOperand)Activator.CreateInstance(entity);
                    instruction.Operands = operands;

                    return instruction;
                }
            }

            #endregion

            return instruction;
        }
        #endregion

    }
}
