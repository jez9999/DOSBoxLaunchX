using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.ObjectModel;

namespace DOSBoxLaunchX.Logic.Helpers;

public class ValidatorHelper {
	#region Private vars

	private readonly Collection<object> _validatedObjects = [];

	#endregion

	/// <summary>
	/// Recursively validates an object graph.  The reflection and validation used here is relatively inefficient,
	/// so this should not be run often; generally, just once on startup.
	/// </summary>
	/// <param name="objToValidate">The object to validate.</param>
	public void RecursiveValidate(object objToValidate) {
		if (_validatedObjects.Contains(objToValidate)) {
			throw new Exception("Cyclical reference while validating object, type: " + objToValidate.GetType().ToString());
		}
		Validator.ValidateObject(objToValidate, new ValidationContext(objToValidate), true);

		// Add non-primitives/strings to validated objects list
		if (!objToValidate.GetType().IsPrimitive && objToValidate.GetType() != typeof(string)) {
			_validatedObjects.Add(objToValidate);
		}

		foreach (var prop in objToValidate.GetType().GetProperties()) {
			object? propValue;
			try {
				if (
					prop.PropertyType.IsPrimitive ||
					prop.PropertyType == typeof(string) ||
					prop.PropertyType == typeof(DateTime) ||
					prop.PropertyType == typeof(DateTimeOffset) ||
					prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>) ||
					prop.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) ||
					(propValue = prop.GetValue(objToValidate)) == null
				) {
					// No recursing into primitives or nulls
					continue;
				}
				RecursiveValidate(propValue);
			}
			catch (TargetParameterCountException ex) {
				if (ex.Message == "Parameter count mismatch." && objToValidate is IEnumerable) {
					// This is an enumerable containing validatable items; we'll check its items later; do nothing
				}
				else { throw; }
			}
		}
		if (objToValidate is IEnumerable objToValidateEnum) {
			// This is an enumerable containing validatable items; loop through and validate each item
			foreach (var child in objToValidateEnum) {
				RecursiveValidate(child);
			}
		}
	}

	public class EmailValid(string message) : ValidationAttribute {
		private readonly string _message = message;

		private ValidationResult? isValid(object? value) {
			if (value is string email) {
				return EmailHelper.EmailIsValid(email) ? ValidationResult.Success : new ValidationResult(_message);
			}

			return new ValidationResult(_message);
		}

		public override bool IsValid(object? value) {
			return isValid(value) == ValidationResult.Success;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
			return isValid(value);
		}
	}
}
