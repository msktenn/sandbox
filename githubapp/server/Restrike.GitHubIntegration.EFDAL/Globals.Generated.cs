using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Restrike.GitHubIntegration.EFDAL.Exceptions;

namespace Restrike.GitHubIntegration.EFDAL
{
	#region Extensions

	public static partial class Extensions
	{
		public static void ResetConcurrency(this IAuditable item, int value)
		{
			if (item != null) item.Concurrency = value;
		}
	}

	#endregion

	#region GlobalValues

	internal static partial class GlobalValues
	{
		public const string ERROR_PROPERTY_NULL = "The value is null and in an invalid state.";
		public const string ERROR_PROPERTY_SETNULL = "Cannot set value to null.";
		public const string ERROR_CONCURRENCY_FAILURE = "Concurrency failure";
		public const string ERROR_CONSTRAINT_FAILURE = "Constraint failure";
		public const string ERROR_DATA_TOO_BIG = "The data '{0}' is too large for the {1} field which has a length of {2}.";
		public const string ERROR_INVALID_ENUM = "The value '{0}' set to the '{1}' field is not valid based on the backing enumeration.";
		public static readonly DateTime MIN_DATETIME = new DateTime(1753, 1, 1);
		public static readonly DateTime MAX_DATETIME = new DateTime(9999, 12, 31, 23, 59, 59);
		private const string INVALID_BUSINIESSOBJECT = "An invalid object of type 'IBusinessObject' was passed in. Perhaps a relationship was not enforced correctly.";

		internal static string SetValueHelperInternal(string newValue, bool fixLength, int maxDataLength)
		{
			string retval = null;
			if (newValue == null)
				retval = null;
			else
			{
				var v = newValue.ToString();
				if (fixLength)
				{
					int fieldLength = maxDataLength;
					if ((fieldLength > 0) && (v.Length > fieldLength)) v = v.Substring(0, fieldLength);
				}
				retval = v;
			}
			return retval;
		}

		internal static double? SetValueHelperDoubleNullableInternal(object newValue)
		{
			double? retval;
			if (newValue == null)
				retval = null;
			else
			{
				if (newValue is string)
					retval = double.Parse((string)newValue);
				else if (!(newValue is double?))
					retval = double.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (double?)newValue;
			}
			return retval;
		}

		internal static double SetValueHelperDoubleNotNullableInternal(object newValue, string nullMessage)
		{
			double retval;
			if (newValue == null)
				throw new Exception(nullMessage);
			else
			{
				if (newValue is string)
					retval = double.Parse((string)newValue);
				else if (!(newValue is double))
					retval = double.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (double)newValue;
			}
			return retval;
		}

		internal static DateTime? SetValueHelperDateTimeNullableInternal(object newValue)
		{
			DateTime? retval;
			if (newValue == null)
				retval = null;
			else
			{
				if (newValue is string)
					retval = DateTime.Parse((string)newValue);
				else if (!(newValue is DateTime?))
					retval = DateTime.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (DateTime?)newValue;
			}
			return retval;
		}

		internal static DateTime SetValueHelperDateTimeNotNullableInternal(object newValue, string nullMessage)
		{
			DateTime retval;
			if (newValue == null)
				throw new Exception(nullMessage);
			else
			{
				if (newValue is string)
					retval = DateTime.Parse((string)newValue);
				else if (!(newValue is DateTime))
					retval = DateTime.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (DateTime)newValue;
			}
			return retval;
		}

		internal static bool? SetValueHelperBoolNullableInternal(object newValue)
		{
			bool? retval;
			if (newValue == null)
				retval = null;
			else
			{
				if (newValue is string)
					retval = bool.Parse((string)newValue);
				else if (!(newValue is bool?))
					retval = bool.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (bool?)newValue;
			}
			return retval;
		}

		internal static bool SetValueHelperBoolNotNullableInternal(object newValue, string nullMessage)
		{
			bool retval;
			if (newValue == null)
				throw new Exception(nullMessage);
			else
			{
				if (newValue is string)
					retval = bool.Parse((string)newValue);
				else if (!(newValue is bool))
					retval = bool.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (bool)newValue;
			}
			return retval;
		}

