using Orleans.Serialization;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using Remote.Linq;

namespace Orleans.Linq.Serializers {
    internal static class BinaryTokenStreamWriterExtensions {
        public static void Write(this BinaryTokenStreamWriter writer, LambdaExpression expr) {
            using (var stream = new MemoryStream()) {
                new BinaryFormatter().Serialize(stream, expr.ToRemoteLinqExpression());
                writer.Write((int)stream.Position);
                writer.Write(stream.ToArray());
            }
        }
    }
}
