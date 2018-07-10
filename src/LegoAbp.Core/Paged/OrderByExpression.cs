using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LegoAbp.Paged
{
    public static class OrderByExpression
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string property, string orderBy)
        {
            //因为前端返回的首字母是小写跟属性的字段是首字母大写对应不上.
            string sort="";
            if (!string.IsNullOrEmpty(property))
            {
                sort= property.Substring(0, 1).ToUpper() + property.Substring(1);
            }
            
            switch (orderBy)
            {
                case "":
                    return query;
                case "ascend":
                    return query.OrderBy(sort);
                case "descend":
                    return query.OrderByDescending(sort);
            }
            return query;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string property)
        {
            var type = typeof(T);
            var para = Expression.Parameter(type);
            var memberInfo = type.GetMember(property)[0];
            var member = Expression.MakeMemberAccess(para, memberInfo);
            var propertyType = type.GetProperty(property).PropertyType;

            if (propertyType.IsEnum)
            {
                var asExpr = Expression.Convert(member, typeof(int));
                return query.OrderBy(Expression.Lambda<Func<T, int>>(asExpr, para));
            }
            if (propertyType == typeof(string))
            {
                return query.OrderBy(Expression.Lambda<Func<T, string>>(member, para));
            }
            if (propertyType == typeof(DateTime))
            {
                return query.OrderBy(Expression.Lambda<Func<T, DateTime>>(member, para));
            }
            if (propertyType == typeof(DateTime?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, DateTime?>>(member, para));
            }
            if (propertyType == typeof(int))
            {
                return query.OrderBy(Expression.Lambda<Func<T, int>>(member, para));
            }
            if (propertyType == typeof(int?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, int?>>(member, para));
            }
            if (propertyType == typeof(decimal))
            {
                return query.OrderBy(Expression.Lambda<Func<T, decimal>>(member, para));
            }
            if (propertyType == typeof(decimal?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, decimal?>>(member, para));
            }

            if (propertyType == typeof(bool))
            {
                return query.OrderBy(Expression.Lambda<Func<T, bool>>(member, para));
            }
            if (propertyType == typeof(bool?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, bool?>>(member, para));
            }

            if (propertyType == typeof(double))
            {
                return query.OrderBy(Expression.Lambda<Func<T, double>>(member, para));
            }
            if (propertyType == typeof(double?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, double?>>(member, para));
            }

            if (propertyType == typeof(float))
            {
                return query.OrderBy(Expression.Lambda<Func<T, float>>(member, para));
            }
            if (propertyType == typeof(float?))
            {
                return query.OrderBy(Expression.Lambda<Func<T, float?>>(member, para));
            }

            throw new Exception("Unsupported data type：" + propertyType);
        }

        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string property)
        {
            var type = typeof(T);
            var para = Expression.Parameter(type);
            var memberInfo = type.GetMember(property)[0];
            var member = Expression.MakeMemberAccess(para, memberInfo);
            var propertyType = type.GetProperty(property).PropertyType;

            if (propertyType.IsEnum)
            {
                var asExpr = Expression.Convert(member, typeof(int));
                return query.OrderByDescending(Expression.Lambda<Func<T, int>>(asExpr, para));
            }
            if (propertyType == typeof(string))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, string>>(member, para));
            }
            if (propertyType == typeof(DateTime))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, DateTime>>(member, para));
            }
            if (propertyType == typeof(DateTime?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, DateTime?>>(member, para));
            }

            if (propertyType == typeof(int))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, int>>(member, para));
            }
            if (propertyType == typeof(int?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, int?>>(member, para));
            }

            if (propertyType == typeof(decimal))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, decimal>>(member, para));
            }
            if (propertyType == typeof(decimal?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, decimal?>>(member, para));
            }

            if (propertyType == typeof(bool))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, bool>>(member, para));
            }
            if (propertyType == typeof(bool?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, bool?>>(member, para));
            }

            if (propertyType == typeof(double))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, double>>(member, para));
            }
            if (propertyType == typeof(double?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, double?>>(member, para));
            }

            if (propertyType == typeof(float))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, float>>(member, para));
            }
            if (propertyType == typeof(float?))
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, float?>>(member, para));
            }

            throw new Exception("Unsupported data type：" + propertyType);
        }
    }
}
