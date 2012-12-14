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
    public partial class PdfViewer : UserControl
    {
        private string pdfFilePath;

        public PdfViewer()
        {
            InitializeComponent();
            acrobatViewer.setShowToolbar(false);
            acrobatViewer.setView("FitH");
            this.Visible = true;
        }

        public string PdfFilePath
        {
            get
            {
                return pdfFilePath;
            }

            set
            {
                if (pdfFilePath != value)
                {
                    pdfFilePath = value;
                    ChangeCurrentDisplayedPdf();
                }
            }
        }

        public void Print()
        {
            acrobatViewer.printWithDialog();
        }

        private void ChangeCurrentDisplayedPdf()
        {
            acrobatViewer.LoadFile(PdfFilePath);
            Console.WriteLine("fichier chargé :"+PdfFilePath);
            acrobatViewer.src = PdfFilePath;
            acrobatViewer.setViewScroll("FitH", 0);
            Console.WriteLine("Size" + acrobatViewer.Height + "x" + acrobatViewer.Width);
        }
    }
}
