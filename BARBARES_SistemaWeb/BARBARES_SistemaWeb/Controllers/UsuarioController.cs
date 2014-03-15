using BARBARES_SistemaWeb.Models;
using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace BARBARES_SistemaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string contrasena, bool recordar = false)
        {
            Debug.WriteLine(Utils.Utils.GetSHA1(usuario, contrasena), "NET");

            Debug.WriteLine(Utils.Utils.GetSHA1NSS(usuario, contrasena), "NSS");

            ResponseBD u = new ResponseBD();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(JsonSerializer.login_Usuario(usuario, contrasena));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Login_Usuario);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                u = (ResponseBD)js.Deserialize(objText, typeof(ResponseBD));
            }

            if (u.Flujo.Equals(Constantes.OK))
            {
                int timeout = recordar ? 525600 : 2; // Timeout in minutes,525600 = 365 days
                var ticket = new FormsAuthenticationTicket(usuario, recordar, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);//My Line
                cookie.HttpOnly = true; // cookie not available in javascript.
                Response.Cookies.Add(cookie);
                Session["usuario"] = usuario;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = u.Mensaje;
                return View();
            }
        }

        public ActionResult List()
        {
            List<Select.Usuario> u = new List<Select.Usuario>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Usuario);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                u = (List<Select.Usuario>)js.Deserialize(objText, typeof(List<Select.Usuario>));
            }

            return View(u);
        }

        [HttpPost]
        public ActionResult List(string nombre, string desde, string hasta, bool estado = false)
        {
            List<Select.Usuario> u = new List<Select.Usuario>();

            Search.Usuario usu = new Search.Usuario()
            {
                Nombre = nombre,
                Activo = estado,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(JsonSerializer.search_Usuario(usu));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Usuario);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                u = (List<Select.Usuario>)js.Deserialize(objText, typeof(List<Select.Usuario>));
            }

            return View(u);
        }
     
        public ActionResult List_Log()
        {
            List<Select.LogUsuario> l = new List<Select.LogUsuario>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_LogUsuario);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                l = (List<Select.LogUsuario>)js.Deserialize(objText, typeof(List<Select.LogUsuario>));
            }

            return View(l);
        }

        [HttpPost]
        public ActionResult List_Log(string nombre, string desde, string hasta, string accion)
        {
            List<Select.LogUsuario> l = new List<Select.LogUsuario>();

            Search.LogUsuario log = new Search.LogUsuario()
            {
                Nombre = nombre,
                Accion = accion,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(JsonSerializer.search_LogUsuario(log));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_LogUsuario);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                l = (List<Select.LogUsuario>)js.Deserialize(objText, typeof(List<Select.LogUsuario>));
            }

            return View(l);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            //Select Perfiles
            encoding = new ASCIIEncoding();
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Perfil);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Perfiles = (List<Perfil>)js.Deserialize(objText, typeof(List<Perfil>));
            }

            List<Perfil> sp = new List<Perfil>();

            Session["selectedPerfiles"] = sp;

            return View(sp);
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(string nombre, int[] selectedPerfiles, bool estado = false, int tienda = 0)
        {
            //Declaraciones Generales para los request
            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();

            //Select Perfiles
            List<Perfil> p = new List<Perfil>();
            encoding = new ASCIIEncoding();
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Perfil);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                p = (List<Perfil>)js.Deserialize(objText, typeof(List<Perfil>));
            }

            //Obtener Perfiles seleccionados
            List<Perfil> sp = (List<Perfil>)Session["selectedPerfiles"];

            if (selectedPerfiles == null)
            {
                //Guardar Contraseña
                int idContrasena = 1;


                //Guardar Usuario
                Usuario usu = new Usuario()
                {
                    IdUsuario = 0,
                    Nombre = nombre,
                    IdContrasena = idContrasena,
                    Activo = estado,
                    FechaCreacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                    UltimaModificacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                };

                data = encoding.GetBytes(JsonSerializer.add_Usuario(usu));

                Debug.WriteLine(JsonSerializer.add_Usuario(usu));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Usuario);
                webrequest.Method = Constantes.PostMethod;
                webrequest.ContentType = Constantes.ContentType;
                webrequest.ContentLength = data.Length;

                newStream = webrequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                webresponse = (HttpWebResponse)webrequest.GetResponse();

                using (var reader = new StreamReader(webresponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    u = (ResponseBD)js.Deserialize(objText, typeof(ResponseBD));
                }

                if (u.Flujo.Equals(Constantes.OK))
                {
                    int idUsuario = Int32.Parse(u.Mensaje);

                    //Agregar Productos seleccionados

                    int i = 0;

                    foreach (var per in sp)
                    {
                        PerfilXUsuario pxu = new PerfilXUsuario()
                        {
                            IdUsuario = idUsuario,
                            IdPerfil= per.IdPerfil,
                            IdPerfilXUsuario = 0,
                            FechaAsignacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"))
                        };

                        data = encoding.GetBytes(JsonSerializer.add_PerfilXUsuario(pxu));

                        webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_PerfilXUsuario);
                        webrequest.Method = Constantes.PostMethod;
                        webrequest.ContentType = Constantes.ContentType;
                        webrequest.ContentLength = data.Length;

                        newStream = webrequest.GetRequestStream();
                        newStream.Write(data, 0, data.Length);
                        newStream.Close();

                        webresponse = (HttpWebResponse)webrequest.GetResponse();

                        using (var reader = new StreamReader(webresponse.GetResponseStream()))
                        {
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            var objText = reader.ReadToEnd();
                            u = (ResponseBD)js.Deserialize(objText, typeof(ResponseBD));
                        }

                        if (u.Flujo.Equals("ERROR"))
                        {
                            ViewBag.Mensaje = u.Mensaje;
                            ViewBag.Productos = sp;
                            return View(p);
                        }

                        i++;
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = u.Mensaje;
                    ViewBag.Perfiles = p;
                    return View(sp);
                }
            }

            foreach (var item in selectedPerfiles)
            {
                Perfil prd = new Perfil();

                data = encoding.GetBytes(JsonSerializer.selectById_Perfil(item));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectById_Perfil);
                webrequest.Method = Constantes.PostMethod;
                webrequest.ContentType = Constantes.ContentType;
                webrequest.ContentLength = data.Length;

                newStream = webrequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                webresponse = (HttpWebResponse)webrequest.GetResponse();

                using (var reader = new StreamReader(webresponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    prd = (Perfil)js.Deserialize(objText, typeof(Perfil));
                }

                sp.Add(prd);

            }

            foreach (var i in sp)
            {
                p.RemoveAll(s => s.IdPerfil == i.IdPerfil);
            }

            ViewBag.Perfiles = p;

            Session["selectedProducts"] = sp;

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }
 
            return View(sp);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            //Select Perfil
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Perfil);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Perfil = (List<Perfil>)js.Deserialize(objText, typeof(List<Perfil>));
            }

            return View();
        }

        //
        // POST: /Usuario/Edit/5

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

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Delete/5

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
