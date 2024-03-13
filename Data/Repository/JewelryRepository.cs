using jewellery.Data.interfaces;
using jewellery.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace jewellery.Data.Repository
{
    public class JewelryRepository: IAllJewelry
    {
        //класс для получения данных из базы данных
        private readonly AppDBContent appDBContent;
        public JewelryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;

        }


        //получаем данные из бд
        public IEnumerable<Jewelry> jewelries => appDBContent.Jewelry.Include(c => c.Category);

        public IEnumerable<Jewelry> getFavJewelry => appDBContent.Jewelry.Where(p => p.isFavorite).Include(c => c.Category);



        //получает айди
        public Jewelry getObjectJewelry(int jewelryId) => appDBContent.Jewelry.FirstOrDefault(p => p.id == jewelryId);
    }
}
