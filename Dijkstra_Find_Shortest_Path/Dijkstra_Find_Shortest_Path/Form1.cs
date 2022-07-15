using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra_Find_Shortest_Path
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Map.Instance.ShowMap(pnlMap);

            radioEndPoint.Tag = Constant.Status.End;
            radioStartPoint.Tag = Constant.Status.Start;
            radioTrapPoint.Tag = Constant.Status.Trap;

            radioTrapPoint.Checked = true;
            Map.Instance.SelectRadio = radioTrapPoint;
        }

        private void radioEndPoint_Click(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            Map.Instance.SelectRadio = btn;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (answer)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Map.Instance.Solve();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Map.Instance.ResetMap();
        }

        private void btnClearPath_Click(object sender, EventArgs e)
        {
            Map.Instance.ClearPath();
        }
    }
}