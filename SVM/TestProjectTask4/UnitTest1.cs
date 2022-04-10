using NUnit.Framework;
using SVM.SimpleMachineLanguage;

namespace TestProjectTask4
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIncr()
        {
            var inc = new Incr();
            inc.VirtualMachine = new SVM.SvmVirtualMachine();
            inc.VirtualMachine.Stack.Push(2);

            inc.Run();

            int result = (int)inc.VirtualMachine.Stack.Pop();
            Assert.AreEqual(result, 3);
            
        }
        [Test]
        public void TestDecre()
        {
            var inc = new Decr();
            inc.VirtualMachine = new SVM.SvmVirtualMachine();
            inc.VirtualMachine.Stack.Push(4);

            inc.Run();

            int result = (int)inc.VirtualMachine.Stack.Pop();
            Assert.AreEqual(result, 3);
            
        }

        [Test]
        public void TesMethod()
        {


/*
            EquInt eq = new EquInt();
            eq.VirtualMachine = new SVM.SvmVirtualMachine();
            eq.VirtualMachine.Stack.Push(5);
            // eq.VirtualMachine.Stack.Push(6);
            eq.Run();

            int result = (int)eq.VirtualMachine.Stack.Pop();
            Assert.IsInstanceOfType(result, typeof(int));*/

        }


    }
}