		internal static int? SetValueHelperIntNullableInternal(object newValue)
		{
			int? retval;
			if (newValue == null)
				retval = null;
			else
			{
				if (newValue is string)
					retval = int.Parse((string)newValue);
				else if (!(newValue is int?))
					retval = int.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (int?)newValue;
			}
			return retval;
		}

		internal static int SetValueHelperIntNotNullableInternal(object newValue, string nullMessage)
		{
			int retval;
			if (newValue == null)
				throw new Exception(nullMessage);
			else
			{
				if (newValue is string)
					retval = int.Parse((string)newValue);
				else if (!(newValue is int))
					retval = int.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (int)newValue;
			}
			return retval;
		}

		internal static long? SetValueHelperLongNullableInternal(object newValue)
		{
			long? retval;
			if (newValue == null)
				retval = null;
			else
			{
				if (newValue is string)
					retval = long.Parse((string)newValue);
				else if (!(newValue is long?))
					retval = long.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (long?)newValue;
			}
			return retval;
		}

		internal static long SetValueHelperLongNotNullableInternal(object newValue, string nullMessage)
		{
			long retval;
			if (newValue == null)
				throw new Exception(nullMessage);
			else
			{
				if (newValue is string)
					retval = long.Parse((string)newValue);
				else if (!(newValue is long))
					retval = long.Parse(newValue.ToString());
				else if (newValue is IBusinessObject)
					throw new Exception(INVALID_BUSINIESSOBJECT);
				else
					retval = (long)newValue;
			}
			return retval;
		}

