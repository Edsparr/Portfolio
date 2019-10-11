using Octokit;
using Portfolio.Website.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Website.TypeConverters
{
    [TypeConverter(typeof(PortfolioProjectTypeConverter))] 
    public class PortfolioProjectTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
        {
            if (sourceType == typeof(PortfolioProject))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
         CultureInfo culture, object value)
        {
            throw new NotSupportedException();
        }
        public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
        {
            if (!(value is Repository repository))
                throw new ArgumentException(nameof(value));

            if (destinationType == typeof(PortfolioProject))
                return new PortfolioProject()
                {
                    Name = repository.Name,
                    Stars = repository.StargazersCount
                };

            return base.ConvertTo(context, culture, value, destinationType);
        }
        
    }
}
