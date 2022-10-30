using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonelService
    {
        void Adding(Personel pers);
        bool Updating(Personel pers);
        void Deleteing(Personel pers);
        List<Personel> Listing();
        Personel Getir(int id);
    }
}