		internal static T PropertyGetterLambdaErrorHandler<T>(Func<T> func)
		{
			try
			{
				return func();
			}
			catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); throw; }
		}

		internal static void PropertySetterLambdaErrorHandler(System.Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); throw; }
		}

	}

	#endregion

	#region Util
	internal static partial class Util
	{
		public static string HashPK(params object[] p)
		{
			var retval = string.Empty;
			for (var ii = 0; ii < p.Length; ii++)
			{
				retval += p[ii] + "|" + ii + "|";
			}
			return retval;
		}

		public static UInt64 HashFast(string read)
		{
			UInt64 hashedValue = 3074457345618258791ul;
			for (int i = 0; i < read.Length; i++)
			{
				hashedValue += read[i];
				hashedValue *= 3074457345618258799ul;
			}
			return hashedValue;
		}

        internal static bool SetPropertyByName(object entity, string propertyName, object value)
        {
            var attr = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == propertyName);
            if (attr != null)
            {
                entity.GetType().GetProperty(attr.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(entity, value);
                return true;
            }
            return false;
        }

	}
	#endregion

	#region AuditTypeConstants Enumeration

	/// <summary>
	/// A set of values for the types of audits
	/// </summary>
	public enum AuditTypeConstants
	{
		/// <summary>
		/// Represents a row insert
		/// </summary>
		Insert = 1,
		/// <summary>
		/// Represents a row update
		/// </summary>
		Update = 2,
		/// <summary>
		/// Represents a row delete
		/// </summary>
		Delete = 3,
	}

	#endregion

	#region IAudit
	/// <summary>
	/// The base interface for all audit objects
	/// </summary>
	public interface IAudit
	{
		/// <summary>
		/// The type of audit
		/// </summary>
		AuditTypeConstants AuditType { get; }

		/// <summary>
		/// The date of the audit
		/// </summary>
		DateTime AuditDate { get; }

		/// <summary>
		/// The modifier value of the audit
		/// </summary>
		string ModifiedBy { get; }
	}
	#endregion

	#region ICreatable
	/// <summary />
	public partial interface ICreatable
	{
	}
	#endregion

	#region IAuditable
	/// <summary />
	public partial interface IAuditable
	{
		/// <summary />
		string CreatedBy { get; set; }
		/// <summary />
		DateTime? CreatedDate { get; set; }
		/// <summary />
		string ModifiedBy { get; set; }
		/// <summary />
		DateTime? ModifiedDate { get; set; }
		/// <summary />
		int Concurrency { get; set; }
	}
	#endregion

	#region FieldNameConstantsAttribute
	/// <summary>
	/// Identities the type of IBusinessObject for an enumeration
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class FieldNameConstantsAttribute : System.Attribute
	{
		/// <summary />
		public FieldNameConstantsAttribute(System.Type targetType) { this.TargetType = targetType; }
		/// <summary />
		public System.Type TargetType { get; private set; }
	}
	#endregion

		/// <summary />
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class StaticDataAttribute : System.Attribute
    {
        public StaticDataAttribute(System.Type parentType)
        {
            if (!parentType.IsEnum)
                throw new ContextConfigurationException($"StaticDataAttribute can only have an Enum parent type.");
            this.ParentType = parentType;
        }

        public System.Type ParentType { get; }
    }

    /// <summary>
    /// Marks an integer property as the key for the data item
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class StaticDataIdFieldAttribute : System.Attribute
    {
    }

    /// <summary>
    /// Marks a string property as the name for data item
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class StaticDataNameFieldAttribute : System.Attribute
    {
    }
	#region IContext
	/// <summary>
	/// The interface for a entity context
	/// </summary>
	public partial interface IContext
	{
		/// <summary />
		IContextStartup ContextStartup { get; }

		/// <summary>
		/// The database context
		/// </summary>
		Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database { get; }

		/// <summary>
		/// The database connection string
		/// </summary>
		string ConnectionString { get; }

		/// <summary>
		/// A unique key for this object instance
		/// </summary>
		Guid InstanceKey { get; }

		/// <summary>
		/// Determines the key of the model that created this library.
		/// </summary>
		string ModelKey { get; }

		/// <summary>
		/// Determines the version of the model that created this library.
		/// </summary>
		string Version { get; }

		/// <summary>
		/// Given a field enumeration value, returns an entity enumeration value designating the source entity of the field
		/// </summary>
		Enum GetEntityFromField(Enum field);

	}
	#endregion

	#region IBusinessObject
	/// <summary>
	/// An interface for writable entities
	/// </summary>
	public partial interface IBusinessObject : Restrike.GitHubIntegration.EFDAL.IReadOnlyBusinessObject
	{
		/// <summary>
		/// Sets the value of a field
		/// </summary>
		/// <param name="field">The field to set</param>
		/// <param name="newValue">The new value to set</param>
		/// <returns></returns>
		void SetValue(Enum field, object newValue);

		/// <summary>
		/// Sets the value of a field
		/// </summary>
		/// <param name="field">The field to set</param>
		/// <param name="newValue">The new value to set</param>
		/// <param name="fixLength">Determines if the length should be truncated if too long. When false, an error will be raised if data is too large to be assigned to the field.</param>
		/// <returns></returns>
		void SetValue(Enum field, object newValue, bool fixLength);

	}
	#endregion

	#region IPrimaryKey
	/// <summary />
	public partial interface IPrimaryKey
	{
		/// <summary />
		long Hash { get; }
	}

	/// <summary />
	public partial class PrimaryKey : IPrimaryKey
	{
		internal PrimaryKey(string key)
		{
			this.Hash = (long)Util.HashFast(key);
		}

		/// <summary />
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is PrimaryKey)) return false;
				return (((PrimaryKey)obj).Hash == this.Hash);
		}

		/// <summary />
		public override int GetHashCode() => base.GetHashCode();

		/// <summary />
		public static bool operator ==(PrimaryKey a, PrimaryKey b)
		{
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}
			// If one is null, but not both, return false.
			if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
			{
				return false;
			}

			return a.Hash == b.Hash;
		}

		/// <summary />
		public static bool operator !=(PrimaryKey a, PrimaryKey b)
		{
			return !(a == b);
		}

		/// <summary />
		public long Hash { get; private set; }
	}
	#endregion

	#region Audit Attributes
	/// <summary>
	/// Attribute used to decorate a concurrency field
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Property)]
	public partial class AuditTimestampAttribute : System.Attribute
	{
	}

	/// <summary>
	/// Attribute used to decorate an Audit CreatedBy field
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Property)]
	public partial class AuditCreatedByAttribute : System.Attribute
	{
	}

	/// <summary>
	/// Attribute used to decorate an Audit ModifiedBy field
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Property)]
	public partial class AuditModifiedByAttribute : System.Attribute
	{
	}

	/// <summary>
	/// Attribute used to decorate an Audit CreatedDate field
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Property)]
    public partial class AuditCreatedDateAttribute : System.Attribute
    {
        public AuditCreatedDateAttribute() : base() { }
        public AuditCreatedDateAttribute(bool utc) : this()
        {
            this.IsUTC = utc;
        }

        public bool IsUTC { get; }
    }

	/// <summary>
	/// Attribute used to decorate an Audit ModifiedDate field
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Property)]
    public partial class AuditModifiedDateAttribute : System.Attribute
    {
        public AuditModifiedDateAttribute() : base() { }
        public AuditModifiedDateAttribute(bool utc) : this()
        {
            this.IsUTC = utc;
        }

        public bool IsUTC { get; }
    }

	#endregion

	#region HasNoKeyAttribute
    /// <summary>
    /// Indicates that a table has no primary key
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class HasNoKeyAttribute : System.Attribute
    {
    }
	#endregion

	#region StringLengthUnboundedAttribute
    /// <summary>
    /// Indicates that a string has no set maximum length
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthUnboundedAttribute : System.Attribute
    {
    }
	#endregion

	#region TenantEntityAttribute
    /// <summary>
    /// Indicates that a database table is tenant based
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class TenantEntityAttribute : System.Attribute
    {
    }
	#endregion

	#region ITenantEntity
    /// <summary>
    /// Entities implementing this interface will have tenant based row security functionality.
    /// When the entity has a string property named "TenanId", the functionality will be picked up by convention.
    /// The 'TenantIDFieldAttribute' can be used on a string property of the entity to mark the tenant discriminator if the name is not "TenantId".
    /// </summary>
    public interface ITenantEntity
    {
        string TenantId { get; }
    }
	#endregion

	#region IReadOnlyBusinessObject
	/// <summary />
	public partial interface IReadOnlyBusinessObject
	{
		/// <summary>
		/// If applicable, returns the maximum number of characters the specified field can hold
		/// </summary>
		/// <param name="field"></param>
		/// <returns>If not applicable, the return value is 0</returns>
		int GetMaxLength(Enum field);

		/// <summary>
		/// Returns the primary key for this object
		/// </summary>
		IPrimaryKey PrimaryKey { get; }

		/// <summary />
		System.Type GetFieldNameConstants();

		/// <summary>
		/// Gets the value of a field specified by the enumeration
		/// </summary>
		/// <param name="field">The field from which to get the value</param>
		/// <returns></returns>
		object GetValue(Enum field);

		/// <summary>
		/// Gets the value of a field specified by the enumeration
		/// </summary>
		/// <param name="field">The field from which to get the value</param>
		/// <param name="defaultValue">The default value to return if the value is null</param>
		/// <returns></returns>
		object GetValue(Enum field, object defaultValue);

	}
	#endregion

}

