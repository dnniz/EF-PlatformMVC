using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Services.Interface
{
    public abstract partial class DBProviderManager<T> where T : BaseDBProvider
    {
        protected static bool s_Initialized;
        protected static Exception s_InitializeException;
        protected static object s_lock;
        private static T s_Provider;

        static DBProviderManager()
        {
            s_lock = new object();
            s_Initialized = false;
            s_InitializeException = null;
        }

        private static void Initialize()
        {
            if (s_Initialized)
            {
                if (s_InitializeException != null)
                {
                    throw s_InitializeException;
                }
            }
            else
            {
                if (s_InitializeException != null)
                {
                    throw s_InitializeException;
                }
                lock (s_lock)
                {
                    if (s_Initialized)
                    {
                        if (s_InitializeException != null)
                        {
                            throw s_InitializeException;
                        }
                    }
                    else
                    {
                        try
                        {
                            s_Provider = (T)Activator.CreateInstance(Type.GetType(typeof(T).ToString().Replace("Interface", "Implementation").Replace("Svc", "Provider")));
                        }
                        catch (Exception exception)
                        {
                            s_InitializeException = exception;
                            throw;
                        }
                        s_Initialized = true;
                    }
                }
            }
        }

        public static T Provider
        {
            get
            {
                Initialize();
                return s_Provider;
            }
        }
    }
}
