using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Framework.Localization.Entities
{
    /// <summary>
    /// Describe a una Clave o "Key" que será remplazada por una localización correspondiente en la página web.
    /// </summary>
    public class LocaleResourceKey
    {
        public int Id { get; set; }
        /// <summary>
        /// Clave que identifica a una traducción.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Notas sobre la traducción.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Fecha en la que se añadió
        /// </summary>
        public DateTime DateAdded { get; set; }
    }
}
