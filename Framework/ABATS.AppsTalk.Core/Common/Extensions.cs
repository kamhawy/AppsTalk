using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        #region Object

        /// <summary>
        /// Safe Integer Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int SafeIntegerParse(this object value, int defaultValue = 0)
        {
            int returnValue = defaultValue;

            if (value != null)
            {
                returnValue = value.ToString().SafeIntegerParse(defaultValue);
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Integer Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? SafeNullableIntegerParse(this object value, int defaultValue = 0)
        {
            int? returnValue = defaultValue;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                returnValue = value.ToString().SafeNullableIntegerParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Double Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? SafeNullableDoubleParse(this object value)
        {
            double? returnValue = null;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                returnValue = value.ToString().SafeDoubleParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Decimal Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? SafeNullableDecimalParse(this object value)
        {
            decimal? returnValue = null;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                returnValue = value.ToString().SafeDecimalParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime SafeDateTimeParse(this object value)
        {
            DateTime returnDate = DateTime.MinValue;

            if (value != null)
            {
                if (!DateTime.TryParse(value.ToString(), out returnDate))
                {
                    returnDate = DateTime.MinValue;
                }
            }

            return returnDate;
        }

        /// <summary>
        /// Safe To String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeToString(this object value, string defaultValue = "")
        {
            return value != null ? value.ToString() : defaultValue;
        }

        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="pObject"></param>
        /// <param name="pPropertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(this object pObject, string pPropertyName)
        {
            object propValue = null;

            if (pObject != null)
            {
                PropertyInfo propInfo = pObject.GetType().GetProperty(pPropertyName);

                if (propInfo != null)
                {
                    propValue = propInfo.GetValue(pObject, null);
                }
            }

            return propValue;
        }

        /// <summary>
        /// Set Property Value
        /// </summary>
        /// <param name="pObject"></param>
        /// <param name="pPropertyName"></param>
        /// <param name="pPropertyValue"></param>
        /// <returns></returns>
        public static object SetPropertyValue(this object pObject, string pPropertyName, object pPropertyValue)
        {
            object propValue = null;

            if (pObject != null)
            {
                PropertyInfo propInfo = pObject.GetType().GetProperty(pPropertyName);

                if (propInfo != null)
                {
                    propInfo.SetValue(pObject, pPropertyValue, null);
                }
            }

            return propValue;
        }

        /// <summary>
        /// IsValidDateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidDateTime(this object value)
        {
            bool isValid = false;

            if (value != null)
            {
                DateTime dtTemp = DateTime.MinValue;

                if (DateTime.TryParse(value.SafeToString(), out dtTemp))
                {
                    if (dtTemp > DateTime.MinValue)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        #endregion

        #region String

        /// <summary>
        /// Safe Integer Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int SafeIntegerParse(this string value, int defaultValue = 0)
        {
            int returnValue = defaultValue;

            if (value.IsValidString())
            {
                if (Int32.TryParse(value.ToString(), out returnValue) == false)
                {
                    returnValue = defaultValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Short Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 SafeShortParse(this string value, short defaultValue = 0)
        {
            Int16 returnValue = defaultValue;

            if (value.IsValidString())
            {
                if (Int16.TryParse(value.ToString(), out returnValue) == false)
                {
                    returnValue = defaultValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? SafeNullableIntegerParse(this string value, int? defaultValue = null)
        {
            int? returnValue = defaultValue;

            if (value.IsValidString())
            {
                returnValue = value.SafeIntegerParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Parse Double 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double SafeDoubleParse(this string value)
        {
            double returnValue = 0;

            if (value.IsValidString())
            {
                if (double.TryParse(value, out returnValue) == false)
                {
                    returnValue = 0;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Double Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? SafeNullableDoubleParse(this string value)
        {
            double? returnValue = null;

            if (value.IsValidString())
            {
                returnValue = value.SafeDoubleParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Parse Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal SafeDecimalParse(this string value)
        {
            decimal returnValue = 0;

            if (value.IsValidString())
            {
                if (decimal.TryParse(value, out returnValue) == false)
                {
                    returnValue = 0;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Decimal Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? SafeNullableDecimalParse(this string value)
        {
            decimal? returnValue = null;

            if (value.IsValidString())
            {
                returnValue = value.SafeDecimalParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Boolean Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SafeBooleanParse(this string value)
        {
            bool returnValue = false;

            if (value.IsValidString())
            {
                bool.TryParse(value, out returnValue);
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Nullable Boolean Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool? SafeNullableBooleanParse(this string value, bool? defaultValue = null)
        {
            bool? returnValue = defaultValue;
            bool temp = false;

            if (value.IsValidString())
            {
                if (bool.TryParse(value, out temp) == true)
                {
                    returnValue = temp;
                }
                else
                {
                    returnValue = defaultValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Safe Byte Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Byte SafeByteParse(this string value, Byte defaultValue = 0)
        {
            Byte returnValue = defaultValue;

            if (value.IsValidString())
            {
                if (Byte.TryParse(value.ToString(), out returnValue) == false)
                {
                    returnValue = defaultValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// IsValidString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidString(this string value)
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(value) == false && string.IsNullOrWhiteSpace(value) == false)
            {
                isValid = true;
            }

            return isValid;
        }

        #endregion

        #region Integer

        /// <summary>
        /// Safe Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeToString(this int? value)
        {
            string returnValue = string.Empty;

            if (value.HasValue)
            {
                returnValue = value.ToString();
            }

            return returnValue;
        }

        /// <summary>
        /// ToEnum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this int? value) where TEnum : struct
        {
            return value.GetValueOrDefault(0).ToEnum<TEnum>();
        }

        /// <summary>
        /// ToEnum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this int value) where TEnum : struct
        {
            TEnum obj = default(TEnum);

            object tempObject = Enum.ToObject(typeof(TEnum), value);

            if (tempObject != null)
            {
                obj = (TEnum)tempObject;
            }

            return obj;
        }

        #endregion

        #region Double

        /// <summary>
        /// Safe Integer Parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int SafeIntegerParse(this double? value, int defaultValue = 0)
        {
            if (value.HasValue)
            {
                return value.ToString().SafeIntegerParse(defaultValue);
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Is Equal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <param name="decimalDigits"></param>
        /// <returns></returns>
        public static bool IsEqual(this double? value, double? compareValue, int decimalDigits)
        {
            double? tempValue = compareValue;

            if (compareValue.HasValue && decimalDigits > 0)
            {
                tempValue = Math.Round(compareValue.Value, decimalDigits);
            }

            return value == tempValue;
        }

        /// <summary>
        /// Is Equal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <param name="decimalDigits"></param>
        /// <returns></returns>
        public static bool IsEqual(this decimal? value, decimal? compareValue, int decimalDigits)
        {
            decimal? tempValue = compareValue;

            if (compareValue.HasValue && decimalDigits > 0)
            {
                tempValue = Math.Round(compareValue.Value, decimalDigits);
            }

            return value == tempValue;
        }

        /// <summary>
        /// Convert To Deciaml
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Convert To Deciaml?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ConvertToNullableDecimal(this double? value)
        {
            if (value.HasValue)
            {
                return Convert.ToDecimal(value.Value);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Decimal

        /// <summary>
        /// Safe Nullable Double Parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? SafeNullableDoubleParse(this decimal? value)
        {
            double? returnValue = null;

            if (value.HasValue)
            {
                returnValue = value.ToString().SafeDoubleParse();
            }

            return returnValue;
        }

        /// <summary>
        /// Is Equal
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool IsEqual(this decimal? value1, decimal? value2)
        {
            bool isEqual = false;

            if (value1.HasValue && value2.HasValue)
            {
                string strValue1 = CoreUtilities.GetFormatedNumber(value1, 12);
                string strValue2 = CoreUtilities.GetFormatedNumber(value2, 12);

                int subStringLength = strValue1.Length > 0 ? (strValue1.Length - 1) : 0;

                if (strValue1.Length > strValue2.Length)
                {
                    subStringLength = strValue2.Length > 0 ? (strValue2.Length - 1) : 0;
                }

                decimal num1 = strValue1.Substring(0, subStringLength).SafeDecimalParse();
                decimal num2 = strValue2.Substring(0, subStringLength).SafeDecimalParse();

                isEqual = num1.Equals(num2);
            }
            else if (!value1.HasValue && !value2.HasValue)
            {
                isEqual = true;
            }

            return isEqual;
        }

        /// <summary>
        /// To Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this decimal value) where TEnum : struct
        {
            return ((int)value).ToEnum<TEnum>();
        }

        #endregion

        #region Enum

        /// <summary>
        /// Get Enum Description Attribute Value
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumObj)
        {
            string description = string.Empty;

            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            if (fieldInfo != null)
            {
                object[] attribArray = fieldInfo.GetCustomAttributes(false);

                if (attribArray != null)
                {
                    DescriptionAttribute descriptionAttribute = attribArray.FirstOrDefault(c =>
                        c.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        description = descriptionAttribute.Description;
                    }
                }
            }

            return description;
        }

        /// <summary>
        /// Get Value
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static T GetValue<T>(this Enum enumObj) where T : struct
        {
            T eValue = default(T);

            try
            {
                FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

                if (fieldInfo != null)
                {
                    object[] attribArray = fieldInfo.GetCustomAttributes(false);

                    if (attribArray != null)
                    {
                        EnumMemberAttribute eMemberAttribute = attribArray.FirstOrDefault(c =>
                            c.GetType() == typeof(EnumMemberAttribute)) as EnumMemberAttribute;

                        if (eMemberAttribute != null)
                        {
                            if (typeof(T) == typeof(Int32))
                            {
                                eValue = (T)Convert.ChangeType(eMemberAttribute.Value.SafeIntegerParse(), typeof(T));
                            }
                            else if (typeof(T) == typeof(Int16))
                            {
                                eValue = (T)Convert.ChangeType(eMemberAttribute.Value.SafeShortParse(), typeof(T));
                            }
                            else if (typeof(T) == typeof(Byte))
                            {
                                eValue = (T)Convert.ChangeType(eMemberAttribute.Value.SafeByteParse(), typeof(T));
                            }
                            else
                            {
                                eValue = (T)Convert.ChangeType(eMemberAttribute.Value, typeof(T));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return eValue;
        }

        /// <summary>
        /// Safe Enum Parse
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum SafeEnumParse<TEnum>(this string value) where TEnum : struct
        {
            TEnum obj = default(TEnum);

            if (value.IsValidString())
            {
                Enum.TryParse<TEnum>(value, out obj);
            }

            return obj;
        }

        #endregion

        #region Byte

        /// <summary>
        /// To Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this byte? value) where TEnum : struct
        {
            return value.GetValueOrDefault(0).ToEnum<TEnum>();
        }

        /// <summary>
        /// To Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this byte value) where TEnum : struct
        {
            return ((int)value).ToEnum<TEnum>();
        }

        #endregion

        #region Serialization

        #region Binary

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(this object obj)
        {
            byte[] arr = null;

            if (obj != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, obj);
                    arr = stream.ToArray();
                }
            }

            return arr;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this byte[] bytes, SerializationBinder pSerializationBinder = null) where T : class
        {
            T obj = default(T);
            BinaryFormatter formatter = null;
            MemoryStream stream = null;

            if (bytes != null)
            {
                formatter = new BinaryFormatter();

                if (pSerializationBinder != null)
                {
                    formatter.Binder = pSerializationBinder;
                }

                using (stream = new MemoryStream(bytes))
                {
                    obj = formatter.Deserialize(stream) as T;
                }
            }

            return obj;
        }

        #endregion

        #region XML

        /// <summary>
        /// XML Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] XMLSerialize(this object obj)
        {
            byte[] arr = null;

            if (obj != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

                using (MemoryStream stream = new MemoryStream())
                {
                    xmlSerializer.Serialize(stream, obj);
                    arr = stream.ToArray();
                }
            }

            return arr;
        }

        /// <summary>
        /// XML Deserialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T XMLDeserialize<T>(this string xml) where T : class
        {
            T obj = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringReader stringReader = new StringReader(xml))
            {
                obj = xmlSerializer.Deserialize(stringReader) as T;
            }

            return obj;
        }

        #endregion

        #endregion

        #region DateTime

        /// <summary>
        /// ToDIFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static string ToDIFormat(this DateTime pDateTime)
        {
            string dateString = pDateTime.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            string tempValue = string.Format("{0}.{1}", pDateTime.Second, dateString.Split('.')[1]);
            Decimal tempDecimal = Math.Round(Decimal.Parse(tempValue), 3, MidpointRounding.AwayFromZero);
            int newMilliSeconds = int.Parse(tempDecimal.ToString().Split('.')[1]);
            DateTime diDate = new DateTime(pDateTime.Year, pDateTime.Month, pDateTime.Day, pDateTime.Hour, pDateTime.Minute, pDateTime.Second, newMilliSeconds);
            return diDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// ToStandardFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static string ToStandardFormat(this DateTime? pDateTime)
        {
            return pDateTime.HasValue ?
                Extensions.ToStandardFormat(pDateTime.Value, true) : string.Empty;
        }

        /// <summary>
        /// ToStandardFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static string ToStandardFormat(this DateTime pDateTime)
        {
            return Extensions.ToStandardFormat(pDateTime, true);
        }

        /// <summary>
        /// ToStandardFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pIncludeTime"></param>
        /// <returns></returns>
        public static string ToStandardFormat(this DateTime? pDateTime, bool pIncludeTime)
        {
            return pDateTime.HasValue ?
                Extensions.ToStandardFormat(pDateTime.Value, pIncludeTime) : string.Empty;
        }

        /// <summary>
        /// ToStandardFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pIncludeTime"></param>
        /// <returns></returns>
        public static string ToStandardFormat(this DateTime pDateTime, bool pIncludeTime)
        {
            if (pIncludeTime)
            {
                return pDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                return pDateTime.ToString("dd/MM/yyyy");
            }
        }

        /// <summary>
        /// ToUIFormat
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pIncludeSeconds"></param>
        /// <returns></returns>
        public static string ToUIFormat(this DateTime pDateTime, bool pIncludeSeconds)
        {
            if (pIncludeSeconds)
            {
                return pDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                return pDateTime.ToString("dd/MM/yyyy hh:mm tt");
            }
        }

        /// <summary>
        /// To Time Format
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pUse24Format"></param>
        /// <returns></returns>
        public static string ToTimeFormat(this DateTime pDateTime, bool pUse24Format = false)
        {
            if (pUse24Format)
            {
                return pDateTime.ToString("HH:mm:ss");
            }
            else
            {
                return pDateTime.ToString("hh:mm:ss tt");
            }
        }

        /// <summary>
        /// CleanTime
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime CleanTime(this DateTime pDateTime)
        {
            return new DateTime(pDateTime.Year, pDateTime.Month, pDateTime.Day);
        }

        /// <summary>
        /// CleanMilliseconds
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime CleanMilliseconds(this DateTime pDateTime)
        {
            return new DateTime(pDateTime.Year, pDateTime.Month, pDateTime.Day, pDateTime.Hour, pDateTime.Minute, pDateTime.Second);
        }

        /// <summary>
        /// GetValueorDefaultDateTime
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime GetValueOrCurrent(this DateTime? pDateTime)
        {
            return pDateTime.GetValueOrDefault(DateTime.Now);
        }

        /// <summary>
        /// EachDay
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable EachDay(this DateTime start, DateTime end)
        {
            DateTime currentDay = new DateTime(start.Year, start.Month, start.Day);

            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }

        /// <summary>
        /// EachMonth
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable EachMonth(this DateTime start, DateTime end)
        {
            DateTime startMonth = CoreUtilities.GetFirstDayOfMonth(start);
            DateTime endMonth = CoreUtilities.GetFirstDayOfMonth(end);

            while (startMonth <= endMonth)
            {
                yield return startMonth;
                startMonth = startMonth.AddMonths(1);
            }
        }

        #endregion

        #region Web Extensions

        /// <summary>
        /// Redirect
        /// </summary>
        /// <param name="response"></param>
        /// <param name="url"></param>
        /// <param name="target"></param>
        /// <param name="windowFeatures"></param>
        public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
        {
            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
                String.IsNullOrEmpty(windowFeatures))
            {
                response.Redirect(url, false);
            }
            else
            {
                Page page = (Page)HttpContext.Current.Handler;

                if (page == null)
                {
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                }

                url = page.ResolveClientUrl(url);

                string script = string.Empty;

                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }

                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }

        #endregion
    }
}