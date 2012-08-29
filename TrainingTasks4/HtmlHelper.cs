using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace TrainingTasks4
{
    class HtmlHelper<InputData>
    {

        private InputData _inputData;

        public HtmlHelper(InputData inputData)
        {
            _inputData = inputData;

        }

        public Html InputFor<TValue>(Expression<Func<InputData, TValue>> selector)
        {

            string propertyName = GetMemberName(selector);
            var value = selector.Compile()(_inputData);

            Html html = new Html("input").Attr("type", "text").Attr("name", propertyName).Attr("value", value).selfEnding();

            return html;

        }

        private static string GetMemberName(Expression method)
        {
            Expression lambdaBodyExpression = ((LambdaExpression)method).Body;
            
            switch (lambdaBodyExpression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)lambdaBodyExpression).Member.Name;
                default:
                    throw new ArgumentException("Unsupported NodeType");
            }
        }

    }
}
