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

namespace BARBARES_SistemaWeb.Controllers
{
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<Perfil> p = new List<Perfil>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Perfil);
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
                p = (List<Perfil>)js.Deserialize(objText, typeof(List<Perfil>));
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult List(string nombre, string desde, string hasta, bool estado = false)
        {
            List<Perfil> p = new List<Perfil>();

            Search.Perfil per = new Search.Perfil()
            {
                Nombre = nombre,
                Activo = estado,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(JsonSerializer.search_Perfil(per));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Perfil);
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
                p = (List<Perfil>)js.Deserialize(objText, typeof(List<Perfil>));
            }

            return View(p);
        }

        //
        // GET: /Perfil/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Perfil/Create

        public ActionResult Create()
        {
            List<Rol> sp = new List<Rol>();
            Session["selectedRoles"] = sp;

            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD(); 

            data = encoding.GetBytes("");

           webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Rol);
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
                ViewBag.Roles = (List<Rol>)js.Deserialize(objText, typeof(List<Rol>));
            }

            return View(sp);
        }

        //
        // POST: /Perfil/Create

        [HttpPost]
        public ActionResult Create(string nombre, int[] selectedRoles, bool estado= false)
        {
            //Declaraciones Generales para los request
            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();

            //Seleccciono Roles
            List<Rol> p = new List<Rol>();
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Rol);
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
                p = (List<Rol>)js.Deserialize(objText, typeof(List<Rol>));
            }

            //Obtener Roles seleccionados
            List<Rol> sp = (List<Rol>)Session["selectedRoles"];

            if (selectedRoles == null)
            {
                //Guardar Perfil
                Perfil per = new Perfil()
                {
                    IdPerfil = 0,
                    Nombre = nombre,
                    Activo = estado,
                    FechaCreacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                    UltimaModificacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                };

                data = encoding.GetBytes(JsonSerializer.add_Perfil(per));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Perfil);
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
                    int idPerfil = Int32.Parse(u.Mensaje);

                    //Agregar Productos seleccionados

                    int i = 0;

                    foreach (var rol in sp)
                    {
                        RolXPerfil rxp = new RolXPerfil()
                        {
                            IdRol = rol.IdRol,
                            IdPerfil = idPerfil,
                            IdRolXPerfil = 0,
                            FechaAsignacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"))
                        };

                        data = encoding.GetBytes(JsonSerializer.add_RolXPerfil(rxp));

                        webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_RolXPerfil);
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

                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    ViewBag.Mensaje = u.Mensaje;
                    ViewBag.Perfiles = p;
                    return View(sp);
                }
            }

            foreach (var item in selectedRoles)
            {
                Rol rol = new Rol();

                data = encoding.GetBytes(JsonSerializer.selectById_Rol(item));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectById_Rol);
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
                    rol = (Rol)js.Deserialize(objText, typeof(Rol));
                }

                sp.Add(rol);

            }

            foreach (var i in sp)
            {
                p.RemoveAll(s => s.IdRol == i.IdRol);
            }

            ViewBag.Roles = p;

            Session["selectedProducts"] = sp;

            return View(sp);
        }

        //
        // GET: /Perfil/Edit/5

        public ActionResult Edit()
        {
            return View();
        }

        //
        // POST: /Perfil/Edit/5

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
        // GET: /Perfil/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Perfil/Delete/5

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
