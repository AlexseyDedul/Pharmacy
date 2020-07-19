using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Аптека
    {
        List<Заявки> app;
        List<Медикаменты> medic;
        List<Накладные> invoice;

        public Аптека()
        {
            app = new List<Заявки>();
            medic = new List<Медикаменты>();
            invoice = new List<Накладные>();
        }

        public void add_app(Заявки m)
        {
            app.Add(m);
        }

        public void add_medic(Медикаменты m)
        {
            medic.Add(m);
        }

        public void add_inv(Накладные m)
        {
            invoice.Add(m);
        }

        public List<Заявки> GetApp()
        {
            return app;
        }

        public List<Медикаменты> GetMed()
        {
            return medic;
        }

        public List<Накладные> GetInv()
        {
            return invoice;
        }

        public List<Заявки> sort_app_date(List<Заявки> ap)
        {
            ap.Sort(delegate(Заявки m_1, Заявки m_2)
            {
                return m_1.LocalDate.CompareTo(m_2.LocalDate);
            });
            return ap;
        }

        public List<Заявки> sort_app_name(List<Заявки> ap)
        {
            ap.Sort(delegate(Заявки m_1, Заявки m_2)
            {
                return m_1.Name.CompareTo(m_2.Name);
            });
            return ap;
        }

        public List<Медикаменты> sort_medic(List<Медикаменты> med)
        {
            med.Sort(delegate(Медикаменты m_1, Медикаменты m_2)
            {
                return m_1.name.CompareTo(m_2.name);
            });
            return med;
        }

        public List<Медикаменты> sort_medicDate(List<Медикаменты> med)
        {
            med.Sort(delegate(Медикаменты m_1, Медикаменты m_2)
            {
                return m_1.localDate.CompareTo(m_2.localDate);
            });
            return med;
        }

        public List<Накладные> sort_inv_date(List<Накладные> inv)
        {
            inv.Sort(delegate(Накладные m_1, Накладные m_2)
            {
                return m_1.localDate.CompareTo(m_2.localDate);
            });
            return inv;
        }

        public List<Накладные> sort_inv_name(List<Накладные> inv)
        {
            inv.Sort(delegate(Накладные m_1, Накладные m_2)
            {
                return m_1.name.CompareTo(m_2.name);
            });
            return inv;
        }

        public void XmlSerialize_app()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Заявки>));
             
            using (FileStream fs = new FileStream("applic.xml", FileMode.Create))
            {
                formatter.Serialize(fs, app);
            }
        }

        public void XmlDeserializable_app()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Заявки>));
            using (FileStream fs = new FileStream("applic.xml", FileMode.OpenOrCreate))
            {
                app = (List<Заявки>)formatter.Deserialize(fs);
            }

        }

        public void XmlSerialize_med()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Медикаменты>));
            
            using (FileStream fs = new FileStream("med.xml", FileMode.Create))
            {
                formatter.Serialize(fs, medic);
            }
        }

        public void XmlDeserializable_med()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Медикаменты>));

            using (FileStream fs = new FileStream("med.xml", FileMode.OpenOrCreate))
            {
                medic = (List<Медикаменты>)formatter.Deserialize(fs);
            }

        }

        public void XmlSerialize_inv()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Накладные>));
            
            using (FileStream fs = new FileStream("invoice.xml", FileMode.Create))
            {
                formatter.Serialize(fs, invoice);
            }
        }

        public void XmlDeserializable_inv()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Накладные>));

            using (FileStream fs = new FileStream("invoice.xml", FileMode.OpenOrCreate))
            {
                invoice = (List<Накладные>)formatter.Deserialize(fs);
            }

        }
    }
}
