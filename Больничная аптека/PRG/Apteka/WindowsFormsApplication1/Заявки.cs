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
    public class Заявки : INotifyPropertyChanged, IMedicines
    {
        public DateTime LocalDate { set; get; }
        public string Name { set; get; }
        public int Number { set; get; }
        public List<Медикаменты_в_заявке> med_app;

        public Заявки()
        {
            LocalDate = new DateTime();
            Name = null;
            Number = 0;
            med_app = new List<Медикаменты_в_заявке>();
        }

        public Заявки(DateTime date, string name, int number)
        {
            this.LocalDate = date;
            this.Name = name;
            this.Number = number;
        }

        public void add_medic_in_app(string new_name, int new_med_numb)
        {
            med_app.Add(new Медикаменты_в_заявке(new_name, new_med_numb));
        }

        public List<Медикаменты_в_заявке> GetMed_App()
        {
            return med_app;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
