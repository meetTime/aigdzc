using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CCITU.Common
{
    public class Validator
    {
        #region 字符长度

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="minLength">include min</param>
        /// <param name="maxLength">inlucde max</param>
        /// <returns></returns>
        public static bool IsValidLengthScope(string str, int minLength, int maxLength)
        {
            if (str == null)
            {
                return false;
            }

            int length = str.Length;
            return (length >= minLength) && (length <= maxLength);
        }

        #endregion

        #region Int

        public static bool IsValidInt(string str)
        {
            int value;
            return IsValidInt(str, out value);
        }

        public static bool IsValidInt(string str, out int value)
        {
            return int.TryParse(str, out value);
        }

        public static bool IsValidInt(string str, int min, int max)
        {
            int value;
            if (IsValidInt(str, out value))
            {
                if (min <= value && value <= max)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Float

        public static bool IsValidFloat(string str)
        {
            float value;
            return float.TryParse(str, out value);
        }

        public static bool IsValidFloat(string str, out float value)
        {
            return float.TryParse(str, out value);
        }

        public static bool IsValidFloat(string str, float min, float max)
        {
            float value;
            if (IsValidFloat(str, out value))
            {
                if (min <= value && value <= max)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 身份证

        public static bool IsValidIdCard(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length != 18)
            {
                return false;
            }

            if (Regex.IsMatch(str, @"^\d{17}[\dx]$") == false)
            {
                return false;
            }

            char checkCode = Utils.GetIdCardCheckCode(str.Substring(0, 17));
            return checkCode == str[18];
        }

        #endregion

        #region Email

        static Regex emailRegex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.Compiled);

        public static bool IsValidEmail(string str)
        {
            if (IsValidLengthScope(str,10,50)==false)
            {
                return false;
            }
            return emailRegex.IsMatch(str);
        }

        public static bool IsLetterOrDigit(string str)
        {
            foreach (var item in str)
            {                
                bool isLetterOrDigit = char.IsLetterOrDigit(item);
                if (isLetterOrDigit == false)
                {
                    return false;
                }
            }
            return true;
        }



        #endregion

        #region 网址

        public static bool IsValidUrl(string str)
        {
            //todo:
            return true;
            //return IsValidLengthScope(str, 10, 100);
        }

        #endregion        

        #region 中国电话号码

        static Regex usaPhoneNumberRegex = new Regex(@"^[13]\d{9}$");

        public static bool IsValidUsaPhoneNumber(string str)
        {
            if (IsValidLengthScope(str, 10, 10) == false)
            {
                return false;
            }
            return usaPhoneNumberRegex.IsMatch(str);
        }

        #endregion

        #region 中国邮编

        static Regex usaZipCodeRegex = new Regex(@"^\d{6}$");

        public static bool IsValidUsaZipCode(string str)
        {
            if (IsValidLengthScope(str, 5, 10) == false)
            {
                return false;
            }
            return usaZipCodeRegex.IsMatch(str);
        }

        #endregion

        #region 信用卡

        static Regex creditCardNumberRegex = new Regex(@"^\d{12,30}$");

        public static bool IsValidCreditCardNumber(string str)
        {
            if (IsValidLengthScope(str, 12, 30) == false)
            {
                return false;
            }
            return creditCardNumberRegex.IsMatch(str);
        }

        static Regex securityCodeRegex = new Regex(@"^\d{3,5}$");
        public static bool IsValidSecurityCode(string str)
        {
            if (IsValidLengthScope(str, 3, 5) == false)
            {
                return false;
            }
            return securityCodeRegex.IsMatch(str);
        }

        #endregion

        #region 用户名字

        static Regex userNameRegex = new Regex(@"^[a-z|0-9|_|\u4E00-\u9FA5]{2,50}$", RegexOptions.IgnoreCase);

        public static bool IsValidUserName(string str)
        {
            if (IsValidLengthScope(str, 2, 50) == false)
            {
                return false;
            }
            return userNameRegex.IsMatch(str);
        }

        #endregion

        #region 分页约束

        public static bool IsValidPagerScope(int startIndex,int endIndex)
        {
            if (startIndex < 1 || endIndex < 1)
            {
                return false;
            }
            if (startIndex > endIndex)
            {
                return false;
            }
            if (endIndex - startIndex > 1000)
            {
                return false;
            }

            return true;
        }

        #endregion      
    }

}
