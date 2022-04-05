using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MedicalOffice.DAL.Extensions.Models;

namespace MedicalOffice.DAL.Extensions
{
    public static class LinqExtension
    {
        private static IQueryable<T> OrderByType<T, TExpression>(IQueryable<T> query, PropertyInfo propertyInfo,
            OrderingModel order)
        {
            var parameterExpression = Expression.Parameter(typeof(T));
            var memberExpression = Expression.Property(parameterExpression, propertyInfo);
            var expression = Expression.Lambda<Func<T, TExpression>>(memberExpression, parameterExpression);

            return order.Dir == "asc" ? query.OrderBy(expression) : query.OrderByDescending(expression);
        }

        public static IQueryable<T> OrderByOrderingModel<T>(this IQueryable<T> query, IList<OrderingModel> orders)
        {
            if (orders is not {Count: > 0})
            {
                return query;
            }

            var propertyInfos = typeof(T)
                .GetProperties()
                .ToDictionary(el => el.Name.ToLower(), val => val.Name);

            foreach (var order in orders)
            {
                if (propertyInfos.ContainsKey(order.Column.ToLower()))
                {
                    var propertyInfo = typeof(T).GetProperty(propertyInfos[order.Column.ToLower()]);
                    if (propertyInfo != null)
                    {
                        query = Type.GetTypeCode(propertyInfo.PropertyType) switch
                        {
                            TypeCode.String => OrderByType<T, string>(query, propertyInfo, order),
                            TypeCode.Boolean => OrderByType<T, bool>(query, propertyInfo, order),
                            TypeCode.DateTime => OrderByType<T, DateTime>(query, propertyInfo, order),
                            TypeCode.Decimal => OrderByType<T, decimal>(query, propertyInfo, order),
                            TypeCode.Double => OrderByType<T, double>(query, propertyInfo, order),
                            TypeCode.Byte => OrderByType<T, byte>(query, propertyInfo, order),
                            TypeCode.Int16 => OrderByType<T, short>(query, propertyInfo, order),
                            TypeCode.Int32 => OrderByType<T, int>(query, propertyInfo, order),
                            TypeCode.Int64 => OrderByType<T, long>(query, propertyInfo, order),
                            _ => query
                        };
                    }
                }
            }

            return query;
        }
    }
}