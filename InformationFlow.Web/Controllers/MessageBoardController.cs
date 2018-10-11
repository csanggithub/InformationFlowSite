using Common;
using Common.Logging;
using InformationFlow.BLL;
using InformationFlow.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationFlow.Web.Controllers
{
    public class MessageBoardController : BaseController
    {
        // GET: MessageBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MessageBoardPage()
        {
            return View();
        }

        public ActionResult VerCodeIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitMessageBoardInfo(FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Success = true, ErrorMessage = "留言失败，请稍后重试！" }, JsonRequestBehavior.DenyGet);
            }
            try
            {
                var host = HttpContext.Request.Url.Host.ToString() ?? string.Empty;
                var requestUrl = HttpContext.Request.Url.ToString() ?? string.Empty;
                var urlReferrer = HttpContext.Request.UrlReferrer.ToString();
                var userName = HttpUtility.UrlDecode(form["nickname"].ToString() ?? string.Empty);
                var phone = HttpUtility.UrlDecode(form["cellphone"].ToString() ?? string.Empty);
                var sourceurl = HttpUtility.UrlDecode(form["sourceurl"].ToString() ?? string.Empty);//
                var isVerCode = HttpUtility.UrlDecode(form["isVerCode"].ToString() ?? string.Empty);
                var messageContent = HttpUtility.UrlDecode(form["messageInfo"].ToString() ?? string.Empty);
                if(isVerCode=="1")
                {
                    var verCode = HttpUtility.UrlDecode(form["vercode"].ToString() ?? string.Empty);
                    var IsCheckedPass = null != Session["VerCode"] && Session["VerCode"].ToString() == verCode;
                    if (!IsCheckedPass)
                    {
                        return Json(new { Success = false, ErrorMessage = "验证码有误，请重新填写！" }, JsonRequestBehavior.DenyGet);
                    }
                }
                if (string.IsNullOrEmpty(userName))
                {
                    return Json(new { Success = false, ErrorMessage = "姓名不能为空！" }, JsonRequestBehavior.DenyGet);
                }
                if (string.IsNullOrEmpty(phone) || !IsCheckPhone(phone))
                {
                    return Json(new { Success = false, ErrorMessage = "手机号码有误，请重新填写！" }, JsonRequestBehavior.DenyGet);
                }
                var entity = new MessageBoard
                {
                    UserName = HttpUtility.UrlDecode(userName.Trim()),
                    Phone = HttpUtility.UrlDecode(phone.Trim()),
                    MessageContent = HttpUtility.UrlDecode(messageContent.Trim()),
                    ClientIp = IPAddressHelper.GetClientIp(),
                    LocalIp = IPAddressHelper.GetLocalIp(),
                    RequestUrl = string.IsNullOrEmpty(sourceurl)? requestUrl: sourceurl,
                    UrlReferrer = urlReferrer,
                    Host = host,
                    CreateTime = DateTime.Now
                };
                var messageBoard = new MessageBoardBLL();
                messageBoard.Add(entity);
                return Json(new { Success = true, }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Log.Error("留言板留言出现未处理异常", ex.ToString());
                return Json(new { Success = false, ErrorMessage = "留言失败，请稍后重试！" }, JsonRequestBehavior.DenyGet);
            }
        }

        public  ActionResult SendVerCode(string cellphone)
        {
            try
            {
                if(!IsCheckPhone(cellphone))
                {
                    return Json(new { Success = false, ErrorMessage = "短信发送失败！" }, JsonRequestBehavior.DenyGet);
                }
                var verCode= RandomNum();
                Session["VerCode"] = verCode;
                var sms = new SendMessageBLL();
                //var result = sms.SendSmsResponse(cellphone, verCode);
                //if(result)
                //{
                //    return Json(new { Success = true, }, JsonRequestBehavior.DenyGet);
                //}
                return Json(new { Success = false, ErrorMessage = "短信发送失败！" }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Log.Error("短信发送出现未处理异常", ex.ToString());
                return Json(new { Success = false, ErrorMessage = "短信发送失败！" }, JsonRequestBehavior.DenyGet);
            }
        }

    }
}