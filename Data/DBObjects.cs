using jewellery.Data.Models;

namespace jewellery.Data
{
    public class DBObjects
    {
        //файл для работы с бд
      
        public static void Initial(AppDBContent content)
        {

            //добавляем категорияи если вообще нет объектов
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));


            //добавляем объекты по категориям если вообще нет объектов
            if (!content.Jewelry.Any())
                content.AddRange(
                     new Jewelry
                     {
                         name = "Кольцо",
                         shortDesc = "Кольцо серебряное",
                         longDesc = "Данное изделие создано из серебра 925 пробы.",
                         img = "/img/1.jpg",
                         price = 45000,
                         isFavorite = true,
                         available = true,
                         Category = Categories["Silver"]
                     },
                      new Jewelry
                      {
                          name = "Кольцо",
                          shortDesc = "Кольцо серебряное",
                          longDesc = "Данное изделие создано из серебра 925 пробы.",
                          img = "/img/2.jpg",
                          price = 45000,
                          isFavorite = true,
                          available = true,
                          Category = Categories["Silver"]
                      },
                       new Jewelry
                       {
                           name = "Кольцо",
                           shortDesc = "Кольцо серебряное",
                           longDesc = "Данное изделие создано из серебра 925 пробы.",
                           img = "/img/3.jpg",
                           price = 45000,
                           isFavorite = true,
                           available = true,
                           Category = Categories["Silver"]
                       },
                        new Jewelry
                        {
                            name = "Кольцо",
                            shortDesc = "Кольцо серебряное",
                            longDesc = "Данное изделие создано из серебра 925 пробы.",
                            img = "/img/4.jpg",
                            price = 45000,
                            isFavorite = true,
                            available = true,
                            Category = Categories["Silver"]
                        },
                         new Jewelry
                         {
                             name = "Кольцо",
                             shortDesc = "Кольцо серебряное",
                             longDesc = "Данное изделие создано из серебра 925 пробы.",
                             img = "/img/5.jpg",
                             price = 45000,
                             isFavorite = true,
                             available = true,
                             Category = Categories["Silver"]
                         },







                      new Jewelry
                      {
                          name = "Кольцо",
                          shortDesc = "Кольцо золотое",
                          longDesc = "Данное изделие создано из золота 925 пробы.",
                          img = "/img/31.jpg",
                          price = 45000,
                          isFavorite = true,
                          available = true,
                          Category = Categories["Gold"]
                      },
                        new Jewelry
                        {
                            name = "Кольцо",
                            shortDesc = "Кольцо золотое",
                            longDesc = "Данное изделие создано из золота 925 пробы.",
                            img = "/img/32.jpg",
                            price = 45000,
                            isFavorite = true,
                            available = true,
                            Category = Categories["Gold"]
                        },
                          new Jewelry
                          {
                              name = "Кольцо",
                              shortDesc = "Кольцо золотое",
                              longDesc = "Данное изделие создано из золота 925 пробы.",
                              img = "/img/33.jpg",
                              price = 45000,
                              isFavorite = true,
                              available = true,
                              Category = Categories["Gold"]
                          },
                            new Jewelry
                            {
                                name = "Кольцо",
                                shortDesc = "Кольцо золотое",
                                longDesc = "Данное изделие создано из золота 925 пробы.",
                                img = "/img/34.jpg",
                                price = 45000,
                                isFavorite = true,
                                available = true,
                                Category = Categories["Gold"]
                            }


                    );
            content.SaveChanges();

        }


        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Silver", desc = "Серебряные украшения"},
                        new Category {categoryName = "Gold", desc = "Золотые украшения"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);

                }
                return category;
            }

        }
    }
}
