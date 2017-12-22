using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using ASF.Framework.Localization.Data;
using ASF.Framework.Localization.Entities;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary;

namespace ASF.Framework.Localization
{
    public static class Translator
    {
        /// <summary>
        /// Diccionario que mapea entre las claves y la traduccion correspondiente. Si no encuentra la clave devuelve la misma cadena
        /// </summary>
        static Dictionary<string, string> diccionario;
        static Language idioma;
        ///Regex que Matchea cadenas que se encuentren dentro de "% %" Ej: Mi idioma favorito es %idioma%
        static Regex reg = new Regex("%(.*?)%");

        public static Language IdiomaActual
        {
            get
            {
                if (idioma == null) idioma = ObtenerIdioma("ES-AR");
                return idioma;
            }
            set { idioma = value; }
        }

        public static Dictionary<string, string> Diccionario
        {
            get
            {
                if (diccionario == null) ObtenerDiccionario(IdiomaActual);
                return diccionario;
            }
            set { diccionario = value; }
        }


        /// <summary>
        /// Metodo que intenta traducir con el diccionario actual
        /// </summary>
        /// <param name="str">Cadena a traducir</param>
        /// <returns>Cadena traducida</returns>
        public static string Translate(string cadena)
        {
            if (Diccionario.ContainsKey(cadena)) ///buscar texto a remplazar
                cadena = cadena.Replace(cadena, Diccionario[cadena]); //Remplaza las keys por las cadenas
            return cadena;
        }

        /// <summary>
        /// Extension de la clase string para devolver valores traducidos
        /// </summary>
        /// <param name="str">Cadena a traducir</param>
        /// <returns>Cadena traducida</returns>
        public static string Translated(this string str)
        {
            return Translate(str);
        }


        /// <summary>
        /// Setea el diccionario con las claves y traducciones de un idioma especifico
        /// </summary>
        /// <param name="language"></param>
        public static void ObtenerDiccionario(Language language)
        {
            if (language.Id == 0) language = ObtenerIdioma(language.LanguageCulture);
            if (language == null) throw new ArgumentException("No existe el idioma ingresado");

            List<LocaleResourceKey> keys = ObtenerKeys();

            List<LocaleStringResource> traducciones = ObtenerResourcesPorIdioma(language);

            Diccionario = traducciones.Join(
                keys,
                x => x.LocaleResourceKey_Id,
                y => y.Id,
                (x, y) => new { key = y.Name, trad = x.ResourceValue }
                ).ToDictionary(x => x.key, x => x.trad);
        }



        /// Esta abstracciones están acá si quieren poner los datos en el servicio REST
        #region Abstracciones de Datos
        private static Language ObtenerIdioma(string languageCulture)
        {
            LanguageDAC languageDAC = new LanguageDAC();

            return languageDAC.SelectByLanguageCulture(languageCulture);
        }

        private static List<LocaleResourceKey> ObtenerKeys()
        {
            LocaleResourceKeyDAC localeResourceKeyDAC = new LocaleResourceKeyDAC();
            return localeResourceKeyDAC.Select();
        }

        private static List<LocaleStringResource> ObtenerResourcesPorIdioma(Language language)
        {
            LocaleStringResourceDAC dac = new LocaleStringResourceDAC();
            return dac.SelectByLanguage_Id(language.Id);
        }
        #endregion
    }
}
