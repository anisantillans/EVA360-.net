using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Helpers;
using TrabajoFinal.ViewModels.Evaluation;
using TrabajoFinal.Models;
using System.Transactions;

namespace TrabajoFinal.Controllers
{
    public class EvaluationController : BaseController
    {
        // GET: Evaluation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LstPeriodoEmpleado(Int32 PeriodoId)
        {
            var model = new LstPeriodoEmpleadoViewModel();
            model.CargarDatos(context, PeriodoId);
            return View(model);
        }
        public ActionResult EliminarPeriodoEmpleado(Int32 EmpleadoPeriodoId)
        {
            var PeriodoId = 0;
            try
            {
                var EmpleadoPeriodo = context.EmpleadoPeriodo.FirstOrDefault(x => x.EmpleadoPeriodoId == EmpleadoPeriodoId);
                PeriodoId = EmpleadoPeriodo.PeriodoId;
                context.EmpleadoPeriodo.Remove(EmpleadoPeriodo);
                context.SaveChanges();
                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstPeriodoEmpleado",new { PeriodoId = PeriodoId });
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstPeriodoEmpleado", new { PeriodoId = PeriodoId });
            }
        }
        public ActionResult AddEditPeriodoEmpleado(Int32? PeriodoId, Int32? EmpleadoPeriodoId)
        {
            var model = new AddEditPeriodoEmpleadoViewModel();
            model.CargarDatos(context, PeriodoId, EmpleadoPeriodoId);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditPeriodoEmpleado(AddEditPeriodoEmpleadoViewModel model)
        {
            try
            {
                using (var Transaction = new TransactionScope())
                {
                    EmpleadoPeriodo EmpleadoPeriodo = null;
                    if (model.EmpleadoPeriodoId.HasValue)
                    {
                        EmpleadoPeriodo = context.EmpleadoPeriodo.FirstOrDefault(x => x.EmpleadoPeriodoId == model.EmpleadoPeriodoId);
                    }
                    else
                    {
                        EmpleadoPeriodo = new EmpleadoPeriodo();
                        EmpleadoPeriodo.SupervisorId = Convert.ToInt32(Session["UsuarioId"].ToString());
                        EmpleadoPeriodo.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                        EmpleadoPeriodo.EmpleadoId = model.EmpleadoId;
                        EmpleadoPeriodo.FechaCreacion = DateTime.Now;
                        context.EmpleadoPeriodo.Add(EmpleadoPeriodo);
                    }

                    EmpleadoPeriodo.PeriodoId = model.PeriodoId.Value;
                    EmpleadoPeriodo.EmpleadoId = model.EmpleadoId;
                    EmpleadoPeriodo.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    EmpleadoPeriodo.FechaModificacion = DateTime.Now;

                    context.SaveChanges();
                    Transaction.Complete();
                    PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                    
                }
                return RedirectToAction("LstPeriodoEmpleado", new { PeriodoId = model.PeriodoId });
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstPeriodoEmpleado", new { PeriodoId = model.PeriodoId });
            }
        }
        public ActionResult LstPeriodo()
        {
            var model = new LstPeriodoViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditPeriodo(Int32? PeriodoId)
        {
            var model = new AddEditPeriodoViewModel();
            model.CargarDatos(context, PeriodoId);
            return View(model);
        }
        public ActionResult EliminarPeriodo(Int32? PeriodoId)
        {
            try
            {
                var Periodo = context.Periodo.FirstOrDefault(x => x.PeriodoId == PeriodoId);
                Periodo.Estado = ConstantHelpers.ESTADO_USUARIO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstPeriodo");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstPeriodo");
            }
        }
        [HttpPost]
        public ActionResult AddEditPeriodo(AddEditPeriodoViewModel model)
        {
            try
            {
                using (var Transaction = new TransactionScope())
                {
                    Periodo Periodo = null;
                    if (model.PeriodoId.HasValue)
                    {
                        Periodo = context.Periodo.FirstOrDefault(x => x.PeriodoId == model.PeriodoId);
                    }
                    else
                    {
                        Periodo = new Periodo();
                        Periodo.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                        Periodo.FechaCreacion = DateTime.Now;
                        Periodo.Estado = ConstantHelpers.ESTADO_USUARIO.ACTIVO;
                        context.Periodo.Add(Periodo);
                    }

                    Periodo.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Periodo.FechaModificacion = DateTime.Now;

                    Periodo.Nombre = model.Nombre;
                    Periodo.FechaFin = model.FechaFin;
                    Periodo.FechaInicio = model.FechaInicio;

                    context.SaveChanges();
                    Transaction.Complete();
                    PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                    
                }
                return RedirectToAction("LstPeriodo");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                model.CargarDatos(context, model.PeriodoId);
                return View(model);
            }
        }
        public ActionResult LstObjetivo()
        {
            var model = new LstObjetivoViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditObjetivo(Int32? ObjetivoId )
        {
            var model = new AddEditObjetivoViewModel();
            model.CargarDatos(context, ObjetivoId);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditObjetivo(AddEditObjetivoViewModel model)
        {
            try
            {
                using (var Transaction = new TransactionScope())
                {
                    Objetivo Objetivo = null;
                    if (model.ObjetivoId.HasValue)
                    {
                        Objetivo = context.Objetivo.FirstOrDefault(x => x.ObjetivoId == model.ObjetivoId);
                    }
                    else
                    {
                        Objetivo = new Objetivo();
                        Objetivo.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                        Objetivo.FechaCreacion = DateTime.Now;
                        context.Objetivo.Add(Objetivo);
                    }
                    Objetivo.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Objetivo.FechaModificacion = DateTime.Now;
                    Objetivo.Nombre = model.Nombre;
                    Objetivo.Orden = model.Orden;
                    Objetivo.Descripcion = model.Descripcion;
                    Objetivo.PeriodoId = model.PeriodoId;

                    context.SaveChanges();
                    Transaction.Complete();
                    PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                }
                return RedirectToAction("LstObjetivo");
            }
            catch(Exception ex)
            {
                TryUpdateModel(model);
                return View(model);
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
            }
             
        }
       public ActionResult LstTema()
        {
            var model = new LstTemaViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditTema(Int32? TemaId)
        {
            var model = new AddEditTemaViewModel();
            model.CargarDatos(context,TemaId);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult AddEditTema(AddEditTemaViewModel model)
        {
            try{
                using (var Transaction= new TransactionScope())
                {
                    Tema Tema = null;
                    if (model.TemaId.HasValue)
                    {
                        Tema = context.Tema.FirstOrDefault(x => x.TemaId == model.TemaId);
                    }else
                    {
                        Tema = new Tema();
                        Tema.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                        Tema.FechaCreacion = DateTime.Now;
                        context.Tema.Add(Tema);
                    }
                    Tema.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Tema.FechaModificacion = DateTime.Now;
                    Tema.Nombre = model.Nombre;
                    Tema.Orden = model.Orden;
                    Tema.Descripcion = model.Descripcion;
                    Tema.ObjetivoId = model.ObjetivoId;
                    context.SaveChanges();
                    Transaction.Complete();
                    PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                }
                return RedirectToAction("LstTema");
            }catch (Exception ex)
            {
                TryUpdateModel(model);
                return View(model);
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");

            }
        }
        public ActionResult LstEvaluation()
        {
            var model = new LstEvaluationViewModel();
            model.CargarDatos(context);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetTemasPorObjetivo(Int32 ObjetivoId, Int32 PeriodoId, Int32 EmpleadoId)
        {
            var LstTemaId = new List<Int32>();
            var LstEvaluacionTema = context.EvalucionTema.Where(x => x.Evaluacion.PeriodoId == PeriodoId && x.Evaluacion.EmpleadoId == EmpleadoId).ToList();

            if (LstEvaluacionTema.Count > 0)
                LstTemaId = LstEvaluacionTema.Select(x => x.TemaId).ToList();

            var resultado = context.Tema.Where(x => x.ObjetivoId == ObjetivoId && LstTemaId.Contains(x.TemaId) == false).Select(y => new { TemaId = y.TemaId, Nombre = y.Nombre }).ToList();
            return Json(resultado);
        }

        public ActionResult AddEvaluationFast()
        {
            var model = new AddEvaluationFastViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEvaluationFast(AddEvaluationFastViewModel model)
        {
            try
            {

                using (var transaction = new TransactionScope())
                {
                    var EvaluacionTema = new EvalucionTema();
                    var Evaluacion = context.Evaluacion.FirstOrDefault(x => x.PeriodoId == model.PeriodoId && x.EmpleadoId == model.EmpleadoId);

                    //EvalucionTema EvaluacionTema = new EvalucionTema();
                    //Evaluacion.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    //Evaluacion.FechaCreacion = DateTime.Now;
                    //Evaluacion.Nombre = model.Nombre;
                    //Evaluacion.PorcentajeAvance = ((context.EvalucionTema.Count()+1)/context.Tema.Count())*100;
                    //Evaluacion.SupervisorId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    //Evaluacion.EmpleadoId = model.EmpleadoId;

                    //Evaluacion.UsuarioModificacionId= Convert.ToInt32(Session["UsuarioId"].ToString());
                    //Evaluacion.FechaModificacion = DateTime.Now;

                    context.EvalucionTema.Add(EvaluacionTema);
                    EvaluacionTema.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    EvaluacionTema.FechaCreacion = DateTime.Now;
                    EvaluacionTema.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    EvaluacionTema.FechaModificacion = DateTime.Now;
                    EvaluacionTema.EvaluacionId = Evaluacion.EvaluacionId;
                    EvaluacionTema.TemaId = model.TemaId;
                    EvaluacionTema.Puntaje = model.Puntaje;
                    
                    context.SaveChanges();
                    transaction.Complete();
                    PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                }
                return RedirectToAction("AddEvaluationFast");
            }
            catch (Exception e)
            {
                TryUpdateModel(model);
                return View(model);
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
            }
        }
        public ActionResult AddInforme(Int32? EvaluacionId)
        {
            var model = new AddInformeViewModel();
            if (EvaluacionId.HasValue)
            {
                var objEvaluacion = context.Evaluacion.FirstOrDefault(x => x.EvaluacionId == EvaluacionId);
                model.CargarDatos(objEvaluacion);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddInforme(AddInformeViewModel model)
        {
            Evaluacion Evaluacion = null;
            if (model.EvaluacionId.HasValue 
                && Request.Files["Archivo"]!=null)
            {
                Evaluacion= context.Evaluacion.FirstOrDefault(x => x.EvaluacionId == model.EvaluacionId);
                
                Evaluacion.ProveedorId = Convert.ToInt32(Session["UsuarioId"].ToString());
                var filename = "INF_" + DateTime.Now.Ticks + "_" + Request.Files["Archivo"].FileName;
                var filepath = Server.MapPath("~/Content/INF/" + filename);
                Request.Files["Archivo"].SaveAs(filepath);
                Evaluacion.RutaInforme = filename;

                context.SaveChanges();
                PostMessage(MessageType.Success, "El informe 360 fue guardado de forma correcta");
                return RedirectToAction("LstEvaluation");
            }
            else
            {
                return View(model);
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
            }
        }
        public ActionResult PuntosAcumulados()
        {
            //var empleado = Convert.ToInt32(Session["UsuarioId"].ToString());
            var model = new PuntosAcumuladosViewModel();
            model.CargarDatos(context, Convert.ToInt32(Session["UsuarioId"].ToString()));
            return View(model);
        }


        public ActionResult AddEditEvaluation(Int32? EvaluacionId)
        {
            var viewModel = new AddEditEvaluationViewModel();
            viewModel.Cargar(context, EvaluacionId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddEditEvaluation(AddEditEvaluationViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                using (var transaction = new TransactionScope())
                {
                    var evaluacion = new Evaluacion();
                    if (model.evaluacionId.HasValue)
                    {
                        evaluacion = context.Evaluacion
                            .FirstOrDefault(x => x.EvaluacionId == model.evaluacionId);
                    }
                    else
                    {
                        context.Evaluacion.Add(evaluacion);
                    }

                    evaluacion.Nombre = model.nombre;
                    evaluacion.PorcentajeAvance = ((context.EvalucionTema.Count() + 1) / context.Tema.Count()) * 100;
                    evaluacion.SupervisorId = Convert.ToInt32(Session["UsuarioId"]);
                    evaluacion.EmpleadoId = model.empleadoId;
                    var id = context.Periodo
                        .FirstOrDefault(x => x.FechaInicio < DateTime.Now && x.FechaFin > DateTime.Now);
                    evaluacion.PeriodoId = id.PeriodoId;
                    evaluacion.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"]);
                    evaluacion.FechaCreacion = DateTime.Now;

                    //agregar zona de evaluacion tema

                    context.SaveChanges();
                    transaction.Complete();
                }

                return RedirectToAction("LstEvaluation");
            }
            catch (Exception ex)
            {
                var context = new EVA360Entities();
                var viewModel = new AddEditEvaluationViewModel();
                viewModel.Lstempleado = context.Empleado.ToList();
                TryUpdateModel(model);
                return View(model);
            }
        }
        /*=========================ZONA EVALUACION TEMA==========================0*/

        public ActionResult Calificar(Int32? EvaluacionId, Int32? EvaluacionTemaId)
        {
            var viewModel = new CalificarViewModel();
            viewModel.CargarDatosCalificar(context, EvaluacionId, EvaluacionTemaId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Calificar(CalificarViewModel model)
        {
            try
            {
                var tId = context.Tema.Where(x => x.Objetivo.Periodo.FechaInicio < DateTime.Now && x.Objetivo.Periodo.FechaFin > DateTime.Now).ToList();
                var h = 1;
                Evaluacion eva = new Evaluacion();
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                for (int i = 0; i < model.LstPuntuacion.Count(); i++)
                {
                    using (var transaction = new TransactionScope())
                    {


                        EvalucionTema evaluaciontema = new EvalucionTema();
                        if (!model.evaluacionTemaId.HasValue)
                        {
                            context.EvalucionTema.Add(evaluaciontema);
                        }

                        evaluaciontema.EvaluacionId = model.evaluacionId;
                        evaluaciontema.TemaId = h;
                        evaluaciontema.Puntaje = model.LstPuntuacion[i];
                        evaluaciontema.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"]);
                        evaluaciontema.FechaCreacion = DateTime.Now;

                        context.SaveChanges();
                        transaction.Complete();
                    }
                    h++;
                    if (i == model.LstPuntuacion.Count() - 1)
                    {
                        eva.PorcentajeAvance = 100;
                        context.SaveChanges();
                    }
                }


                return RedirectToAction("LstEvaluation");
            }
            catch (Exception ex)
            {
                var context = new EVA360Entities();
                var viewModel = new CalificarViewModel();
                TryUpdateModel(model);
                return View(model);
            }
        }

    }
}