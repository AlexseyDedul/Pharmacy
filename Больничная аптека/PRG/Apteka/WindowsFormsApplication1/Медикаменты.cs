using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Медикаменты : INotifyPropertyChanged
    {
        public DateTime localDate { set; get; }
        public string name { set; get; }
        public int numbers_m { set; get; }

        public Медикаменты() { }

        public Медикаменты(DateTime date, string name, int numbers_m)
        {
            this.localDate = date;
            this.name = name;
            this.numbers_m = numbers_m;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
