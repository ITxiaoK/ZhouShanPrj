using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                ListViewItem item = new ListViewItem
                {
                    Name = "111",
                    Text="root",
                   
                };
                listView.Items.Add(item);
            }
        }
    }
}
