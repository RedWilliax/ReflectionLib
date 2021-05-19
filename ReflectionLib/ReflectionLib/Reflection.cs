using System;
using System.Reflection;

namespace ReflectionLib
{
    public static class Reflection
    {
        /// <summary>
        /// Is used to get, by reflection, a method  info in a class and use it
        /// </summary>
        /// <param name="_objectToAccess">Instance of the class you want to acces</param>
        /// <param name="_methodeName">The name of method you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        public static MethodInfo MethodInfo(object _objectToAccess, string _methodeName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.NonPublic)
        {
            Type _hisType = GetType(_objectToAccess);

            MethodInfo _methode = _hisType.GetMethod(_methodeName, _flagsToSearch);

            if (_methode == null) throw new Exception("MethodInfo you want to access is not defined ! Maybe you have mistaken her name ?");

            return _methode;
        }

        /// <summary>
        /// Is used to get, by reflection, a property info in a class and use it
        /// </summary>
        /// <param name="_objectToAccess">Object you want to acces</param>
        /// <param name="_propertyName">The name of property you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specific search</param>
        /// <returns></returns>
        public static PropertyInfo PropertyInfo(object _objectToAccess, string _propertyName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.Public)
        {
            Type _hisType = GetType(_objectToAccess);

            PropertyInfo _property = _hisType.GetProperty(_propertyName, _flagsToSearch);

            if (_property == null) throw new Exception("PropertyInfo you want to access is not declared ! Maybe you have mistaken her name ?");

            return _property;
        }

        /// <summary>
        /// Is used to get, by reflection, a field info in a class and use it
        /// </summary>
        /// <param name="_objectToAccess">Object you want to access</param>
        /// <param name="_fieldName">The name of field you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        /// <returns></returns>
        public static FieldInfo FieldInfo(object _objectToAccess, string _fieldName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.NonPublic)
        {
            Type _hisType = GetType(_objectToAccess);

            FieldInfo _field = _hisType.GetField(_fieldName, _flagsToSearch);

            if (_field == null) throw new Exception("FieldInfo you want to access is not declared ! Maybe you have mistaken his name ?");

            return _field;
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

        /// <summary>
        /// Is used to get a Method in object's instance, by reflection
        /// </summary>
        /// <param name="_objectToAccess">Object you want to acces</param>
        /// <param name="_methodeName">The name of method you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        /// <param name="_parameters">Array of parameters of your method</param>
        public static void Method(object _objectToAccess, string _methodeName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.NonPublic, object[] _parameters = null)
        {
            MethodInfo _methodInfo = MethodInfo(_objectToAccess, _methodeName, _flagsToSearch);

            _methodInfo.Invoke(_objectToAccess, _parameters);
        }

        /// <summary>
        /// Is used to get a Property in object's instance, by reflection
        /// </summary>
        /// <param name="_objectToAccess">Object you want to acces</param>
        /// <param name="_propertyName">The name of property you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        public static T Property<T>(object _objectToAccess, string _propertyName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.Public)
        {
            PropertyInfo _propertyInfo = PropertyInfo(_objectToAccess, _propertyName, _flagsToSearch);

            EqualType(typeof(T), _propertyInfo.PropertyType);

            return (T)_propertyInfo.GetValue(_objectToAccess);
        }

        /// <summary>
        /// Is used to get a Field in objet's instance, by reflection
        /// </summary>
        /// <typeparam name="T">type to return</typeparam>
        /// <param name="_objectToAccess">Object you want to access</param>
        /// <param name="_fieldName">The name of field you want to use</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        /// <returns></returns>
        public static T Field<T>(object _objectToAccess, string _fieldName, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.NonPublic)
        {
            FieldInfo _fieldInfo = FieldInfo(_objectToAccess, _fieldName, _flagsToSearch);

            EqualType(typeof(T), _fieldInfo.FieldType);

            return (T)_fieldInfo.GetValue(_objectToAccess);
        }


        /// <summary>
        /// Is used to Set a property, by reflection
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="_objectToAccess">Object you want to access</param>
        /// <param name="_propertyName">The name of property you want to set</param>
        /// <param name="_valueToSet">The value used to set the property</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        public static void SetProperty<T>(object _objectToAccess, string _propertyName, T _valueToSet, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.Public)
        {
            PropertyInfo _propertyInfo = PropertyInfo(_objectToAccess, _propertyName, _flagsToSearch);

            EqualType(_propertyInfo.PropertyType, typeof(T));

            _propertyInfo.SetValue(_objectToAccess, _valueToSet);

        }

        /// <summary>
        /// Is used to Set a field, by reflection
        /// </summary>
        /// <typeparam name="T">Type of field</typeparam>
        /// <param name="_objectToAccess">Object you want to access</param>
        /// <param name="_fieldName">The name of field you want to set</param>
        /// <param name="_valueToSet">the value used to set the field</param>
        /// <param name="_flagsToSearch">BindingFlags allow a more specefic search</param>
        public static void SetField<T>(object _objectToAccess, string _fieldName, T _valueToSet, BindingFlags _flagsToSearch = BindingFlags.Instance | BindingFlags.NonPublic)
        {
            FieldInfo _fieldInfo = FieldInfo(_objectToAccess, _fieldName, _flagsToSearch);

            EqualType(_fieldInfo.FieldType, typeof(T));

            _fieldInfo.SetValue(_objectToAccess, _valueToSet);

        }

        static void EqualType(Type _type1, Type _type2)
        {
            if (_type1 != _type2)
                throw new Exception("Error type requested is not the one get");
        }


    }
}
