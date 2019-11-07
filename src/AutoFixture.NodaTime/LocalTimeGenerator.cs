using NodaTime;
using AutoFixture.Kernel;
using System;

namespace AutoFixture.NodaTime
{
    public class LocalTimeGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(LocalTime).Equals(request))
            {
                return new NoSpecimen();
            }

            return LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
        }
    }
}
