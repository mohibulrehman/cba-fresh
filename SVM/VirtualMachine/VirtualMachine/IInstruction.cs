﻿namespace SVM.VirtualMachine
{
    #region Using directives
    using System;
    using System.Collections;
    #endregion

    /// <summary>
    /// Defines the interface contract for all Simple 
    /// Virtual Machine instructions
    /// </summary>
    public interface IInstruction
    {
        /// <summary>
        /// Executes the instruction
        /// </summary>
        void Run();

        /// <summary>
        /// Assigns a reference to the virtual machine 
        /// that is executing this instruction
        /// </summary>
        SvmVirtualMachine VirtualMachine { set; }

        bool isDebuggedLie { set; get; }

        int lineNumber { set; get; }

        bool hasLabel { set; get; }
        String labelIS { set; get; }
        
    }
}
