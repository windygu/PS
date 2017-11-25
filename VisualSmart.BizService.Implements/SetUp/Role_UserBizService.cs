﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualSmart.BizService.Implements.Base;
using VisualSmart.BizService.SetUp;
using VisualSmart.Dao.DataQuickStart.SetUp;
using VisualSmart.Domain.SetUp;

namespace VisualSmart.BizService.Implements.SetUp
{
    public class Role_UserBizService : EntityBizService<Role_UserDomain, Role_UserDao>, IRole_UserBizService
    { 
    }
}
