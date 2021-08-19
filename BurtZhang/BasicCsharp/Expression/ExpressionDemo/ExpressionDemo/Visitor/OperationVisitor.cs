using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    /// <summary>
    /// ExpressionVisitor: 肯定需要递归解析表达式目录树，因为不知道深度的一棵树
    /// 只有一个入口叫Visit
    /// 首先检查是什么类型的表达式
    /// 然后调通对应的protected virtual visit 方法
    /// 得到结果继续去 检查类型 -- 调用对应的visit 方法 -- 再检测--再调用 （递归）
    /// </summary>
    public class OperationVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
           return base.Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);

                return Expression.Subtract(left, right);
            }

            return base.VisitBinary(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return base.VisitConstant(node);
        }
    }
}
