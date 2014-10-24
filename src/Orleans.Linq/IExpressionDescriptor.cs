using System;

namespace Orleans.Linq {
    public interface IExpressionDescriptor {
        Type ExpressionType { get; }
    }
}
