using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks4
{
    public class Html
    {
        public static Html html;
        public static Dictionary<string, string> htmlAttrs;
        public static string htmlString;

        public Html()
        {

        }

        public static Html Tag(string tag)
        {
            htmlString = "<" + tag + "></" + tag + ">";

            htmlAttrs = new Dictionary<string, string>();
            html = new Html();

            return html;
        }

        public Html Attr(string attribute, string value)
        {

            htmlAttrs.Add(attribute, value);
            return html;
        }

        public Html Modify(Action<Html> action)
        {
            action(this);
            return html;
        }


        public Html AddClass(string value)
        {
            htmlAttrs.Add("class", value);
            return html;
        }

        //override ToString()
        public override string ToString()
        {
            string htmlMiddle = "";

            foreach (KeyValuePair<String, String> entry in htmlAttrs)
            {
                htmlMiddle += " " + entry.Key + "=\"" + entry.Value + "\"";

            }

            return htmlString.Replace("><", htmlMiddle + "><");
        }

        //override Equals
        public override bool Equals(System.Object obj)
        {

            if (obj == null)
            {
                return false;
            }

            return (html == (Html)obj);
        }

        //override HashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //override == operator
        public static bool operator ==(string c2, Html c1)
        {
            return c1.ToString() == c2;
        }

        //override != operator
        public static bool operator !=(string c2, Html c1)
        {
            return c1.ToString() != c2;
        }

    }
}
