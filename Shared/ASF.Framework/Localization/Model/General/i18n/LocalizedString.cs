using System;
using System.Web;

namespace ASF.Framework.Localization.Model.General.i18n
{
    public class LocalizedString : MarshalByRefObject, IHtmlString
    {
        private readonly string _localized;
        private readonly string _scope;
        private readonly string _textHint;
        private readonly object[] _args;

        public LocalizedString(string localized)
        {
            _localized = localized;
        }

        public LocalizedString(string localized, string scope, string textHint, object[] args)
        {
            _localized = localized;
            _scope = scope;
            _textHint = textHint;
            _args = args;
        }

        public static LocalizedString TextOrDefault(string text, LocalizedString defaultValue)
        {
            return string.IsNullOrEmpty(text) ? defaultValue : new LocalizedString(text);
        }

        public string Scope => _scope;

        public string TextHint => _textHint;

        public object[] Args => _args;

        public string Text => _localized;

        public override string ToString()
        {
            return _localized;
        }

        public string ToHtmlString()
        {
            return _localized;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            if (_localized != null)
            {
                hashCode ^= _localized.GetHashCode();
            }
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var that = (LocalizedString)obj;

            return string.Equals(_localized, that._localized);
        }

    }
}