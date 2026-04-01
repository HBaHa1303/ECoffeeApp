using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MenuSize=ECoffee.Application.Models.MenuSize;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _db;
        public MenuRepository(AppDbContext db)
        {
            _db = db;
        }

        public Menu? GetById(long id)
        {
            return _db.Menus.FirstOrDefault(m => m.Id == id)?.Adapt<Menu>();
        }

        public decimal GetPrice(long MenuId, MenuSize size) {
            var menu = _db.Menus.Include(m => m.Prices).FirstOrDefault( m => m.Id == MenuId);
            if (menu == null) return 0;

            var princeEntry = menu.Prices.FirstOrDefault(p => (MenuSize)p.Size == size);
            return princeEntry?.Price ?? 0;
        }

        
        public List<Menu> GetAllProducts()
        {
            
            var entities = _db.Menus
                .Include(m => m.Prices) 
                .ToList();

           

            return entities.Adapt<List<Menu>>();
        }
    }
}
