using System;
using System.Reflection;

namespace ReflectionLib
{
    public static class Reflection
    {
        /// <summary>
        /// Is used to get, by reflection, a method in a class and use it
        /// </summary>
        /// <param name="_objectToAcces">Instance of the class you want to acces</param>
        /// <param name="_methodeName">The name of method you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <param name="_paramters">Array of parameters of your method</param>
        public static void Method(object _objectToAcces, string _methodeName, BindingFlags _flagsToSearch = BindingFlags.Default, object[] _paramters = null)
        {
            Type _hisType = GetType(_objectToAcces);

            MethodInfo _methode = _hisType.GetMethod(_methodeName, _flagsToSearch);

            if (_methode == null) throw new Exception("Method you want to access is not defined ! Maybe you have mistaken her name ?");

            _methode.Invoke(_objectToAcces, _flagsToSearch, null, _paramters, null);
        }

        /// <summary>
        /// Is used to get, by reflection, a property in a class and use it
        /// </summary>
        /// <param name="_objectToAcces">Object you want to acces</param>
        /// <param name="_propertiesName">The name of property you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <returns></returns>
        public static PropertyInfo Property(object _objectToAcces, string _propertiesName, BindingFlags _flagsToSearch = BindingFlags.Default)
        {
            Type _hisType = GetType(_objectToAcces);

            PropertyInfo _property = _hisType.GetProperty(_propertiesName, _flagsToSearch);

            if (_property == null) throw new Exception("Property you want to access is not declared ! Maybe you have mistaken her name ?");

            return _property;
        }

        /// <summary>
        /// Is used to get a type of an object
        /// </summary>
        /// <param name="_objectToAcces">Object you want to acces</param>
        /// <returns></returns>
        static Type GetType(object _objectToAcces)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            return _objectToAcces.GetType();
        }


    }
}