namespace Restrike.GitHubIntegration.EFDAL.Exceptions
{
	#region nHydrateException
	/// <summary />
	public partial class nHydrateException : System.Exception
	{
		/// <summary />
		public string ErrorCode = null;
		/// <summary />
		public string []Arguments = null;

		/// <summary />
		public nHydrateException (): base ()
		{
		}

		/// <summary />
		public nHydrateException ( string Message ) : base ( Message )
		{
		}
		
		/// <summary />
		public nHydrateException ( string Message, System.Exception InnerException ) : base ( Message, InnerException )
		{
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, string Message ) : base ( Message )
		{
			this.ErrorCode = ErrorCode;
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, params object [] Arguments )
		{
			this.ErrorCode = ErrorCode;
			//this.arguments = arguments;

			this.Arguments = new string [Arguments.Length];

			for ( var length = 0; length < Arguments.Length; ++ length )
			{
				this.Arguments[length] = (string)Arguments [length];
			}
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, string Message, System.Exception InnerException ) : base ( Message, InnerException )
		{
			this.ErrorCode = ErrorCode;
		}

	}
	#endregion

	#region ContextConfigurationException
    public class ContextConfigurationException : System.Exception
    {
        public ContextConfigurationException(string message)
            : base(message)
        {
        }
    }
	#endregion

}
namespace Restrike.GitHubIntegration.EFDAL
{
    internal static partial class ReflectionHelpers
    {
        private static Random _rnd = new Random();

