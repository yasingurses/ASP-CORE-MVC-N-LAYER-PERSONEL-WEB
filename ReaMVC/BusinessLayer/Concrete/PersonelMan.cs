using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonelMan : IPersonelService
    {
        IPersonel ıper;
     

        public PersonelMan(IPersonel ıper)
        {
            this.ıper = ıper;
        }

        public void Adding(Personel pers)
        {
            ıper.ekle(pers);
        }

        public void Deleteing(Personel pers)
        {
            ıper.Sil(pers);
        }

        public Personel Getir(int id)
        {
           return ıper.Get(id);
        }

        public List<Personel> Listing()
        {
            return ıper.Listele();
        }

        public bool Updating(Personel pers)
        {
            int value= ıper.guncelle(pers);
            if (value >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
