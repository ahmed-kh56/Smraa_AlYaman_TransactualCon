using System.Data;
using Dapper;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Infrastructure.Persistence.DbSettings
{
    public static class DapperTypeHandlerConfiguration
    {
        public static void Register()
        {
            var enumTypes = typeof(DomainException).Assembly
                .GetTypes()
                .Where(t => t.IsEnum && t.IsDefined(typeof(StoreAsStringAttribute), false))
                .ToList();

            foreach (var type in enumTypes)
            {
                var handlerType = typeof(EnumStringHandler<>).MakeGenericType(type);
                var handler = (SqlMapper.ITypeHandler)Activator.CreateInstance(handlerType)!;

                SqlMapper.AddTypeHandler(type, handler);
                SqlMapper.AddTypeHandler(typeof(Nullable<>).MakeGenericType(type), handler);
            }
        }


        private sealed class EnumStringHandler<T> : SqlMapper.TypeHandler<T>
            where T : struct, Enum
        {
            public override void SetValue(IDbDataParameter parameter, T value)
            {
                parameter.Value = value.ToString();
                parameter.DbType = DbType.String;
            }

            public override T Parse(object value)
            {
                if (value is null || value == DBNull.Value)
                    throw new DataException(
                        $"Cannot convert NULL to non-nullable enum {typeof(T).Name}");

                if (value is not string s)
                    throw new DataException(
                        $"Expected string for enum {typeof(T).Name}, got {value?.GetType().Name}");

                if (!Enum.TryParse<T>(s, true, out var parsed) ||
                    !Enum.IsDefined(typeof(T), parsed))
                    throw new DataException(
                        $"Invalid value '{s}' for enum {typeof(T).Name}");

                return parsed;
            }
        }

    }
}
