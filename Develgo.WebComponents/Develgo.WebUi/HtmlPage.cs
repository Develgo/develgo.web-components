using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Develgo.WebUi
{
    public class HtmlPage
    {
        private StringBuilder _page;
        private string _language = "en";
        private string _characterSet = "UTF-8";
        private string _title = "Untitled";
        private string _favIcon = string.Empty;
        private string _bodyClass = string.Empty;
        private string _bodyStyle = string.Empty;
        private IEnumerable<string> _stylesheets;
        private IEnumerable<string> _scripts;

        public HtmlPage()
        {
            _page = new StringBuilder("<!DOCTYPE html>");
        }

        public HtmlPage Language(string language)
        {
            _language = language;
            return this;
        }

        public HtmlPage CharacterSet(string charSet)
        {
            _characterSet = charSet;
            return this;
        }

        public HtmlPage Title(string title)
        {
            _title = title;
            return this;
        }

        public HtmlPage FavIcon(string href)
        {
            _favIcon = href;
            return this;
        }

        public HtmlPage StyleSheet(string href)
        {
            List<string> stylesheets;
            if (_stylesheets == null)
            {
                stylesheets = new List<string>();
            }
            else
            {
                stylesheets = new List<string>(_stylesheets);
            }
            stylesheets.Add(href);
            _stylesheets = stylesheets;
            return this;
        }

        public HtmlPage Script(string href)
        {
            List<string> scripts;
            if (_scripts == null)
            {
                scripts = new List<string>();
            }
            else
            {
                scripts = new List<string>(_scripts);
            }
            scripts.Add(href);
            _scripts = scripts;
            return this;
        }

        public HtmlPage BodyClass(string cssClass)
        {
            _bodyClass = cssClass;
            return this;
        }

        public HtmlPage BodyStyle(string cssStyle)
        {
            _bodyStyle = cssStyle;
            return this;
        }

        public string Render(string content)
        {
            _page.AppendLine($@"<html lang=""{_language}"">");
            RenderHead();
            RenderBody(content);
            _page.Append("</html>");
            return _page.ToString();
        }

        private void RenderHead()
        {
            _page.AppendLine("<head>");
            _page.AppendLine($@"<meta charset=""{_characterSet}"">");
            _page.AppendLine(@"<meta name=""viewport"" content=""width=device-width, initial-scale=1, minimum-scale=1"" />");
            _page.AppendLine($"<title>{_title}</title>");
            if (!string.IsNullOrEmpty(_favIcon))
            {
                _page.AppendLine($@"<link rel=""icon"" href=""{_favIcon}"">");
            }
            if (_stylesheets != null && _stylesheets.Count() > 0)
            {
                foreach (var stylesheet in _stylesheets)
                {
                    _page.AppendLine($@"<link rel=""stylesheet"" href=""{stylesheet}"" type=""text/css"" />");
                }
            }
            if (_scripts != null && _scripts.Count() > 0)
            {
                foreach (var script in _scripts)
                {
                    _page.Append($@"<script src=""{script}""></script>");
                }
            }
            _page.AppendLine("</head>");
        }

        private void RenderBody(string content)
        {
            _page.AppendLine("<body");
            if (!string.IsNullOrEmpty(_bodyClass))
            {
                _page.Append($@" class=""{_bodyClass}""");
            }
            if (!string.IsNullOrEmpty(_bodyStyle))
            {
                _page.Append($@" style=""{_bodyStyle}""");
            }
            _page.Append('>');
            _page.Append(content);
            _page.AppendLine("</body>");
        }
    }
}
