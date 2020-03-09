using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public static class EF_Where_Expression
    {
        public static IQueryable<T> WhereContains<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.Call(left, typeof(string).GetMethod("Contains"), right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereEndsWith<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.Call(left, typeof(string).GetMethod("EndsWith"), right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereEqual<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.Equal(left, right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereGreaterThan<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.GreaterThan(left, right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereGreaterThanOrEqual<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.GreaterThanOrEqual(left, right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereLessThan<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.LessThan(left, right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereLessThanOrEqual<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.LessThanOrEqual(left, right);
            }, columnNames, values));
        }

        public static IQueryable<T> WhereStartsWith<T>(this IQueryable<T> source, string columnNames, params object[] values)
        {
            return source.Where(Custom_Expression_Common<T>((Expression left, Expression right) =>
            {
                return Expression.Call(left, typeof(string).GetMethod("StartsWith"), right);
            }, columnNames, values));
        }

        public delegate Expression ExpressionEventHandler(Expression left, Expression right);

        static Expression<Func<T, bool>> Custom_Expression_Common<T>(ExpressionEventHandler handler, string columnNames, params object[] values)
        {
            BinaryExpression filter = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            var columns = columnNames.Split(',');
            var param = Expression.Parameter(typeof(T));
            for (int i = 0; i < columns.Length; i++)
            {
                if (values[i] == null) continue;
                string columnName = columns[i].ToString();
                var value = values[i];
                Expression left = Expression.Property(param, typeof(T).GetProperty(columnName));
                Expression right = Expression.Constant(value, value.GetType());
                Expression result = handler(left, right);
                filter = Expression.And(filter, result);
            }
            return Expression.Lambda<Func<T, bool>>(filter, param);
        }
    }


    public static class OrderExpression
    {
        public static IQueryable<T> OrderByProp<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IQueryable<T> OrderByDescendingProp<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IQueryable<T> ThenByProp<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }
        public static IQueryable<T> ThenByDescendingProp<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }
        static IQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)result;
        }
    }
}
