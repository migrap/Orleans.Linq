using Orleans.Serialization;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using Remote.Linq;

namespace Orleans.Linq.Serializers {
    internal static class BinaryTokenStreamReaderExtensions {
        public static LambdaExpression ReadLambdaExpression(this BinaryTokenStreamReader reader) {
            var length = reader.ReadInt();
            var buffer = reader.ReadBytes(length);
            using (var stream = new MemoryStream(buffer)) {
                var expression = new BinaryFormatter().Deserialize(stream);
                return (expression as Remote.Linq.Expressions.LambdaExpression).ToLinqExpression();
            }            
        }
    }
}
