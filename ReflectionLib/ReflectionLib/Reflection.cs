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
        public static void Method(object _objectToAcces, string _methodeName, BindingFlags _flagsToSearch = BindingFlags.InvokeMethod | BindingFlags.Instance, object[] _paramters = null)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            Type _hisType = _objectToAcces.GetType();

            MethodInfo _methode = _hisType.GetMethod(_methodeName, _flagsToSearch);

            if (_methode == null) throw new Exception("Method you want to access is not defined ! Maybe you have mistaken her name ?");

            _methode.Invoke(_objectToAcces, _flagsToSearch, null, _paramters, null);
        }

        /// <summary>
        /// Is used to get, by reflection, a method in a class and use it
        /// </summary>
        /// <param name="_objectToAcces">Instance of the class you want to acces</param>
        /// <param name="_methodeName">The name of method you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <param name="_paramters">Array of parameters of your method</param>
        public static void InvokeMethod(object _objectToAcces, string _methodeName, object[] _paramters = null, BindingFlags _flagsToSearch = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            Type _hisType = _objectToAcces.GetType();

            MethodInfo _methode = _hisType.GetMethod(_methodeName, _flagsToSearch | BindingFlags.InvokeMethod);

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
        public static object GetProperty(object _objectToAcces, string _propertiesName, BindingFlags _flagsToSearch = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            Type _hisType = _objectToAcces.GetType();

            PropertyInfo _property = _hisType.GetProperty(_propertiesName, _flagsToSearch | BindingFlags.GetProperty);

            if (_property == null) throw new Exception("Property you want to access is not declared ! Maybe you have mistaken her name ?");

            return _property.GetValue(_objectToAcces);
        }

        /// <summary>
        /// Is used to get, by reflection, a field in a class and use it
        /// </summary>
        /// <param name="_objectToAcces">Object you want to acces</param>
        /// <param name="_fieldName">The name of field you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <returns></returns>
        public static T GetField<T>(object _objectToAcces, string _fieldName, BindingFlags _flagsToSearch = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            Type _hisType = _objectToAcces.GetType();

            FieldInfo _field = _hisType.GetField(_fieldName, _flagsToSearch | BindingFlags.GetField);

            if (_field == null) throw new Exception("Field you want to access is not declared ! Maybe you have mistaken his name ?");

            return (T)_field.GetValue(_objectToAcces);
        }

        /// <summary>
        /// Is used to get, by reflection, a field in a class and use it
        /// </summary>
        /// <param name="_objectToAcces">Object you want to acces</param>
        /// <param name="_fieldName">The name of field you want to use</param>
        /// <param name="_newValue">Value to set the field</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <returns></returns>
        public static void SetField<T>(object _objectToAcces, string _fieldName, T _newValue, BindingFlags _flagsToSearch = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (_objectToAcces == null) throw new Exception("Object you want to access is null. Make sure there is no probleme");

            Type _hisType = _objectToAcces.GetType();

            FieldInfo _field = _hisType.GetField(_fieldName, _flagsToSearch | BindingFlags.GetField);

            if (_field == null) throw new Exception("Field you want to access is not declared ! Maybe you have mistaken his name ?");

            _field.SetValue(_objectToAcces, _newValue);
        }


    }
}
