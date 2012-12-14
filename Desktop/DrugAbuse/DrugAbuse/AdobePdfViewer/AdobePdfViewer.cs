using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrugAbuse
{
    public partial class AdobePdfViewer : UserControl
    {
        public AdobePdfViewer(string filename)
        {
            InitializeComponent();
            axAcroPDF1.LoadFile(filename);
        }
    }
}
