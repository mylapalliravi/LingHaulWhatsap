using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;
using Longhaul_BO;
using Longhaul_DA;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;


namespace LonghaulWhatsApp.Controllers
{
    public class CustomerController : Controller
    {
        DA.UserDA DB = new DA.UserDA();
        // GET: Customer



        public ActionResult Index()
        {
            return View();
        }

     

        public ActionResult ChannelList()
        {

          
            if (Session["username"] == null)
            {
                BO_Employee obj = new BO_Employee();

                return RedirectToAction("Index", "Home");
            }


            List<BO_Message_Recipients_Status> li = new List<BO_Message_Recipients_Status>();
            try
            {
               
                BO_Message_Recipients_Status MSR_Result = new BO_Message_Recipients_Status();
                MSR_Result = DA_Login.DA_MessageRecipientStatus();

                if(MSR_Result.msg!=null)
                {
                    ViewBag.Exception = MSR_Result.msg;
                }
                //  MSR_Result = DB.Channellist();
                li.Add(MSR_Result);
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
              
            }
            return View("ChannelList", "_Layout", li);
        
        }

        public ActionResult status()
        {

            if (Session["username"].ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Configuration.Default.BasePath = "https://eu184.chat-api.com";

                Session["basepath"] = Configuration.Default.BasePath;
                // Configure API key authorization: instanceId

                if (Configuration.Default.ApiKey.Count == 0)
                {
                    Configuration.Default.ApiKey.Add("instanceId", "198528");
                    // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
                    // Configuration.Default.ApiKeyPrefix.Add("instanceId", "Bearer");
                    // Configure API key authorization: token

                    Configuration.Default.ApiKey.Add("token", "b4c3s3irxqj4pzwf");
                    // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
                    // Configuration.Default.ApiKeyPrefix.Add("token", "Bearer");
                    ViewBag.Apikeys = Configuration.Default.ApiKey.Values;
                    string instanceid = ViewBag.Apikeys[0];
                    string token = ViewBag.Apikeys[1];
                    DA.UserDA Wkeys = new DA.UserDA();
                    Wkeys.Keys_insert(instanceid, token);
                }
               

                var apiInstance = new Class1InstanceApi(Configuration.Default);

                var response200 = apiInstance.GetStatus();
                ViewBag.AccountStatus = response200.AccountStatus.Value.ToString();



                var getqrcode1 = apiInstance.GetQRCode();

               
                InlineResponse2002 result = apiInstance.Expiry();
               

                byte[] byData = ReadFully(getqrcode1);

                var base64 = Convert.ToBase64String(byData);
                var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                ViewBag.img = imgSrc;

               

                
                // Updates the QR code after its expired
                InlineResponse2002 result1 = apiInstance.Expiry();
                Debug.WriteLine(result1);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Class1InstanceApi.Expiry: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
                ViewBag.Exception = e.Message;
            }

            return View("status", "_Layout");
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
          
        public ActionResult Logout()
        {
            try
            {
                var apiInstance = new Class1InstanceApi(Configuration.Default);
                var logout = apiInstance.Logout();
                var logout1 = apiInstance.LogoutAsync();
                var logout2 = apiInstance.LogoutAsyncWithHttpInfo();
                var logout3 = apiInstance.LogoutWithHttpInfo();
                //var logout4=apiInstance.
                ViewBag.logout = "Logout Successfully";
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
                //throw;
            }
            return View("status", "_Layout");
        }



        public ActionResult AutoFileRegexList()
        {
            return View("AutoFileRegexList", "_Layout");
        }

        public ActionResult profile()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View("profile", "_Layout");
        }

        [HttpPost]
        public JsonResult Update_Password(string current_Password, string new_Password, string confirm_Password)
        {
            BO_Employee objResult = new BO_Employee();
           
            try
            {
                string emcd = Session["EntryBy"].ToString();
                string Password = Session["Password"].ToString();
                // objResult = DA_Login.DA_LoginEmployee(emcd, old_Password);

                if (Password == current_Password.Trim())
                {
                    if (new_Password.Trim() == confirm_Password.Trim())
                    {

                        if (current_Password != new_Password.Trim())
                        {
                            DB.Update_Password(new_Password, emcd);
                            Session.Clear();
                            return Json("Updated Successfully...");
                        }
                        else
                        {
                            return Json("New password must different from Current password");
                        }

                    }
                    else
                    {

                        return Json("Re-type Password Not Matched...");
                    }
                }
                else 
                {
                    return Json("Current Password InCorrect...");
                }
              
            }
            catch (Exception e)
            {
                return Json("Exception...");
            }
          
        }

        
    }
}