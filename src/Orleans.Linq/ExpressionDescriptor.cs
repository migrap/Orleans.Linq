using System;

namespace Orleans.Linq {
    public class ExpressionDescriptor : IExpressionDescriptor {
        public Type ExpressionType { get; private set; }

        public ExpressionDescriptor(Type expressionType) {
            ExpressionType = expressionType;
        }
    }
}