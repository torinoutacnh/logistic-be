using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Infras.Utils
{
    public static class ExtensionUtils
    {
        public static TResult Map<T, TResult>(this T @this, Func<T, TResult> f) => f(@this);

        public static bool HasImageExtension(this string? source)
        {
            if (source == null)
                return false;
            return (source.EndsWith(".png")
                || source.EndsWith(".jpg")
                || source.EndsWith(".jpeg")
                || source.EndsWith(".gif")
                || source.EndsWith(".webp")
                || source.EndsWith(".tiff")
                || source.EndsWith(".jpeg 2000")
                || source.EndsWith(".raw")
                || source.EndsWith(".psd")
                || source.EndsWith(".bmp")
                || source.EndsWith(".heif")
                || source.EndsWith(".indd"));
        }

        public static IQueryable<T> QueryExt<T>(this IQueryable<T> @this, Func<IQueryable<T>, IQueryable<T>> func) => func(@this);

        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            // need to detect whether they use the same
            // parameter instance; if not, they need fixing
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                // simple version
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            // otherwise, keep expr1 "as is" and invoke expr2
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }

        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            objects.Sort();
            return objects;
        }
    }
}
