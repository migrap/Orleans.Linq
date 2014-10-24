using System.Collections.Generic;

namespace Orleans.Linq {
    
    public class ExpressionCollection : IExpressionCollection {
        private readonly List<IExpressionDescriptor> _descriptors = new List<IExpressionDescriptor>();

        internal IReadOnlyCollection<IExpressionDescriptor> Descriptor { get { return _descriptors.AsReadOnly(); } }

        public IExpressionCollection Add(IEnumerable<IExpressionDescriptor> descriptors) {
            _descriptors.AddRange(descriptors);
            return this;
        }

        public IExpressionCollection Add(IExpressionDescriptor descriptor) {
            _descriptors.Add(descriptor);
            return this;
        }
    }
}
