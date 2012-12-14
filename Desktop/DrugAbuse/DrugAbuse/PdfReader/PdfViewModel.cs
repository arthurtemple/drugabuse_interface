using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;

namespace DrugAbuse
{
    public class PdfViewModel : INotifyPropertyChanged
    {
        private readonly string[] pdfChoices;
        private string currentPdf;
        private int currentPdfChoiceIndex;

        public PdfViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            
            string path1 = Path.Combine(currentFolder, @"SamplePDF1.pdf");
            
            string path2 = Path.Combine(currentFolder, @"SamplePDF2.pdf");
            
            pdfChoices = new string[]
                              {
                                  path1,
                                  path2,
                              };
            CurrentPdf = pdfChoices[currentPdfChoiceIndex];
            Console.WriteLine("currentpdf:" + CurrentPdf);

            SwapPdfsCommand = new ActionCommand(() =>
            {
                currentPdfChoiceIndex ^= 1;
                CurrentPdf = pdfChoices[currentPdfChoiceIndex];
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentPdf
        {
            get
            {
                return currentPdf;
            }

            set
            {
                if (currentPdf != value)
                {
                    currentPdf = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("CurrentPdf"));
                }
            }
        }

        public ICommand SwapPdfsCommand
        {
            get;
            private set;
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
