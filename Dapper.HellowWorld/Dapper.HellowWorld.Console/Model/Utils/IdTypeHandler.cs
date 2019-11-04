using System.Data;

namespace Dapper.HellowWorld.Console.Model.Utils
{
    public class IdTypeHandler : SqlMapper.TypeHandler<Id>
    {
        public override void SetValue(IDbDataParameter parameter, Id value)
        {
            parameter.Value = value.ToString();
        }

        public override Id Parse(object value)
        {
            return new Id(value.ToString());
        }
    }
}
