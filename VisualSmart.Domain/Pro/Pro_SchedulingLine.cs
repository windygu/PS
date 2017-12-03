﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualSmart.Domain.Base;

namespace VisualSmart.Domain.Pro
{
    /// <summary>
    /// Pro_SchedulingLine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pro_SchedulingLine : Entity
    {
        public Pro_SchedulingLine()
        { }
        #region Model
      
        private int _mainid = 0;
        private string _prolineno = "";
        private int _morningshift = 0;
        private int _morningnum = 0;
        private int? _middleshift;
        private int? _middlenum;
        private int? _eveningshift;
        private int? _eveningnum;
        
        /// <summary>
        /// 
        /// </summary>
        public int MainId
        {
            set { _mainid = value; }
            get { return _mainid; }
        }
        /// <summary>
        /// 生产线
        /// </summary>
        public string ProLineNo
        {
            set { _prolineno = value; }
            get { return _prolineno; }
        }
        /// <summary>
        /// 早班
        /// </summary>
        public int MorningShift
        {
            set { _morningshift = value; }
            get { return _morningshift; }
        }
        /// <summary>
        /// 早班产能
        /// </summary>
        public int MorningNum
        {
            set { _morningnum = value; }
            get { return _morningnum; }
        }
        /// <summary>
        /// 中班
        /// </summary>
        public int? MiddleShift
        {
            set { _middleshift = value; }
            get { return _middleshift; }
        }
        /// <summary>
        /// 中班产能
        /// </summary>
        public int? MiddleNum
        {
            set { _middlenum = value; }
            get { return _middlenum; }
        }
        /// <summary>
        /// 晚班
        /// </summary>
        public int? EveningShift
        {
            set { _eveningshift = value; }
            get { return _eveningshift; }
        }
        /// <summary>
        /// 晚班产能
        /// </summary>
        public int? EveningNum
        {
            set { _eveningnum = value; }
            get { return _eveningnum; }
        }
        #endregion Model

    }
}
