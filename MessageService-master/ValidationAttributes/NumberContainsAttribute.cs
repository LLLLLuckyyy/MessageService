﻿using System.ComponentModel.DataAnnotations;

namespace MessageService.ValidationAttributes
{
    public class NumberContainsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string number = value.ToString();
                if (number.Contains("+262") || number.Contains("+232") || number.Contains("+260") || number.Contains("+380") || number.Contains("+120"))
                    return true;
            }
            return false;
        }
    }
}
