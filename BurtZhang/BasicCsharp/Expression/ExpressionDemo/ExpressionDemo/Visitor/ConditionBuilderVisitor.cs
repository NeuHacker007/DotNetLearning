using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionDemo.DBExtend;

namespace ExpressionDemo.Visitor
{
    public class ConditionBuilderVisitor : ExpressionVisitor
    {
        private Stack<string> _stack = new Stack<string>();

        public string Condition()
        {
            string condition = string.Concat(this._stack.ToArray());

            this._stack.Clear();
            return condition;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new ArgumentException("BinaryExpression");
            _stack.Push(")");
            base.Visit(node.Right);
            _stack.Push(" " + node.NodeType.ToSqlOperator() + " ");

            base.Visit(node.Left);
            _stack.Push("(");
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentException("BinaryExpression");

            _stack.Push(" [" + node.Member.Name + "] ");

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentException("BinaryExpression");

            _stack.Push(" '" + node.Value + "' ");
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null) throw new ArgumentException("BinaryExpression");
            string format = node.Method.Name switch
            {
                "StartsWith" => "({0} LIKE {1} + '%')",
                "Contains" => "({0} LIKE '%'+{1}+'%')",
                "EndsWith" => "({0} LIKE '%'+{1})",
                _ => throw new NotSupportedException("Not supported")
            };
            this.Visit(node.Object);
            this.Visit(node.Arguments[0]);

            string right = _stack.Pop();
            string left = _stack.Pop();

            _stack.Push(string.Format(format, left, right));
            return node;
        }
    }
}
