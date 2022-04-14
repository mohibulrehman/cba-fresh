using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Debugger
{
    public partial class SmLDebuggerFrameWindow : Form
    {
        Action<string> callback;
        public SmLDebuggerFrameWindow(Action<string> callback1)
        {
            callback = callback1;
            InitializeComponent();
        }

        private void SmLDebuggerFrameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
