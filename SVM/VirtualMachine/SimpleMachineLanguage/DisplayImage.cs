using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using SVM.VirtualMachine.Debug;



namespace SML_Extensions
{
    public class DisplayImage : BaseInstruction
    {
        public override void Run()
        {
            if (VirtualMachine.Stack.Count < 1)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }

            String url = VirtualMachine.Stack.Pop().ToString();
            Console.WriteLine(url);

            
            IDebugFrame debugger = null;
            // Getting list of files
            var files = Directory.GetFiles(Environment.CurrentDirectory, "Debugger.dll");

            Type[] types;

            foreach (var file in files)
            {
                try
                {
                    types = Assembly.LoadFrom(file).GetTypes();

                    types = types.Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IDebugger))
                   && t.Name.Equals("debugger", StringComparison.InvariantCultureIgnoreCase)).ToArray();

                }
                catch (Exception exception)
                {
                    continue;  // Can't load as .NET assembly, so ignoring it
                }

               
                if (types.Count() != 0)
                {
                    Type type = types[0];
                    debugger = (IDebugFrame)Activator.CreateInstance(type);
                }
                else
                {
                    throw new SvmCompilationException("invalid SML source instruction.");
                }


                debugger.showImage(url);
              



            }
        }
    }
}

