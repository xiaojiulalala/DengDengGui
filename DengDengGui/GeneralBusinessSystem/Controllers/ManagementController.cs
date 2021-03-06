using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralBusinessRepository;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Common;

namespace GeneralBusinessSystem.Controllers
{
    public class ManagementController : GBController
    {
        /// <summary>
        /// 实例化ManagementController
        /// </summary>
        /// <param name="businessRepository">业务仓储类</param>
        public ManagementController(IBusinessRepository businessRepository) : base(businessRepository)
        {

        }
        public IActionResult Index()
        {
            return View();
        }


        #region 菜单模块管理

        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("menus")]
        public IActionResult Menus()
        {
            return View();
        }

        /// <summary>
        /// 查询全部菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("getmenus")]
        public IActionResult GetMenus()
        {
            var list = _businessRepository.GetMenus();
            return new JsonResult(list, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new LowercaseContractResolver()
            });
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="rolename">名称</param>
        /// <returns></returns>
        [HttpPost("addmenu")]
        public bool AddMenu(string name)
        {
            return _businessRepository.AddMenu(name) > 0 ? true : false;
        }
        /// <summary>
        /// 修改菜单 
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [HttpPost("modifymenu")]
        public bool ModifyMenu(int id, string name)
        {
            return _businessRepository.ModifyMenu(id, name) > 0 ? true : false;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpPost("deletemenu")]
        public bool DeleteRole(int id)
        {
            return _businessRepository.RemoveMenu(id) > 0 ? true : false;
        }

        /// <summary>
        /// 菜单模块管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("menumodules")]
        public IActionResult MenuModules()
        {
            return View();
        }

        #endregion
    }
}