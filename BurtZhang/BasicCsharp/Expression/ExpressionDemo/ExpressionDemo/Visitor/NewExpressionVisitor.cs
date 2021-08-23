using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    internal class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression Param { get; private set; }

        public NewExpressionVisitor(ParameterExpression param)
        {
            Param = param;
        }

        public Expression Replace(Expression exp)
        {
            return base.Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Param;
        }
    }
}
