using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace DependencyInjectionConcept.Core.ViewModels
{
    public abstract class PropertyChangedNotification : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        private readonly List<ValidationResult> _results = new();
        private readonly Dictionary<string, object> _values = new();

        #endregion

        #region Public
        public List<ValidationResult> ValidationErrors() => _results;

        [JsonIgnore]
        public bool IsValid => Validator.TryValidateObject(this, new ValidationContext(this), _results);

        #endregion

        #region Protected

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The property value.</param>
        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            _values[propertyName] = value;
            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T GetValue<T>([CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            if (_values.TryGetValue(propertyName, out var value))
            {
                return (T)value;
            }

            value = default(T);
            _values.Add(propertyName, value);

            return (T)value;
        }

        /// <summary>
        /// Validates current instance properties using Data Annotations.
        /// </summary>
        /// <param name="propertyName">This instance property to validate.</param>
        /// <returns>Relevant error string on validation failure or <see cref="System.String.Empty"/> on validation success.</returns>
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            var error = string.Empty;
            var value = GetValue(propertyName);
            var results = new List<ValidationResult>(1);
            var result = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName
                },
                results);

            if (result)
            {
                return error;
            }

            var validationResult = results.First();
            error = validationResult.ErrorMessage;

            return error;
        }

        #endregion

        #region Change Notification

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            VerifyPropertyName(propertyName);

            var handler = PropertyChanged;
            if (handler == null)
            {
                return;
            }

            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }

        #endregion // INotifyPropertyChanged Members

        #region Data Validation

        string IDataErrorInfo.Error => throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");

        string IDataErrorInfo.this[string propertyName] => OnValidate(propertyName);

        #endregion

        #region Privates

        private object GetValue(string propertyName)
        {
            if (_values.TryGetValue(propertyName, out var value))
            {
                return value;
            }

            var propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
            if (propertyDescriptor == null)
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            value = propertyDescriptor.GetValue(this);
            _values.Add(propertyName, value);

            return value;
        }

        #endregion

        #region Debugging

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] != null)
            {
                return;
            }

            var msg = "Invalid property name: " + propertyName;

            if (ThrowOnInvalidPropertyName)
                throw new Exception(msg);

            Debug.Fail(msg);
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        private static bool ThrowOnInvalidPropertyName => false;

        #endregion // Debugging Aides
    }
}
