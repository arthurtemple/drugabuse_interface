using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms.Integration;

namespace DrugAbuse
{
    public class PdfViewerHost : WindowsFormsHost
    {
        public static readonly DependencyProperty PdfPathProperty =
            DependencyProperty.Register("PdfPath", typeof(string), typeof(PdfViewerHost), new PropertyMetadata(PdfPathPropertyChanged));

        private readonly PdfViewer wrappedControl;

        public PdfViewerHost()
        {
            wrappedControl = new PdfViewer();
            Child = wrappedControl;
        }

        public string PdfPath
        {
            get
            {
                return (string)GetValue(PdfPathProperty);
            }

            set
            {
                SetValue(PdfPathProperty, value);
            }
        }

        public void Print()
        {
            wrappedControl.Print();
        }

        private static void PdfPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PdfViewerHost host = (PdfViewerHost)d;
            host.wrappedControl.PdfFilePath = (string)e.NewValue;
        }
    }
}
