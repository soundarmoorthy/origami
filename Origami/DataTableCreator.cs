using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Origami
{
    public static class DataTableCreator
    {
        public static DataTable Create(List<object[]> root)
        {
            DataTable table = DataTableFactory.Create();
            table.TableName = nameof(Origami.Models.Assesment);
            foreach (var entry in root)
            {
                PopulateData(entry, ref table);
            }
            return table;

        }

        private static void PopulateData(object[] objects,
            ref DataTable table)
        {
            DataRow row = table.NewRow();
            foreach (var obj in objects)
            {
                var props = Props(obj);
                foreach (var prop in props)
                {
                    var name = NameOf(obj.GetType(), prop);
                    var value = prop.GetValue(obj);
                    row[name] = value;
                }
            }
            table.Rows.Add(row);
        }

        private static string NameOf(Type type, PropertyInfo prop)
            => DataTableFactory.NameOf(type, prop);

        private static IEnumerable<PropertyInfo> Props(object item)
            => DataTableFactory.Props(item.GetType());
    }
}