        internal static object[] BuildEntityObjectsFromEnum(System.Type classType, System.Type enumType)
        {
            var listObjectsToReturn = new List<object>();
            Dictionary<string, int> dictionary = Enum.GetValues(enumType).Cast<Enum>().ToDictionary(t => t.ToString(), t => System.Convert.ToInt32(t));

            foreach (var item in dictionary)
            {
                var newObject = Activator.CreateInstance(classType, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
                var propId = classType.Props(false).FirstOrDefault(x => x.GetCustomAttributes(true).Any(z => z.GetType() == typeof(StaticDataIdFieldAttribute)));
                var propName = classType.Props(false).FirstOrDefault(x => x.GetCustomAttributes(true).Any(z => z.GetType() == typeof(StaticDataNameFieldAttribute)));

                if (propId == null || propName == null)
                    throw new ContextConfigurationException($"Enumeration '{classType.Name}' not setup correctly.");

                propId.SetValue(newObject, item.Value); // Enum int id
                propName.SetValue(newObject, item.Key); // Enum string value
                listObjectsToReturn.Add(newObject);
            }
            return listObjectsToReturn.ToArray();
        }

        private static readonly MethodInfo SetQueryFilterMethod = typeof(ModelBuilderExtensions)
              .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
              .Single(t => t.IsGenericMethod && t.Name == "SetQueryFilter");

        internal static void SetEntityQueryFilter<TEntityInterface>(
              this Microsoft.EntityFrameworkCore.ModelBuilder builder,
              Type entityType,
              Expression<Func<TEntityInterface, bool>> filterExpression)
        {
            SetQueryFilterMethod
              .MakeGenericMethod(entityType, typeof(TEntityInterface))
              .Invoke(null, new object[] { builder, filterExpression });
        }


        internal static T GetAttr<T>(this System.Type tableType)
            where T : class
        {
            return tableType.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(T)) as T;
        }

        internal static T GetAttr<T>(this PropertyInfo propInfo)
            where T : class
        {
            return propInfo.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(T)) as T;
        }

