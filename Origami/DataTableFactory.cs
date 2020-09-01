using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Origami.Models;

namespace Origami

{
    public class DataTableFactory
    {
        public static DataTable Create()
        {
            DataTable table = new DataTable();
            SetupColumns(table);
            return table;
        }

        private static void SetupColumns(DataTable table)
        {
            var types =
                from type in allTypes()
                where type.Namespace == typeof(Assesment).Namespace
                && type.GetCustomAttribute<OrderAttribute>().Include
                orderby type.GetCustomAttribute<OrderAttribute>().Index
                select type;

            foreach (var type in types)
            {
                foreach (var prop in Props(type))
                {
                    //To avoid ambiguity across types.
                    var name = NameOf(type, prop);
                    table.Columns.Add(name, prop.PropertyType);
                }
            }
        }

        private static IEnumerable<Type> allTypes() =>
            Assembly.GetExecutingAssembly().GetTypes();

        public static IEnumerable<PropertyInfo> Props(Type type)
        {
            foreach (var prop in type.GetProperties())
                if (prop.PropertyType == typeof(string))
                    yield return prop;
            yield break;
        }

        internal static Type stringType()
            => typeof(string);

        internal static string NameOf(Type type, PropertyInfo prop)
                    => $"{type.Name}_{prop.Name}";
    }
}
