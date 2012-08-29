using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks4
{
    public class Html
    {
        public Dictionary<string, object> htmlAttrs;
        public List<string> classes;
        public string tagName;
        private bool _selfEnding = false;

        public Html(string tag)
        {
            tagName = tag;

            htmlAttrs = new Dictionary<string, object>();
            classes = new List<string>();
        }

        public static Html Tag(string tag)
        {

            return new Html(tag);
        }

        public Html Attr(string attribute, object value)
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

        public Html selfEnding()
        {
            _selfEnding = true;
            return this;
        }

        //override ToString()
        public override string ToString()
        {
            string attrString = "";
            string classesString = "";

            foreach (KeyValuePair<String, object> entry in htmlAttrs)
            {
                attrString += " " + entry.Key + "=\"" + entry.Value + "\"";

            }

            if (classes.Any())
                classesString = " class=\"" + string.Join(" ", classes) + "\"";

            if (_selfEnding)
            {
                return "<" + this.tagName + attrString + classesString + " />";
            }
            else
                return "<" + this.tagName + attrString + classesString + "></" + this.tagName + ">";
        }

        public static implicit operator string(Html html)
        {
            return html.ToString();
        }

    }
}