        internal static PropertyInfo[] Props(this System.Type tableType, bool onlyPublic = true)
        {
            var retval = new List<PropertyInfo>();
            if (onlyPublic)
                retval.AddRange(tableType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance));
            else
                retval.AddRange(tableType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));

            retval.RemoveAll(x => x.Name == "EFCore.Extensions.ITenantEntity.TenantId");
            retval.RemoveAll(x => x.Name == "EFCore.Extensions.ISoftDeleted.IsDeleted");

            return retval.ToArray();
        }

        internal static Tuple<T, PropertyInfo> GetAttrWithProp<T>(this PropertyInfo propInfo)
            where T : class
        {
            var t = propInfo.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(T)) as T;
            return new Tuple<T, PropertyInfo>(t, propInfo);
        }

        internal static bool NotMapped(this PropertyInfo prop)
        {
            return prop.GetCustomAttributes(true).Any(z => z.GetType() == typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute));
        }

        // Given an expression for a method that takes in a single parameter (and
        // returns a bool), this method converts the parameter type of the parameter
        // from TSource to TTarget.
        internal static Expression<Func<TTarget, bool>> Convert<TSource, TTarget>(
          this Expression<Func<TSource, bool>> root)
        {
            var visitor = new ParameterTypeVisitor<TSource, TTarget>();
            return (Expression<Func<TTarget, bool>>)visitor.Visit(root);
        }

        internal static bool SetPropertyByAttribute(object entity, System.Type attrType, object value)
        {
            if (entity == null) return false;
            var attr = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .FirstOrDefault(x => x.GetCustomAttributes().Any(z => z.GetType() == attrType));

            if (attr != null)
            {
                entity.GetType().GetProperty(attr.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(entity, value);
                return true;
            }
            return false;
        }

        internal static void SetPropertyConcurrency(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, System.Type attrType)
        {
            var entity = entry.Entity;
            if (entity == null) return;
            var attr = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .FirstOrDefault(x => x.GetCustomAttributes(true).Any(z => z.GetType() == attrType));

            if (attr != null)
            {
                var property = entity.GetType().GetProperty(attr.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var propName = $"{entity.GetType().FullName}.{property.Name}";

                if (property.PropertyType == typeof(int))
                {
                    var value = property.GetValue(entity);
                    SetPropertyByName(entity, property.Name, ((int)value) + 1);

                    var orig = entry.OriginalValues.ToObject();
                    if (SetPropertyByName(orig, property.Name, value))
                        entry.OriginalValues.SetValues(orig);
                }
                else if (property.PropertyType == typeof(long))
                {
                    var value = property.GetValue(entity);
                    SetPropertyByName(entity, property.Name, ((long)value) + 1);

                    var orig = entry.OriginalValues.ToObject();
                    if (SetPropertyByName(orig, property.Name, value))
                        entry.OriginalValues.SetValues(orig);
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    var value = property.GetValue(entity);
                    SetPropertyByName(entity, property.Name, Guid.NewGuid());

                    var orig = entry.OriginalValues.ToObject();
                    if (SetPropertyByName(orig, property.Name, value))
                        entry.OriginalValues.SetValues(orig);
                }
                else if (property.PropertyType == typeof(byte[]))
                {
                    var value = property.GetValue(entity);
                    //Just set 4 bytes for now. Assume at least this big.
                    var newValue = new byte[] { (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255) };
                    SetPropertyByName(entity, property.Name, newValue);

                    var orig = entry.OriginalValues.ToObject();
                    if (SetPropertyByName(orig, property.Name, value))
                        entry.OriginalValues.SetValues(orig);
                }
                else
                    throw new ContextConfigurationException("The concurrency token cannot be set.");
            }
        }

        internal static bool SetPropertyByName(object entity, string propertyName, object value)
        {
            var attr = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == propertyName);
            if (attr != null)
            {
                entity.GetType().GetProperty(attr.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(entity, value);
                return true;
            }
            return false;
        }

        internal static IEnumerable<Type> GetTypesWithAttribute(IEnumerable<System.Type> allTypes, System.Type attributeType)
        {
            foreach (Type type in allTypes)
            {
                if (type.GetCustomAttributes(attributeType, true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        private class ParameterTypeVisitor<TSource, TTarget> : ExpressionVisitor
        {
            private ReadOnlyCollection<ParameterExpression> _parameters;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameters?.FirstOrDefault(p => p.Name == node.Name)
                  ?? (node.Type == typeof(TSource) ? Expression.Parameter(typeof(TTarget), node.Name) : node);
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                _parameters = VisitAndConvert<ParameterExpression>(node.Parameters, "VisitLambda");
                return Expression.Lambda(Visit(node.Body), _parameters);
            }
        }

    }

    internal static partial class ModelBuilderExtensions
    {
        static void SetQueryFilter<TEntity, TEntityInterface>(
          this Microsoft.EntityFrameworkCore.ModelBuilder builder,
          Expression<Func<TEntityInterface, bool>> filterExpression)
            where TEntityInterface : class
            where TEntity : class, TEntityInterface
        {
            var concreteExpression = filterExpression
              .Convert<TEntityInterface, TEntity>();
            builder.Entity<TEntity>()
              .HasQueryFilter(concreteExpression);
        }
    }
}
