using System.Linq.Expressions;

namespace SWD_Laundry_Backend.Core.Utils;
public class ExpressionInspect : ExpressionVisitor
{
    public string? Id { get; set; }

    public ExpressionInspect(BinaryExpression node)
    {
        VisitBinary(node);
    }

    public override Expression Visit(Expression? node)
    {
        if (node.NodeType == ExpressionType.Constant)
        {
            var value = ((ConstantExpression)node).Value;
            if (value != null)
            {
                var valueType = value.GetType();
                var fieldInfo = valueType.GetField("id");
                if (fieldInfo != null)
                {
                    string? id = (string?)fieldInfo.GetValue(value);
                    if (id != null)
                    {
                        Id = id;
                    }
                }
            }
        }
        return base.Visit(node);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {

        if (node.NodeType == ExpressionType.Equal)
        {
            Expression left = Visit(node.Left);
            if (left != null)
            {
                var leftnode = left as MemberExpression;
                if (leftnode != null)
                {
                    var name = leftnode?.Member.Name;
                    if (name == "Id")
                    {
                        Visit(node.Right);
                    }
                }
            }
        }
        return base.VisitBinary(node);
    }
}
