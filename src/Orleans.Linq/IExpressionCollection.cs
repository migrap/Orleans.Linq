using System.Collections.Generic;

namespace Orleans.Linq {
    public interface IExpressionCollection {
        IExpressionCollection Add(IExpressionDescriptor descriptor);
        IExpressionCollection Add(IEnumerable<IExpressionDescriptor> descriptors);
    }
}
