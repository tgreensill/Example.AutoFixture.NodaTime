using AutoFixture.Kernel;
using NodaTime;
using System;

namespace AutoFixture.NodaTime
{
    public class LocalDateGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(LocalDate).Equals(request))
            {  
                return new NoSpecimen();
            }
            
            return LocalDate.FromDateTime(DateTime.Today);
        }
    }
}
