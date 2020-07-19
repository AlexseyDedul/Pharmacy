using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Медикаменты_в_накладной : INotifyPropertyChanged, IMedecinesProduct
    {
        public string Medicines { set; get; }
        public int Quantity { set; get; }

        public Медикаменты_в_накладной()
        {
        }

        public Медикаменты_в_накладной(string medicines, int numbers)
        {
            this.Medicines = medicines;
            this.Quantity = numbers;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
