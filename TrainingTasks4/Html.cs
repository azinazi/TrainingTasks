using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks4
{
    public class Html
    {
        public Dictionary<string, string> htmlAttrs;
        public List<string> classes;
        public string tagName;

        public Html(string tag)
        {
            tagName = tag;

            htmlAttrs = new Dictionary<string, string>();
            classes = new List<string>();
        }

        public static Html Tag(string tag)
        {

            return new Html(tag);
        }

        public Html Attr(string attribute, string value)
        {

            htmlAttrs.Add(attribute, value);
            return this;
        }

        public Html AddClass(string value)
        {
            classes.Add(value);
            return this;
        }

        public Html Modify(Action<Html> action)
        {
            action(this);
            return this;
        }

        //override ToString()
        public override string ToString()
        {
            string attrString = "";
            string classesString = "";

            foreach (KeyValuePair<String, String> entry in htmlAttrs)
            {
                attrString += " " + entry.Key + "=\"" + entry.Value + "\"";

            }
            
            if (classes.Any())
                classesString = " class=\"" + string.Join(" ", classes) + "\"";

            return "<" + this.tagName + attrString + classesString + "></" + this.tagName + ">";
        }

        public static implicit operator string(Html html)
        {
            return html.ToString();
        }

        ////override Equals
        //public override bool Equals(System.Object obj)
        //{

        //    if (obj == null)
        //    {
        //        return false;
        //    }

        //    return (this == (Html)obj);
        //}

        ////override HashCode
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        ////override == operator
        //public static bool operator ==(string c2, Html c1)
        //{
        //    return c1.ToString() == c2;
        //}

        ////override != operator
        //public static bool operator !=(string c2, Html c1)
        //{
        //    return c1.ToString() != c2;
        //}

    }
}
