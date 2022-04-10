﻿using SVM.VirtualMachine.Debug;

namespace SVM
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.IO;
    using SVM.VirtualMachine;
    using System.Linq;
    using System.Reflection;
    #endregion

    /// <summary>
    /// Implements the Simple Virtual Machine (SVM) virtual machine 
    /// </summary>
    public sealed class SvmVirtualMachine : IVirtualMachine
    {
        #region Constants
        private const string CompilationErrorMessage = "An SVM compilation error has occurred at line {0}.\r\n\r\n{1}";
        private const string RuntimeErrorMessage = "An SVM runtime error has occurred.\r\n\r\n{0}";
        private const string InvalidOperandsMessage = "The instruction \r\n\r\n\t{0}\r\n\r\nis invalid because there are too many operands. An instruction may have no more than one operand.";
        private const string InvalidLabelMessage = "Invalid label: the label {0} at line {1} is not associated with an instruction.";
        private const string ProgramCounterMessage = "Program counter violation; the program counter value is out of range";
        #endregion

        #region Fields
        private IDebugger debugger = null;
        private List<IInstruction> program = new List<IInstruction>();
        private int instructionDebugIndex = -1;
        private Stack stack = new Stack();
        private int programCounter = 0;
        public delegate void CallBackButtonPressed(string result);

        private string[] label = null;
        public static List<Type> instructionsList = new List<Type>();

        #endregion

        #region Constructors

        public SvmVirtualMachine()
        {
            #region Task 5 - Debugging 
            // Do something here to find and create an instance of a type which implements 
            // the IDebugger interface, and assign it to the debugger field

            createDebuggerInstance();

            #endregion
        }

        private void createDebuggerInstance()
        {

            if (false)
            {

                var tpe = (typeof(IDebugger).Assembly)
                                              .GetTypes().Where(x => x.Name == "IDebugger")
                                              .ToList();

                if (tpe.Count() != 0)
                {
                    Type type = tpe[0];
                    debugger.VirtualMachine = this;
                    debugger = (IDebugger)Activator.CreateInstance(type);
                }

                Console.WriteLine("what is this");
                return;
            }

            // Getting list of files
            var files = Directory.GetFiles(Environment.CurrentDirectory, "Debugger.dll");

            Type[] types;

            foreach (var file in files)
            {
                try
                {
                    types = Assembly.LoadFrom(file).GetTypes();
                }
                catch (Exception exception)
                {
                    String msg = exception.Message;
                    Console.WriteLine(msg);
                    continue;  // Can't load as .NET assembly, so ignoring it
                }

                Console.WriteLine("yes it should");
                types =
                    types.Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IDebugger))
                    && t.Name.Equals("debugger", StringComparison.InvariantCultureIgnoreCase)).ToArray();

                if (types.Count() != 0)
                {
                    Type type = types[0];
                    debugger = (IDebugger)Activator.CreateInstance(typeof(IDebugger));
                }
                else
                {
                    throw new SvmCompilationException("Some Thing invalid in SML source instruction has been found.");
                }
            }
        }
        #endregion

        #region Entry Point
        static void Main(string[] args)
        {
            if (CommandLineIsValid(args))
            {
                SvmVirtualMachine vm = new SvmVirtualMachine();

                loadInstructionListFromPath();
                try
                {
                    vm.Compile(args[0]);
                    vm.Run();
                }
                catch (SvmCompilationException)
                {
                }
                catch (SvmRuntimeException err)
                {
                    Console.WriteLine(RuntimeErrorMessage, err.Message);
                }
            }
        }

        private static void loadInstructionListFromPath()
        {

            Assembly assemblyName = Assembly.GetExecutingAssembly();

            foreach (Type entity in assemblyName.ExportedTypes)
            {

                foreach (Type tpe in entity.GetInterfaces())
                {

                    if (tpe.Name == "IInstruction" || tpe.Name == "IInstructionwithoperand")
                    {
                        instructionsList.Add(entity);
                    }
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        ///  Gets a reference to the virtual machine stack.
        ///  This is used by executing instructions to retrieve
        ///  operands and store results
        /// </summary>
        public Stack Stack
        {
            get
            {
                return stack;
            }
        }

        /// <summary>
        /// Accesses the virtual machine 
        /// program counter (see programCounter in the Fields region).
        /// This can be used by executing instructions to 
        /// determine their order (ie. line number) in the 
        /// sequence of executing SML instructions
        /// </summary>
        public int ProgramCounter
        {
            #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT
            get { return programCounter; }
            set { programCounter++; }
            #endregion
        }

        #endregion

        #region Public Methods

        #endregion

        /// <summary>
        /// Reads the specified file and tries to 
        /// compile any SML instructions it contains
        /// into an executable SVM program
        /// </summary>
        /// <param name="filepath">The path to the 
        /// .sml file containing the SML program to
        /// be compiled</param>
        /// <exception cref="SvmCompilationException">
        /// If file is not a valid SML program file or 
        /// the SML instructions cannot be compiled to an
        /// executable program</exception>
        private void Compile(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new SvmCompilationException("The file " + filepath + " does not exist");
            }

            int lineNumber = 0;
            try
            {
                using (StreamReader sourceFile = new StreamReader(filepath))
                {
                    while (!sourceFile.EndOfStream)
                    {
                        string instruction = sourceFile.ReadLine();
                        if (!String.IsNullOrEmpty(instruction) &&
                            !String.IsNullOrWhiteSpace(instruction))
                        {
                            ParseInstruction(instruction, lineNumber);
                            lineNumber++;
                        }
                    }
                }
            }
            catch (SvmCompilationException err)
            {
                Console.WriteLine(CompilationErrorMessage, lineNumber, err.Message);
                throw;
            }
        }

        /// <summary>
        /// Executes a compiled SML program 
        /// </summary>
        /// <exception cref="SvmRuntimeException">
        /// If an unexpected error occurs during
        /// program execution
        /// </exception>
        private void Run()
        {
            DateTime start = DateTime.Now;

            #region TASK 2 - TO BE IMPLEMENTED BY THE STUDENT
            #region TASKS 5 & 7 - MAY REQUIRE MODIFICATION BY THE STUDENT
            // For task 5 (debugging), you should construct a IDebugFrame instance and
            // call the Break() method on the IDebugger instance stored in the debugger field

            SvmVirtualMachine svmVirtualMachine = new SvmVirtualMachine();
            programCounter = 0;
            foreach (var instruction in program)
            {
                if (this.instructionDebugIndex > 0 && this.instructionDebugIndex == programCounter)
                {
                    /*Console.WriteLine("Never come usually Dear");
                    FrameDebug debugFrame = new FrameDebug();
                    debugFrame.CodeFrame = program;
                    debugFrame.CurrentInstruction = instruction;
                                      
                    if (debugger == null)
                        createDebuggerInstance();

                    debugger.Break(debugFrame);*/

                    return;

                }
                instruction.VirtualMachine = svmVirtualMachine;
                instruction.Run();

                programCounter++;
            }

            #endregion
            #endregion

            long memUsed = System.Environment.WorkingSet;
            TimeSpan elapsed = DateTime.Now - start;
            Console.WriteLine(String.Format(
                                        "\r\n\r\nExecution finished in {0} milliseconds. Memory used = {1} bytes",
                                        elapsed.Milliseconds,
                                        memUsed));
        }

        /// <summary>
        /// Parses a string from a .sml file containing a single
        /// SML instruction
        /// </summary>
        /// <param name="instruction">The string representation
        /// of an instruction</param>
        private void ParseInstruction(string instruction, int lineNumber)
        {
            #region TASK 5 & 7 - MAY REQUIRE MODIFICATION BY THE STUDENT

            //  For Debugging
            if (instruction.StartsWith('*'))
            {
                instruction = instruction.Trim('*');
                instruction = instruction.TrimStart();
                this.instructionDebugIndex = lineNumber;
            }

            //  For Labeling
            if (instruction.StartsWith('%'))
            {
                label = instruction.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                label[0] = label[0].Trim('%');
                instruction = label[1];
            }

            #endregion

            string[] tokens = null;
            if (instruction.Contains("\""))
            {
                tokens = instruction.Split(new char[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);

                // Remove any unnecessary whitespace
                for (int i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].Trim();
                }
            }
            else
            {
                // Tokenize the instruction string by separating on spaces
                tokens = instruction.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }


            // Ensure the correct number of operands
            if (tokens.Length > 3)
            {
                throw new SvmCompilationException(String.Format(InvalidOperandsMessage, instruction));
            }

            switch (tokens.Length)
            {
                case 1:
                    program.Add(JITCompiler.CompileInstruction(tokens[0]));
                    break;
                case 2:
                    program.Add(JITCompiler.CompileInstruction(tokens[0], tokens[1].Trim('\"')));
                    break;
                case 3:
                    program.Add(JITCompiler.CompileInstruction(tokens[0], tokens[1].Trim('\"'), tokens[2].Trim('\"')));
                    break;
            }
        }


        #region Validate command line
        /// <summary>
        /// Verifies that a valid command line has been supplied
        /// by the user
        /// </summary>
        private static bool CommandLineIsValid(string[] args)
        {
            bool valid = true;

            if (args.Length != 1)
            {
                DisplayUsageMessage("Wrong number of command line arguments");
                valid = false;
            }

            if (valid && !args[0].EndsWith(".sml", StringComparison.CurrentCultureIgnoreCase))
            {
                DisplayUsageMessage("SML programs must be in a file named with a .sml extension");
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Displays comamnd line usage information for the
        /// SVM virtual machine 
        /// </summary>
        /// <param name="message">A custom message to display
        /// to the user</param>
        static void DisplayUsageMessage(string message)
        {
            Console.WriteLine("The command line arguments are not valid. {0} \r\n", message);
            Console.WriteLine("USAGE:");
            Console.WriteLine("svm program_name.sml");
        }
        #endregion



        #region System.Object overrides
        /// <summary>
        /// Determines whether the specified <see cref="System.Object">Object</see> is equal to the current <see cref="System.Object">Object</see>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object">Object</see> to compare with the current <see cref="System.Object">Object</see>.</param>
        /// <returns><b>true</b> if the specified <see cref="System.Object">Object</see> is equal to the current <see cref="System.Object">Object</see>; otherwise, <b>false</b>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for this type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="System.Object">Object</see>.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String">String</see> that represents the current <see cref="System.Object">Object</see>.
        /// </summary>
        /// <returns>A <see cref="System.String">String</see> that represents the current <see cref="System.Object">Object</see>.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}
