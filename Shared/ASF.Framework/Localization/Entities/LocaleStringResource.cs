using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Framework.Localization.Entities
{
    /// <summary>
    /// Traducción de una clave o "key" a un idioma específico
    /// </summary>
    public class LocaleStringResource
    {
        public int Id { get; set; }
        /// <summary>
        /// Traducción
        /// </summary>
        public string ResourceValue { get; set; }
        /// <summary>
        /// Id de la Clave traducida.
        /// </summary>
        public int LocaleResourceKey_Id { get; set; }
        /// <summary>
        /// Id del idioma en el que se tradujo.
        /// </summary>
        public int Language_Id { get; set; }
    }
}
