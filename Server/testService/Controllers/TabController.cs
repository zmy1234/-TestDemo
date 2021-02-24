using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testService.Model;

namespace testService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabController : ControllerBase
    {
        private readonly DataContext _context;

        public TabController(DataContext context)
        {
            _context = context;
            //初始数据
            if (_context.LeftTabs.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                List<LeftTab> leftTabs = new List<LeftTab>();
                leftTabs.Add(new LeftTab() { 
                   RepoTitle= "boat-house-frontend",
                   RepoDesp= "IDCF Boat House 前端库，包括用户界面 和 管理界面",
                   RepoUrl= "https://github.com/idcf-boat-house/boat-house-frontend",
                   AddTime=DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house-backend",
                    RepoDesp = "boat-house 后端库，web api 微服务",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house-backend",
                    AddTime = DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house",
                    RepoDesp = "IDCF boat-house 社区共创文档库, 官网： https://boat-house.cn/ 文档库：https://idcf.org.cn/boat-house/#/",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house",
                    AddTime = DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house-infrastructure",
                    RepoDesp = "IDCF Boat House 基础设施库，包括vm环境创建脚本，devops相关工具部署脚本",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house-infrastructure",
                    AddTime = DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house-calculator",
                    RepoDesp = "Forked from AzureDevOps101/calculator Boat House Calculator Demo App",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house-calculator",
                    AddTime = DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house-mobile-android",
                    RepoDesp = "IDCF Boat House Android 移动端",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house-mobile-android",
                    AddTime = DateTime.Now
                });
                leftTabs.Add(new LeftTab()
                {
                    RepoTitle = "boat-house-hello-world",
                    RepoDesp = "",
                    RepoUrl = "https://github.com/idcf-boat-house/boat-house-hello-world",
                    AddTime = DateTime.Now
                });
                _context.LeftTabs.AddRange(leftTabs);
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeftTab>>> GetTodoItems()
        {
            return await _context.LeftTabs.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeftTab>> GetTodoItem(int id)
        {
            var todoItem = await _context.LeftTabs.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpPost("SaveData")]
        public async Task<ActionResult<int>> SaveData(List<RightTab> RightTabs)
        {
            
            await _context.RightTabs.AddRangeAsync(RightTabs);
            return await _context.SaveChangesAsync();
        }
    }
}