using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent db;

        public ShopCart(AppDBContent db)
        {
            this.db = db;
        }

        [Key]
        [Required]
        public string ShopCartId { get; set; }
        //Предметы которые могу находится в корзине
        public List<ShopCartItem> ListShopsItems { get; set; }

        //Создание или получение существующей корзины для определенной сессии (С определенного компа)
        static public ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        //Добавление определенного Itema в корзину пользователя(ShopCartId=ShopCartId) в текущую его сессию
        public void AddToCart(Car car)
        {
            db.ShopCartItem.Add(new ShopCartItem() { ShopCartId=ShopCartId, Car=car });
            db.SaveChanges();
        }
        
        //Взятие всех Items из корзины
        public List<ShopCartItem> GetShopItems()
        {
            //Слева на право - мы получаем все предметы нашей текущей сессии .мы берем и получаем все машинки (Item)
            return db.ShopCartItem.Where(i => i.ShopCartId==ShopCartId).Include(i => i.Car).ToList();
        }
    }
}
