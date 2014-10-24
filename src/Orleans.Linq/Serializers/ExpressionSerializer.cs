using Orleans.CodeGeneration;
using Orleans.Serialization;
using System;
using System.Linq.Expressions;

namespace Orleans.Linq.Serializers {
    public class ExpressionSerializer {
        [CopierMethod]
        public static object DeepCopier(object original) {
            return original;
        }

        [SerializerMethod]
        public static void Serializer(object value, BinaryTokenStreamWriter stream, Type expected) {
            if (value is LambdaExpression) {
                stream.Write(value as LambdaExpression);
            }
        }

        [DeserializerMethod]
        public static object Deserializer(Type expected, BinaryTokenStreamReader stream) {
            if (typeof(LambdaExpression).IsAssignableFrom(expected)) {
                return stream.ReadLambdaExpression();
            }
            return null;
        }
    }
}