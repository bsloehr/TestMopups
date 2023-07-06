using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiLib1.Contracts;

namespace MauiLib1
{
    public static class ThingService
    {
        private static readonly Lazy<IClass> Implementation = new(() => CreateClass(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IClass Instance
        {
            get
            {
                IClass lazyEvalClass = Implementation.Value;

                if (lazyEvalClass == null)
                    throw new Exception("How is this null?");

                return lazyEvalClass;
            }
        }

        static IClass CreateClass()
        {
            return new Class1();
        }
    }
}
