﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualSmart.Domain.Base;

namespace VisualSmart.Domain.Pro
{
    /// <summary>
    /// Pro_ShipPlanMain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pro_ShipPlanMain : Entity
    {
        public Pro_ShipPlanMain()
        { }
        #region Model
        private int _id;
        private DateTime _planfromdate;
        private DateTime _planfromto;
      
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PlanFromDate
        {
            set { _planfromdate = value; }
            get { return _planfromdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PlanFromTo
        {
            set { _planfromto = value; }
            get { return _planfromto; }
        }
       
        #endregion Model

    }
}
