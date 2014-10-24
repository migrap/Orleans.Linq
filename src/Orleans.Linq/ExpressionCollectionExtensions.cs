using System;

namespace Orleans.Linq {
    public static class ExpressionCollectionExtensions {
        public static IExpressionCollection Add(this IExpressionCollection collection, Type expressionType) {
            return collection.Add(new ExpressionDescriptor(expressionType));
        }
    }
}
