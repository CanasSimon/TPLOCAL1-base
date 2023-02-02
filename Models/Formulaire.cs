using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TPLOCAL1.Models
{
    public class FormulaireModel
    {
        public static IEnumerable<string> Sexes = new List<string> {
            "Sélectionner un sexe",
            "Homme",
            "Femme",
            "Autre"
        };

        public static IEnumerable<string> Formations = new List<string> {
            "Sélectionner une formation",
            "Formation Cobol",
            "Formation objet",
            "Formation double compétence"
        };

        // Informations personelles
        [Required(ErrorMessage = "Le nom de famille est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom de famille est requis.")]
        public string Prenom { get; set; }

        [Required]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        public string Adresse { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Entrez un code postal valide.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "La ville est requise.")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "L'adresse mail est requise.")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$", ErrorMessage = "Entrez une adresse mail valide.")]
        public string Mail { get; set; }

        // Informations formation suivie
        [Required(ErrorMessage = "La date est requise.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Formation { get; set; }

        // Avis sur la formation
        public string AvisCobol { get; set; }

        public string AvisSharp { get; set; }
    }
}
