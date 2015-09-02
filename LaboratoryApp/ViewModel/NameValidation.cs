using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LaboratoryApp.ViewModel
{
    class NameValidation: ValidationRule
    {
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (!string.IsNullOrEmpty((string)value))
            {
                    if (int.TryParse(value.ToString(), out i))
                    return new ValidationResult(false, "Podana wartość jest liczbą!");
                else
                    if (i < (MinValue ?? i) || i > (MaxValue ?? i))
                        return new ValidationResult(false, ErrorMessage);
                    else
                        return ValidationResult.ValidResult;
            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }
    public class NIPValidation: ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {
                
                FieldContent = value as string;

                if (FieldContent.Length > 15)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 15 znaków]");
                }

                else
                {
                    return ValidationResult.ValidResult;
                }
                
            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }


    public class SerialNumberValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;

                if (FieldContent.Length > 100)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 100 znaków]");
                }

                else
                {
                    return ValidationResult.ValidResult;
                }

            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }


    public class SelectedItemValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;
                    return ValidationResult.ValidResult;

            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }

    public class ModelOfGaugesValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;

                if (FieldContent.Length > 50)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 50 znaków]");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }

    public class AddressValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            
            
                FieldContent = value as string;
                if(FieldContent == null)
                {
                    return ValidationResult.ValidResult;
                }

                else if (FieldContent.Length > 150)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 150 znaków]");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            
        }
    }
    public class ContactPersonValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;


            FieldContent = value as string;
            if (FieldContent == null)
            {
                return ValidationResult.ValidResult;
            }

            else if (FieldContent.Length > 70)
            {
                return new ValidationResult(false, "Podana wartość jest za długa. [max. 70 znaków]");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }

    public class NumberValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;


            FieldContent = value as string;
            if (FieldContent == null)
            {
                return ValidationResult.ValidResult;
            }

            else if (FieldContent.Length > 15)
            {
                return new ValidationResult(false, "Podana wartość jest za długa. [max. 15 znaków]");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }

    public class CommentValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;


            FieldContent = value as string;
            if (FieldContent == null)
            {
                return ValidationResult.ValidResult;
            }

            else if (FieldContent.Length > 500)
            {
                return new ValidationResult(false, "Podana wartość jest za długa. [max. 500 znaków]");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }

    public class UsageValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;

                if (FieldContent.Length > 500)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 500 znaków]");
                }

                else
                {
                    return ValidationResult.ValidResult;
                }

            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }

    public class AllowNullFieldValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent = (string) value;
            if (FieldContent == null)
            {

                FieldContent = value as string;

                if (FieldContent == null)
                {
                    return ValidationResult.ValidResult;
                }

                else if (FieldContent.Length > 50)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 50 znaków]");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
                return ValidationResult.ValidResult;

        }

    }

    public class StandardFieldValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;

                if (FieldContent.Length > 50)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 50 znaków]");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }

    public class CalibratorValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string FieldContent;
            if (!string.IsNullOrEmpty((string)value))
            {

                FieldContent = value as string;

                if (FieldContent.Length > 300)
                {
                    return new ValidationResult(false, "Podana wartość jest za długa. [max. 300 znaków]");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
                return new ValidationResult(false, "Nie wprowadzono danych.");
        }
    }

    

}
