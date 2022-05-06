using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Websistmedico.Models;
using System.Net;
using System.Data.Entity;

namespace Websistmedico.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con;
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=LAPTOP-ARQQ4BPU\\SQLEXPRESS;Initial Catalog=horas;Integrated Security=true");
            con.Open();


            DataContext dbmedico = new DataContext();
            ViewBag.medico = new SelectList(dbmedico.tabmedico, "ap", "nombres");


            con.Close();

            return View();

        }



        [HttpPost]
        public ActionResult About(string fecha, int horad, int horah, string especialidad,string ap,string nombre)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=LAPTOP-ARQQ4BPU\\SQLEXPRESS;Initial Catalog=horas;Integrated Security=true");
            con.Open();


            if (Request.HttpMethod == "POST")
            {
                Response.Redirect("About", false);

                DataContext dbmedico = new DataContext();
                ViewBag.medico = new SelectList(dbmedico.tabmedico, "ap", "nombres");

                string cona = "SELECT count(*) FROM thoras";
                SqlCommand sc1 = new SqlCommand(cona, con);
                int icon = Convert.ToInt32(sc1.ExecuteScalar());

                string espe = "SELECT especialidad FROM tmedico where nombres='" + nombre + "'";
                SqlCommand sespe = new SqlCommand(espe, con);
                string especial = Convert.ToString(sespe.ExecuteScalar());

                if (icon == 0)
                {

                    for (int ciclo = horad - 1; ciclo < horah; ciclo++)
                    {

                        int horaf = ciclo + 1;
                        string horaf2 = String.Format("{0:00}", horaf);
                        using (var ctatrans = new DataContext())
                        {
                            int salida = ctatrans.Database.ExecuteSqlCommand("Insert into thoras Values({0},{1},{2},{3},{4},{5},{6}) ", fecha, horaf2,ap,nombre,especial,"pendiente","nn");

                        }

                    }

                }


                /*************************************************************************************************/
                  string contana = "SELECT count(*) FROM thoras";
                    SqlCommand sql1 = new SqlCommand(contana, con);
                    int incon = Convert.ToInt32(sql1.ExecuteScalar());

                    string strespe = "SELECT especialidad FROM medico where nombres='" + dbmedico + "'";
                    SqlCommand sqlespe = new SqlCommand(strespe, con);
                    string stespecial = Convert.ToString(sqlespe.ExecuteScalar());

                    string stfecha = "SELECT fecha FROM thoras ";
                    SqlCommand sqlfcha = new SqlCommand(stfecha, con);
                    string salidafecha = Convert.ToString(sqlfcha.ExecuteScalar());
   
                    string sthora = "SELECT hora FROM thoras ";
                    SqlCommand sqlhora = new SqlCommand(sthora, con);
                    int salidahora= Convert.ToInt32(sqlhora.ExecuteScalar());


                    string snombre= "SELECT nombre FROM thoras ";
                   SqlCommand sqlnombre = new SqlCommand(snombre, con);
                   string salidanombre = Convert.ToString(sqlnombre.ExecuteScalar());





                /****************************************************************************/
                if (incon > 0 && salidanombre!=nombre && fecha != salidafecha && salidahora != horad && salidahora != horah)
                    {

                        for (int ciclo = horad - 1; ciclo < horah; ciclo++)
                        {

                            int horaf = ciclo + 1;
                            string horaf2 = String.Format("{0:00}", horaf);
                            using (var ctatranss = new DataContext())
                            {
                                int salidaa = ctatranss.Database.ExecuteSqlCommand("Insert into thoras Values({0},{1},{2},{3},{4},{5},{6}) ", fecha, horaf2, ap, nombre, especial, "pendiente", "nn");

                            }

                        }

                    }
                    /****************************************************************/

                    if (incon > 0 && fecha == salidafecha && salidahora!=horad && salidahora!=horah )
                    {

                        for (int ciclo = horad - 1; ciclo < horah; ciclo++)
                        {

                            int horaf = ciclo + 1;
                            string horaf2 = String.Format("{0:00}", horaf);
                            using (var ctatranss = new DataContext())
                            {
                                int salidaa = ctatranss.Database.ExecuteSqlCommand("Insert into thoras Values({0},{1},{2},{3},{4},{5},{6}) ", fecha, horaf2, ap, nombre, especial, "pendiente", "nn");

                            }

                        }

                    }
                /****************************************************************/

               



                /****************************************************************/

                if (incon > 0 && fecha == salidafecha && horad == salidahora && horah==salidahora)
                {
                    /*************************************************************************************************/
                }
               
               
            }
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult CreaMedico()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult CreaMedico([Bind(Include = "id,ap,am,nombres,rut,dv,correo,titulo,especialidad,celular,comuna")] CMedico medico)
        {

                  con= new SqlConnection("Data Source=LAPTOP-ARQQ4BPU\\SQLEXPRESS;Initial Catalog=horas;Integrated Security=true");
                  con.Open();
            try
            {
                if (ModelState.IsValid)
                {
                    db.tabmedico.Add(medico);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                 con.Close();
                return View(medico);
                

            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult Paciente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Paciente([Bind(Include = "id,ap,am,nombres,rut,dv,sexo,correo,prevision,edad,celular")] CPaciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tabpaciente.Add(paciente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(paciente);

            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public ActionResult listapaciente()
        {
            return View(db.tabpaciente.ToList());
        }


        [HttpGet]
        public ActionResult listamedicos()
        {
            return View(db.tabmedico.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMedico medico = db.tabmedico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);


        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ap,am,nombres,rut,dv,correo,titulo,especialidad,celular,comuna")] CMedico medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(medico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(medico);


            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edita(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPaciente paciente = db.tabpaciente.Find(id);
            if (paciente== null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edita([Bind(Include = "id,ap,am,nombres,rut,dv,sexo,correo,prevision,edad,celular")] CPaciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(paciente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(paciente);


            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Generahoras([Bind(Include = "id,fecha,hora,ap,nombres,especialidad,estado,paciente")] CHoras horas)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(horas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(horas);


            }
            catch
            {
                return View();
            }
        }

 
        [HttpGet]
        public ActionResult Pedirhora()
        {


            return View(db.tabhoras.ToList());

        }


        [HttpGet]
        public ActionResult PedirEdita(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           CHoras horas = db.tabhoras.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            return View(horas);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PedirEdita([Bind(Include = "id,fecha,hora,ap,nombre,especialidad,estado,paciente")] CHoras horas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(horas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(horas);


            }
            catch
            {
                return View();
            }
        }

    }
}