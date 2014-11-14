namespace Crm.Admin.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class NewPasswordModel : IValidatableObject
	{
		private string _value;
		private string _confirmation;

		[Display(Name = "Enter")]
		[DataType(DataType.Password)]
		public string Value
		{
			get { return IsConfirmed ? _value : string.Empty; }
			set { _value = value; }
		}

		[Display(Name = "Confirm")]
		[DataType(DataType.Password)]
		public string Confirmation
		{
			get { return IsConfirmed ? _confirmation : string.Empty; }
			set { _confirmation = value; }
		}

		public bool IsConfirmed { get { return _value == Confirmation; } }

		IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
		{
			return new[] {
				Value == Confirmation
					? ValidationResult.Success
					: new ValidationResult(
						"Password and Confirmation Password must match.",
						new[] {"Password", "ConfirmPassword"}
					)
			};
		}

		public static implicit operator string(NewPasswordModel model)
		{
			if (!model.IsConfirmed)
				throw new InvalidOperationException("Password is incorrectly confirmed.");
			return model.Value;
		}
	}
}