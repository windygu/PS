﻿using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VisualSmart.Domain;
using VisualSmart.Domain.SetUp;

namespace PS.Controllers
{
    [AuthorizeFilter]
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public UserDomain CurrentUser
        {
            get
            {
                return Session["User"] as UserDomain;
            }

        }

        /// <summary>
        /// 添加修改时 基本信息设置
        /// </summary>
        /// <param name="T"></param>
        public void AddOrUpdateBaseInfo(VisualSmart.Domain.Base.Entity T)
        {
            if (T != null && T.Id == 0)
            {
                ViewBag.ViewTitle = "新增";
            }
            else
            {
                ViewBag.ViewTitle = "修改";
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //string loginUrl = "/Account/Login?returnurl=" + Request.RawUrl;
            //if (CurrentUser != null)
            //{
            //if (requestContext.HttpContext.Request.HttpMethod == "GET")
            //{
            //    var controllername = requestContext.RouteData.Values["controller"].ToString().ToLower();
            //    var actionname = requestContext.RouteData.Values["action"].ToString().ToLower();
            //    var currentController = controllername;


            //    List<ComDefinedColumnsEntity> userDefinePages = new ComDefinedColumnsBll().GetUserDefinePages();
            //    if (userDefinePages.Any(t => t.Controller.ToLower() == controllername && t.Action.ToLower() == actionname))
            //    {
            //        if (Request.Cookies["ActionName"] != null)
            //        {
            //            Request.Cookies.Remove("ActionName");
            //        }
            //        HttpCookie actionName = new HttpCookie("ActionName");
            //        actionName.Value = actionname;
            //        Response.AppendCookie(actionName);
            //        if (Request.Cookies["ControllerName"] != null)
            //        {
            //            Request.Cookies.Remove("ControllerName");
            //        }
            //        HttpCookie controllerName = new HttpCookie("ControllerName");
            //        controllerName.Value = controllername;
            //        Response.AppendCookie(controllerName);

            //    }
            //    if (Session["CurrentController"] == null || Session["CurrentController"].ToString() != currentController)
            //    {
            //        controllername = string.Format("'{0}'", controllername);
            //        var currentUrl = string.Format("/{0}", controllername);
            //        if (!string.IsNullOrEmpty(OtherControllers))
            //        {
            //            controllername += "," + OtherControllers;
            //        }
            //        var myAllActions = new MembershipManager().GetUserMenus(CurrentUser.CrmUser.Id, controllername, SystemType.Main);
            //        Session["CurrentUrl"] = currentUrl;
            //        Session["MyAllActions"] = myAllActions.ToLower();
            //    }
            //}
            //}
            //else
            //{
            //    FormsAuthentication.SignOut();
            //    Response.Redirect(loginUrl);
            //}
        }



        /// <summary>
        /// 增加一个合并功能
        /// </summary>
        /// <param name="fristRow">开始行号</param>
        /// <param name="lastRow">结束行号</param>
        /// <param name="fristColumn">开始列号</param>
        /// <param name="lastColumn">结束列号</param>
        /// <param name="title">内容</param>
        /// <param name="hssfworkbook">EXCEL工作簿</param>
        /// <param name="sheet">工作薄</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="alignment">字体对齐方式</param>
        protected void AddRow(int fristRow, int lastRow, int fristColumn, int lastColumn, string title, HSSFWorkbook hssfworkbook, Sheet sheet, short fontSize, NPOI.SS.UserModel.HorizontalAlignment alignment)
        {
            sheet.AddMergedRegion(new CellRangeAddress(fristRow, lastRow, fristColumn, lastColumn - 1));
            sheet.GetRow(fristRow).CreateCell(0).SetCellValue(title);
            for (var i = 1; i < lastColumn; i++)
            {
                sheet.GetRow(fristRow).CreateCell(i).SetCellValue("");
            }
            var subtotalStyle = hssfworkbook.CreateCellStyle();
            subtotalStyle.Alignment = alignment;
            subtotalStyle.VerticalAlignment = VerticalAlignment.CENTER;
            subtotalStyle.BorderTop = CellBorderType.THIN;
            subtotalStyle.BorderBottom = CellBorderType.THIN;
            subtotalStyle.BorderLeft = CellBorderType.THIN;
            subtotalStyle.BorderRight = CellBorderType.THIN;
            subtotalStyle.TopBorderColor = IndexedColors.BLACK.Index;
            subtotalStyle.BottomBorderColor = IndexedColors.BLACK.Index;
            subtotalStyle.LeftBorderColor = IndexedColors.BLACK.Index;
            subtotalStyle.RightBorderColor = IndexedColors.BLACK.Index;
            var font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = fontSize;
            font.Boldweight = 100 * 100;
            var currentRow = sheet.GetRow(fristRow);
            for (var i = 0; i < lastColumn; i++)
            {
                currentRow.GetCell(i).CellStyle = subtotalStyle;
                currentRow.GetCell(i).CellStyle.SetFont(font);
            }
        }


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="folderName">上传文件夹名称</param>
        /// <param name="returntype">返回类型(1:返回文件URL 2:返回文件物理地址(dirpath)|文件URL(url)|文件名(filename)</param>
        /// <param name="zip">是否需要压缩文件(1:是 0:否)</param>
        /// <returns></returns>
        public string FileUpload(int returntype = 1)
        {
            var urlpath = string.Format(@"/UploadFiles/WeChat/{0}/", Guid.NewGuid());
            var dirpath = Server.MapPath(urlpath);
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            if (System.Web.HttpContext.Current.Request.Files.Count == 0)
            {
                return string.Empty;
            }
            var postedFile = System.Web.HttpContext.Current.Request.Files[0];
            if (postedFile == null)
            {
                return string.Empty;
            }

            var filename = postedFile.FileName.ToLower();
            postedFile.SaveAs(dirpath + filename);

            string url = returntype.Equals(1)
                       ? string.Format("{0}{1}", urlpath, filename)
                       : string.Format("{0}|{1}|{2}", dirpath, Url, filename);

            return url;
        }

    }
}