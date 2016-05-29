using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace UmbracoTest.Helpers
{
    public static class ExpressionUmbracoHelper
    {
        public static bool IsFieldRequired<TModel, TPropertyType>(this Expression<Func<TModel, TPropertyType>> propertyExpression)
        {
            var hasRequiredAttribute = propertyExpression.HasAttribute<TModel, TPropertyType, RequiredAttribute>();
            return hasRequiredAttribute;
        }
    }
}