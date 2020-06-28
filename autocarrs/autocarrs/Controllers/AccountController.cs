using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json; //for stringify
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using autocarrs.Models;
using Facebook;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using System.Runtime.Serialization;
using System.Configuration;
using System.Text;

namespace autocarrs.Controllers
{
    public class AccountController : Controller
    {
        // private IFacebookService _facebookService;
        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44363/";
        

        [HttpPost]
        public async Task<ActionResult> Login(string UserId, string UserPassword)
        {
            SiteUsers SiteUsers = new SiteUsers();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                var abc = Request.QueryString["UserId"];
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource PostSiteUsers using HttpClient  
                UriBuilder builder = new UriBuilder("https://localhost:44363/api/SiteUsers/CheckLogin?");

                //builder.Query = "id=mars&UserPassword=mars";

                builder.Query = "id=" + UserId + "&UserPassword=" + UserPassword;

                               
                HttpResponseMessage Res = await client.GetAsync(builder.Uri);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SiteUser = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    SiteUsers = JsonConvert.DeserializeObject<SiteUsers>(SiteUser);
                    ViewBag.SiteUsers = SiteUsers;
                    ViewBag.Error = null;
                    return View("Welcome", SiteUsers);
                }
                else
                {
                    Error err = new Error();
                    err.ErrorMessage = "Wrong UserId or Password";
                    ViewBag.Error = err;
                    ViewBag.SiteUsers = null;
                    return View("Error", err);
                }
            }
            

        }

        [HttpGet]
        public ActionResult LoginWithFaceBook()
        {
            FaceBookConnect.API_Key = "317988162529177";
            FaceBookConnect.API_Secret = "6e2dab9677f176a9fd4006018b4d1e35";

            FaceBookUser faceBookUser = new FaceBookUser();
            if (Request.QueryString["error"] == "access_denied")
            {
                ViewBag.Message = "User has denied access.";
            }
            else
            {
                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
                    faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                }
                else
                {
                    FaceBookConnect.Authorize("user_photos,email", string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Authority, "Home/Index/"));
                    string code1 = Request.QueryString["code"];
                    if (!string.IsNullOrEmpty(code1))
                    {
                        string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
                        faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                        faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    }
                    return new EmptyResult();

                }
            }

            return View(faceBookUser);
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
        

        // POST: Account/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            SiteUsers siteusers = new SiteUsers
            {
                UserId = collection["UserId"],
                UserFName = collection["UserFName"],
                UserMName = collection["UserMName"],
                UserLName = collection["UserLname"],
                UserEmail = collection["UserEmail"],
                UserPassword = collection["UserPassword"],
                IsActive = 1,
                IsDeleted = 0,
                UserType = "N",
                RegDate = DateTime.Now
            };

            string output = JsonConvert.SerializeObject(siteusers);
            try
            {
                var data = new StringContent(output, Encoding.UTF8, "application/json");

                var url = "https://localhost:44363/api/SiteUsers/CreateSiteUsers";

                var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                var SiteUser = response.Content.ReadAsStringAsync().Result;

                var a = JsonConvert.DeserializeObject<SiteUsers>(SiteUser);
                ViewBag.SiteUsers = a;
                return View("welcome", a);

            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
