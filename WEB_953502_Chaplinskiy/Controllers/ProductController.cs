﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_Chaplinskiy.Data;
using WEB_953502_Chaplinskiy.Entities;
using WEB_953502_Chaplinskiy.Extensions;
using WEB_953502_Chaplinskiy.Models;

namespace WEB_953502_Chaplinskiy.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        //List<Dish> _dishes;
        //List<DishGroup> _dishGroups;
        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            //SetupData();
            _context = context;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            //return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,
            //_pageSize));
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,
_pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
        
        
        /// <summary>
        /// Инициализация списков
        /// </summary>
        //private void SetupData()
        //{
        //    _dishGroups = new List<DishGroup>
        //    {
        //    new DishGroup {DishGroupId=1, GroupName="Стартеры"},
        //    new DishGroup {DishGroupId=2, GroupName="Салаты"},
        //    new DishGroup {DishGroupId=3, GroupName="Супы"},
        //    new DishGroup {DishGroupId=4, GroupName="Основныеблюда"},
        //    new DishGroup {DishGroupId=5, GroupName="Напитки"},
        //    new DishGroup {DishGroupId=6, GroupName="Десерты"}
        //    };
        //    _dishes = new List<Dish>
        //    {
        //    new Dish {DishId = 1, DishName="Суп-харчо",
        //    Description="Очень острый, невкусный",
        //    Calories =200, DishGroupId=3, Image="dan.jfif" },
        //    new Dish { DishId = 2, DishName="Борщ",
        //    Description="Много сала, без сметаны",
        //    Calories =330, DishGroupId=3, Image="dannie.jfif" },
        //    new Dish { DishId = 3, DishName="Котлета пожарская",
        //    Description="Хлеб - 80%, Морковь - 20%",
        //    Calories =635, DishGroupId=4, Image="donnie.jpg" },
        //    new Dish { DishId = 4, DishName="Макароны по-флотски",
        //    Description="С охотничьей колбаской",
        //    Calories =524, DishGroupId=4, Image="Man.png" },
        //    new Dish { DishId = 5, DishName="Компот",
        //    Description="Быстро растворимый, 2 литра",
        //    Calories =180, DishGroupId=5, Image="ыру.jpg" }

        //    };

        //}
    }
}
