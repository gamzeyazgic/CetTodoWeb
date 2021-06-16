using CetTodoWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CetTodoWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace CetTodoWeb.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<CetUser> _userManager;

        public CategoryMenuViewComponent(ApplicationDbContext dbContext,UserManager<CetUser> userManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
            
        }
        
        public async Task<IViewComponentResult> InvokeAsync(bool ShowEmpty=true)
        {
            var cetUser = await _userManager.GetUserAsync(HttpContext.User);
            var query= dbContext.Categories.Where(c => c.CetUserId == cetUser.Id);


            var items =await query.ToListAsync();
            return View(items);
        }
    }
}
