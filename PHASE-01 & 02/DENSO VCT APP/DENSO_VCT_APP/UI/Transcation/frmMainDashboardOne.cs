using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DENSO_VCT_APP
{
    public partial class frmMainDashboardOne : Form
    {
        public frmMainDashboardOne()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void CollapseThirdPanel()
        {
            //splitContainer2.Panel2Collapsed = true; // Hide the third panel

            int totalWidth = splitContainer1.Width; // Get total available width
            int newWidth = totalWidth / 2; // Divide equally between first and second panels

            splitContainer1.SplitterDistance = newWidth; // Adjust first panel width
            dgv.Width = newWidth - 10;

            // 🔹 Force the DataGridView to recognize the new size
            dgv.ScrollBars = ScrollBars.Both;  // Ensure scrollbars are enabled
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Prevent auto-resizing
                                                                            // Force refresh
            dgv.PerformLayout();
            dgv.Invalidate();
            dgv.Update();
        }
        void RestoreThirdPanel()
        {
            //splitContainer2.Panel2Collapsed = false; // Show the third panel

            int totalWidth = splitContainer1.Width; // Get total width
            int newWidth = totalWidth / 3; // Divide equally among three sections

            splitContainer1.SplitterDistance = newWidth * 1; // First section width
            //splitContainer2.SplitterDistance = newWidth * 1; // Second section width
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
