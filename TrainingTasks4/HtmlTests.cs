using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks4
{
    [TestFixture]
    public class HtmlTests
    {
        [Test]
        public void BasicHtmlBuilderWithHelper()
        {

            InputData inputData = new InputData { Location = "St Kilda" };
            HtmlHelper<InputData> htmlHelper = new HtmlHelper<InputData>(inputData);

            var html = htmlHelper.InputFor(x => x.Location);

            Assert.AreEqual("<input type=\"text\" name=\"Location\" value=\"St Kilda\" />", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderWithHelperWithClass()
        {

            InputData inputData = new InputData { Park = "Albert" };
            HtmlHelper<InputData> htmlHelper = new HtmlHelper<InputData>(inputData);

            var html = htmlHelper.InputFor(x => x.Location).AddClass("lake");

            Assert.AreEqual("<input type=\"text\" name=\"Location\" value=\"Albert\" class=\"park\" />", html.ToString());
        }

        public class InputData
        {
            public string Location { get; set; }
            public string Park { get; set; }
        }

        [Test]
        public void BasicHtmlBuilder()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue");
            Assert.AreEqual("<div test=\"testvalue\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderMultipleAttributes()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Attr("test1", "testvalue1");
            Assert.AreEqual("<div test=\"testvalue\" test1=\"testvalue1\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderAddClass()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue").AddClass("wow");
            Assert.AreEqual("<span test=\"testvalue\" class=\"wow\"></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderModify()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Modify(x => x.AddClass("wow"));
            Assert.AreEqual("<div test=\"testvalue\" class=\"wow\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderWithoutToString()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue");
            Assert.True("<span test=\"testvalue\"></span>" == html);
        }

        [Test]
        public void BasicHtmlBuilderWithTwoClasses()
        {
            Html html = Html.Tag("span").AddClass("test").AddClass("test2");
            Assert.AreEqual("<span class=\"test test2\"></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilder1()
        {

            Html html2 = Html.Tag("div");
            html2.AddClass("hi");

            Html html = new Html("span");
            html.Attr("test", "1");

            Assert.AreEqual("<span test=\"1\"></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilder2()
        {
            Html html = new Html("span");
            html.AddClass("test");

            Assert.AreEqual("<span class=\"test\"></span>", meth(html));
        }

        [Test]
        public void BasicHtmlBuilder3()
        {
            Html html = new Html("span");

            Assert.AreEqual("<span></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilder4()
        {
            Html html = Html.Tag("span");
            html.Attr("test", "value");

            object html1 = html;

            Assert.AreEqual("<span test=\"value\"></span>", html1.ToString());
        }

        private string meth(string html)
        {
            return html;
        }

    }
}
