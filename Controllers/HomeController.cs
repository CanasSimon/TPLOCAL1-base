using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TPLOCAL1.Models;

//L'énoncé du tp et le logo hn sont livrés dans le répertoire /ressources de la solution
//--------------------------------------------------------------------------------------
//Attention, le modèle MVC est un modèle dit de convention plutot que configuration, 
//Le controller doit donc obligatoirement se nommer avec "Controller" à la fin!!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        // méthode appelée par la routeur "naturellement"
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //renvoie vers la vue Index (voir routage dans RouteConfig.cs)
                return View();
            else
            {
                //en fonction du paramètre id, on appelle les différentes pages
                switch (id)
                {
                    case "ListeAvis":
                        var liste = new ListeAvis();
                        var avis = liste.GetAvis(AppDomain.CurrentDomain.BaseDirectory + "/FichierXML/DataAvis.xml");
                        return View(id, avis);
                    case "Formulaire":
                        return View(id);
                    default:
                        //renvoie vers Index (voir routage dans RouteConfig.cs)
                        return View();
                }
            }
        }

        //méthode pour entrer les données du formulaire
        [HttpPost]
        public ActionResult Formulaire(FormulaireModel model)
        {
            if (model.Sexe.Equals(FormulaireModel.Sexes.ToArray()[0]))
            {
                ModelState.AddModelError("Sexe", "Selectionnez un sexe.");
            }

            if (model.Date > DateTime.Parse("01/01/2021"))
            {
                ModelState.AddModelError("Date", "La formation doit avoir commencée avant le 01/01/2021.");
            }

            if (model.Formation.Equals(FormulaireModel.Formations.ToArray()[0]))
            {
                ModelState.AddModelError("Formation", "Selectionnez une formation.");
            }
            else if (model.Formation.Equals(FormulaireModel.Formations.ToArray()[1]) && model.AvisCobol == null)
            {
                ModelState.AddModelError("AvisCobol", "Donnez un avis pour la formation Cobol.");
            }
            else if (model.Formation.Equals(FormulaireModel.Formations.ToArray()[2]) && model.AvisSharp == null)
            {
                ModelState.AddModelError("AvisCobol", "Donnez un avis pour la formation C#.");
            }
            else if (model.Formation.Equals(FormulaireModel.Formations.ToArray()[3]) && 
                (model.AvisCobol == null || model.AvisSharp == null))
            {
                ModelState.AddModelError("AvisCobol", "Donnez un avis pour les deux formations.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(nameof(ValidationFormulaire), model);
        }

        //méthode pour envoyer les données du formulaire vers la page de validation
        [HttpPost]
        public ActionResult ValidationFormulaire(FormulaireModel model)
        {
            return View(model);
        }
    }
}