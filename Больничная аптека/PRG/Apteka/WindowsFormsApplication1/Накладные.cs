using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Накладные : INotifyPropertyChanged
    {
        public DateTime localDate { set; get; }
        public string name { set; get; }
        public int number { set; get; }
        public List<Медикаменты_в_накладной> med_inv = new List<Медикаменты_в_накладной>();

        public Накладные()
        {
        }

        public Накладные(DateTime date, string name, int number)
        {
            this.localDate = date;
            this.name = name;
            this.number = number;
        }

        public void add_medic_in_inv(string new_name, int new_med_numb)
        {
            med_inv.Add(new Медикаменты_в_накладной(new_name, new_med_numb));
        }

        public List<Медикаменты_в_накладной> GetMed_Inv()
        {
            return med_inv;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
