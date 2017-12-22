using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Framework.Localization.Entities
{
    /// <summary>
    /// Clase que contiene información sobre un idioma específico
    /// </summary>
    public class Language
    {
        public int Id { get; set; }
        /// <summary>
        /// Nombre descriptivo del idioma Ej: Español - Argentina
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nombre de la cultura. Ej: es-AR
        /// </summary>
        public string LanguageCulture { get; set; }
        /// <summary>
        /// Nombre de la imagen de la bandera de la cultura. Ej: argentina.jpg
        /// </summary>
        public string FlagImageFileName { get; set; }
        /// <summary>
        /// Indica si el idioma se lee de derecha a izquierda.
        /// </summary>
        /// <remarks>
        /// ProTip: Podes sacar las imagenes de las banderas de acá http://www.famfamfam.com/lab/icons/flags/
        /// </remarks>
        public bool RightToLeft { get; set; }

        public Language() { }

        /// <summary>
        /// Forma facil de crear idiomas a través de culturas.
        /// </summary>
        /// <param name="culture">Cultura del idioma</param>
        /// <param name="FlagImageFileName">Nombre de la imagen que contiene la bandera del idioma</param>
        public Language(CultureInfo culture, string FlagImageFileName = null)
        {
            this.Name = culture.DisplayName;
            this.LanguageCulture = culture.Name;
            this.RightToLeft = culture.TextInfo.IsRightToLeft;

            this.FlagImageFileName = FlagImageFileName;
        }

        /// <summary>
        /// Obtiene la cultura a la que hace referencia.
        /// </summary>
        public CultureInfo GetCulture
        {
            get { return new CultureInfo(this.LanguageCulture); }
        }
    }
}
