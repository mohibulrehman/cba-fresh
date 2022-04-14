using Microsoft.VisualStudio.TestTools.UnitTesting;
using SVM;
using SVM.VirtualMachine;

using System;
using Moq;
using System.Collections;
using SVM.SimpleMachineLanguage;
using System.Diagnostics;


namespace TestProjectTadk4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(SvmRuntimeException), "wrong type operand")]
        public void WrongDecrementOperandTest()
        {

            Stack sta = new Stack();
            sta.Push("a");

            Mock<IVirtualMachine> mock = new Mock<IVirtualMachine>(MockBehavior.Strict);
            mock.Setup(vm => vm.Stack).Returns(sta);
            Decr dec = new Decr
            {
                VirtualMachine = (SvmVirtualMachine)mock.Object
            };
            dec.Run();
        }

        [TestMethod]
        [ExpectedException(typeof(SvmRuntimeException), "wrong type operand")]
        public void WrongIncreOperandTest()
        {

            Stack sta = new Stack();
            sta.Push("a");

            Mock<IVirtualMachine> mock = new Mock<IVirtualMachine>(MockBehavior.Strict);
            mock.Setup(vm => vm.Stack).Returns(sta);
            Incr dec = new Incr
            {
                VirtualMachine = (SvmVirtualMachine)mock.Object
            };
            dec.Run();
        }


        [TestMethod]
        public void IncrMethodTest()
        {
            Incr inc = new Incr();
            inc.VirtualMachine = new SVM.SvmVirtualMachine();
            inc.VirtualMachine.Stack.Push(3);
            inc.Run();

            int result = (int)inc.VirtualMachine.Stack.Pop();
            Assert.AreEqual(result, 4);


        }

        [TestMethod]
        public void TestMethodDecr()
        {

            Decr inc = new Decr();
            inc.VirtualMachine = new SVM.SvmVirtualMachine();
            inc.VirtualMachine.Stack.Push(5);
            inc.Run();

            int result = (int)inc.VirtualMachine.Stack.Pop();
            Assert.AreEqual(result, 4);

        }






        [TestMethod]
        public void TestMethodEquint()
        {


            EquInt eq = new EquInt();
            eq.VirtualMachine = new SvmVirtualMachine();
            eq.VirtualMachine.Stack.Push(5);
            eq.Run();

            int result = (int)eq.VirtualMachine.Stack.Pop();
            Assert.IsInstanceOfType(result, typeof(int));


        }

        [TestMethod]
        public void TestMethodNotEquint()
        {


            NotEqu eq = new NotEqu();
            eq.VirtualMachine = new SVM.SvmVirtualMachine();
            eq.VirtualMachine.Stack.Push(5);
            eq.VirtualMachine.Stack.Push(4);
            eq.Run();

            int first = (int)eq.VirtualMachine.Stack.Pop();
            int second = (int)eq.VirtualMachine.Stack.Pop();
            Assert.AreNotEqual(first, second);

        }

        [TestMethod]
        public void TestMethodBgrInt()
        {
            BgrInt eq = new BgrInt();
            eq.VirtualMachine = new SVM.SvmVirtualMachine();
            eq.VirtualMachine.Stack.Push(998877665544332211);
            eq.Run();

            int first = (int)eq.VirtualMachine.Stack.Pop();

            Assert.AreNotSame(first, 998877665544332211);

        }

        [TestMethod]
        public void TestMethodBltInt()
        {


            BgrInt eq = new BgrInt();
            eq.VirtualMachine = new SVM.SvmVirtualMachine();
            eq.VirtualMachine.Stack.Push(-998877665544332211);
            eq.Run();

            int first = (int)eq.VirtualMachine.Stack.Pop();

            Assert.AreNotSame(first, -998877665544332211);

        }



    }
}
