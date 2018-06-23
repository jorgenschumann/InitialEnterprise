using System;

namespace InitialEnterprise.Infrastructure.Utils
{
    public static class Guard
    {
        public static void Against<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void Against<TException>(Func<bool> assertion, string message) where TException : Exception
        {
            if (assertion())
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void AgainstNull<TException>(object candidate, string message = "") where TException : Exception
        {
            if (candidate == null)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void AgainstNotNull<TException>(object candidate, string message = "") where TException : Exception
        {
            if (candidate != null)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void AgainstArgumentNull(object value, string message = "")
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void InheritsFrom<TBase>(object instance, string message) where TBase : Type
        {
            InheritsFrom<TBase>(instance.GetType(), message);
        }

        public static void InheritsFrom<TBase>(Type type, string message)
        {
            if (type.BaseType != typeof(TBase))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void Implements<TInterface>(object instance, string message)
        {
            Implements<TInterface>(instance.GetType(), message);
        }

        public static void Implements<TInterface>(Type type, string message)
        {
            if (!typeof(TInterface).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void TypeOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void IsEqual<TException>(object compare, object instance, string message) where TException : Exception
        {
            if (compare != instance)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }
    }
}