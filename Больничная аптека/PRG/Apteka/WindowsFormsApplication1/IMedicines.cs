using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IMedicines
    {
        DateTime LocalDate { set; get; }
        string Name { set; get; }
        int Number { set; get; }

        void add_medic_in_app(string new_name, int new_med_numb);
        //List<IMedecinesProduct> GetMed_App();
    }
}
