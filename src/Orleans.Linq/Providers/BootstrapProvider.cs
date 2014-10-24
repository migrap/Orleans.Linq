using Orleans.Linq.Serializers;
using Orleans.Providers;
using System;
using System.Threading.Tasks;

namespace Orleans.Linq.Providers {
    public class BootstrapProvider : IBootstrapProvider {
        public string Name { get; set; }

        public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config) {
            return Task.Run(() => Init());
        }

        public static void Init(params Type[] types) {
            foreach (var type in types) {
                global::Orleans.Serialization.SerializationManager.Register(type, ExpressionSerializer.DeepCopier, ExpressionSerializer.Serializer, ExpressionSerializer.Deserializer, true);
            }
        }

        public static void Init(Action<IExpressionCollection> configure) {
            var expressions = new ExpressionCollection();
            configure(expressions);
            Init(expressions);
        }

        private static void Init(ExpressionCollection expressions) {
            foreach(var descriptor in expressions.Descriptor) {
                global::Orleans.Serialization.SerializationManager.Register(descriptor.ExpressionType, ExpressionSerializer.DeepCopier, ExpressionSerializer.Serializer, ExpressionSerializer.Deserializer, true);
            }
        }
    }
}
