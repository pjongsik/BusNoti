using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBusNoti.Noti
{
    public partial class NotiForm : Form
    {
        public NotiForm()
        {
            InitializeComponent();
        }

        public void setNotiText(string strMsg) 
        {
            this.lbNoti.Text = strMsg;
        }

    }
}
