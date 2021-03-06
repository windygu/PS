﻿using System.Collections;
using System.Collections.Generic;
using VisualSmart.BizService.Implements.Base;
using VisualSmart.BizService.Pro;
using VisualSmart.Dao.DataQuickStart.Pro;
using VisualSmart.Domain.Pro;
using VisualSmart.Util;

namespace VisualSmart.BizService.Implements.Pro
{
    public class Pro_SchedulingBizService : EntityBizService<Pro_Scheduling, Pro_SchedulingDao>, IPro_SchedulingBizService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddGetId(Pro_Scheduling entity)
        {
            return EntityDao.AddGetId(entity); 
        }
        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<Pro_Scheduling> GetList(QueryCondition query, Hashtable hs)
        {
            return EntityDao.GetList(query,hs);
        }

        /// <summary>
        /// 获取当前Bom 是否有下级商品信息 需要排产
        /// </summary>
        /// <param name="query"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CreateNextBomList(QueryCondition query, string name)
        {
            return EntityDao.CreateNextBomList(query,name);
        }
    }
}
