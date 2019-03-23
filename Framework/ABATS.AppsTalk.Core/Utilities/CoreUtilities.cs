using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Provides the common application utilities
    /// </summary>
    public static class CoreUtilities
    {
        #region Core Utilities

        /// <summary>
        ///     Build Parameters
        ///     ex: code=master
        /// </summary>
        /// <param name="pArguments"></param>
        /// <returns></returns>
        public static List<ParameterInfo> BuildParameters(string[] pArguments)
        {
            List<ParameterInfo> parameters = null;

            try
            {
                parameters = new List<ParameterInfo>();

                foreach (string arg in pArguments)
                {
                    string[] parts = arg.Split('=');

                    if (parts.Length == 2)
                    {
                        SystemParameter sysParameter = SystemParameter.None;

                        if (Enum.TryParse(parts[0].Trim().ToLower(), out sysParameter))
                        {
                            parameters.Add(new ParameterInfo(sysParameter, parts[1].Trim()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return parameters;
        }

        /// <summary>
        /// Used to get an attribute instance of specified type from object
        /// </summary>
        /// <typeparam name="T">Type of the Attribute</typeparam>
        /// <param name="pObject">Target Object</param>
        /// <returns>Instance of the Attribute</returns>
        public static T GetAttribute<T>(object pObject) where T : Attribute
        {
            T fieldAtt = default(T);

            if (pObject != null)
            {
                Type fieldsEnumType = pObject.GetType();

                FieldInfo refFieldInfo = fieldsEnumType.GetField(pObject.ToString());

                if (refFieldInfo != null)
                {
                    fieldAtt = Attribute.GetCustomAttribute(refFieldInfo, typeof(T), false) as T;
                }
            }

            return fieldAtt;
        }

        /// <summary>
        /// Get Negative Number
        /// </summary>
        /// <param name="pNumber"></param>
        /// <returns></returns>
        public static int GetNegativeNumber(int? pNumber)
        {
            return CoreUtilities.GetNegativeNumber(pNumber.GetValueOrDefault(0));
        }

        /// <summary>
        /// Get Negative Number
        /// </summary>
        /// <param name="pNumber"></param>
        /// <returns></returns>
        public static int GetNegativeNumber(int pNumber)
        {
            int negativeNum = pNumber;

            if (pNumber != 0)
            {
                negativeNum = int.Parse(string.Format("-{0}", pNumber.ToString()));
            }

            return negativeNum;
        }

        /// <summary>
        /// Get First Day Of Month
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(DateTime pDateTime)
        {
            return new DateTime(pDateTime.Year, pDateTime.Month, 1);
        }

        /// <summary>
        /// Get Last Day Of Month
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pGetLastSecond"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(DateTime pDateTime, bool pGetLastSecond = false)
        {
            DateTime dtTo = pDateTime;
            dtTo = dtTo.AddMonths(1);

            dtTo = dtTo.AddDays(-(dtTo.Day));

            if (pGetLastSecond)
            {
                dtTo = CoreUtilities.GetLastSecondOfDay(dtTo);
            }

            return dtTo;
        }

        /// <summary>
        /// Get Last Minute Of Day
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastSecondOfDay(DateTime pDateTime)
        {
            return new DateTime(pDateTime.Year, pDateTime.Month, pDateTime.Day, 23, 59, 59);
        }

        /// <summary>
        /// Build Price Date BPC Key
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static long BuildPriceDateBPCKey(DateTime pDateTime)
        {
            return CoreUtilities.BuildPriceDateBPCKey(pDateTime, false);
        }

        /// <summary>
        /// Build Price Date BPC Key
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="pWithTime"></param>
        /// <returns></returns>
        public static long BuildPriceDateBPCKey(DateTime pDateTime, bool pWithTime)
        {
            long iValue = 1;

            if (!pWithTime)
            {
                iValue = long.Parse(string.Format("{0}{1}{2}", pDateTime.Year.ToString(), pDateTime.Month.ToString("#00"), pDateTime.Day.ToString("#00")));
            }
            else
            {
                iValue = long.Parse(string.Format("{0}{1}{2}{3}{4}", pDateTime.Year.ToString(), pDateTime.Month.ToString("#00"), pDateTime.Day.ToString("#00"), pDateTime.Hour.ToString("#00"), pDateTime.Minute.ToString("#00")));
            }

            return iValue;
        }

        /// <summary>
        /// GetJustDate
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime GetOnlyDate(DateTime pDateTime)
        {
            return new DateTime(pDateTime.Year, pDateTime.Month, pDateTime.Day);
        }

        /// <summary>
        /// GetFormatedNumber
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static string GetFormatedNumber(decimal? pValue, int pDecimalDigits)
        {
            string pFormatedNumber = string.Empty;
            string format = "########";
            if (pDecimalDigits > 0) { format += "."; }

            for (int i = 1; i <= pDecimalDigits; i++)
            {
                format += "0";
            }

            pFormatedNumber = pValue.GetValueOrDefault(0).ToString(format);

            return pFormatedNumber;
        }

        /// <summary>
        /// GetFormatedNumber
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static string GetFormatedNumber(decimal pValue, int pDecimalDigits)
        {
            string pFormatedNumber = string.Empty;
            string format = "########";
            if (pDecimalDigits > 0) { format += "."; }

            for (int i = 1; i <= pDecimalDigits; i++)
            {
                format += "0";
            }

            pFormatedNumber = pValue.ToString(format);

            return pFormatedNumber;
        }

        /// <summary>
        /// GetFormatedNumber
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static decimal? UpdateDecimalDigits(decimal? pValue, int pDecimalDigits)
        {
            decimal? pFormatedNumber = pValue;
            string format = "########";

            if (pDecimalDigits > 0) { format += "."; }

            for (int i = 1; i <= pDecimalDigits; i++)
            {
                format += "0";
            }

            pFormatedNumber = pValue.GetValueOrDefault(0).ToString(format).SafeNullableDecimalParse();

            return pFormatedNumber;
        }

        /// <summary>
        /// Round
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static decimal? Round(decimal? pValue, int pDecimalDigits, bool pTruncate = false)
        {
            decimal? roundedNumber = pValue;

            roundedNumber = CoreUtilities.UpdateDecimalDigits(roundedNumber, pDecimalDigits);

            return roundedNumber;
        }

        /// <summary>
        /// Calculates the lenght in bytes of an object 
        /// and returns the size 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static int GetObjectSize(object pObject)
        {
            int length = 0;
            byte[] array = null;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, pObject);

                array = ms.ToArray();
                length = array.Length;
            }

            return length;
        }

        /// <summary>
        /// Get Deciaml Digits String Format
        /// </summary>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static string GetDeciamlDigitsStringFormat(int pDecimalDigits)
        {
            string format = "{0:0";

            if (pDecimalDigits > 0)
            {
                format += ".";
            }

            for (int i = 1; i <= pDecimalDigits; i++)
            {
                format += "0";
            }

            format += "}";

            return format;
        }

        /// <summary>
        /// Get Column Name From Index
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static String GetColumnNameFromIndex(int column)
        {
            column--;

            String col = Convert.ToString((char)('A' + (column % 26)));

            while (column >= 26)
            {
                column = (column / 26) - 1;
                col = Convert.ToString((char)('A' + (column % 26))) + col;
            }

            return col;
        }

        /// <summary>
        /// Safe Dispose
        /// </summary>
        /// <param name="pObject"></param>
        public static void SafeDispose<T>(ref T pObject) where T : class
        {
            if (pObject != null && !pObject.GetType().IsValueType)
            {
                if (pObject is IList)
                {
                    IList list = pObject as IList;

                    for (int i = 0; i < list.Count; i++)
                    {
                        var item = list[i];
                        CoreUtilities.SafeDispose(ref item);
                        list[i] = item;
                    }
                }

                else if (pObject is IDisposable)
                {
                    (pObject as IDisposable).Dispose();
                }

                pObject = null;
            }
        }

        /// <summary>
        /// Validate Date Range
        /// </summary>
        /// <param name="pFromDate"></param>
        /// <param name="pToDate"></param>
        /// <returns></returns>
        public static bool ValidateDateRange(DateTime? pFromDate, DateTime? pToDate)
        {
            bool isValid = true;

            if (pFromDate.HasValue && pToDate.HasValue && (pFromDate > pToDate))
            {
                isValid = false;
            }

            return isValid;
        }

        #endregion

        #region Xml DbRecord Handlers

        /// <summary>
        /// Get Bytes
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string pString)
        {
            byte[] bytes = new byte[pString.Length * sizeof(char)];
            Buffer.BlockCopy(pString.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Get String
        /// </summary>
        /// <param name="pBytes"></param>
        /// <returns></returns>
        public static string GetString(byte[] pBytes)
        {
            char[] chars = new char[pBytes.Length / sizeof(char)];
            Buffer.BlockCopy(pBytes, 0, chars, 0, pBytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// Construct Xml From DBRecordInfo
        /// </summary>
        /// <param name="pDbRecordInfo"></param>
        /// <returns></returns>
        public static byte[] ConstructXmlFromRecord(DBRecordInfo pDbRecordInfo)
        {
            XDocument doc = new XDocument(
                new XElement(Constants.TableName_RecordDetails,
                    new XElement(Constants.ColumnName_RecordStatus, ((int)pDbRecordInfo.RecordTransactionStatus).ToString()),
                    CoreUtilities.BuildRecordDetails(pDbRecordInfo.Row)));

            return CoreUtilities.GetBytes(doc.ToString());
        }

        /// <summary>
        /// Build Record Details
        /// </summary>
        /// <param name="pDataRow"></param>
        /// <returns></returns>
        public static List<XElement> BuildRecordDetails(DataRow pDataRow)
        {
            return
                (from DataColumn dataColumn in pDataRow.Table.Columns
                 select new XElement(
                     CoreUtilities.FormatXMLColumnName(dataColumn.ColumnName, true),
                     pDataRow[dataColumn])).ToList();
        }

        /// <summary>
        /// Format XML Column Name
        /// </summary>
        /// <param name="pColumnName"></param>
        /// <param name="pGetXMLName"></param>
        /// <returns></returns>
        public static string FormatXMLColumnName(string pColumnName, bool pGetXMLName)
        {
            if (pGetXMLName)
            {
                return pColumnName.Replace("#", "_HASHTAG_");
            }
            else
            {
                return pColumnName.Replace("_HASHTAG_", "#");
            }
        }

        #endregion

        #region Settings

        /// <summary>
        /// Used to get Settings Item from the Configuration file
        /// </summary>
        /// <param name="pKey">Settings Item Key</param>
        /// <returns>Settings Item Value</returns>
        public static string GetSettingsItemValue(SettingsKey pSettingsKey)
        {
            return CoreUtilities.GetSettingsItemValue(pSettingsKey.GetDescription());
        }

        /// <summary>
        /// Used to get Settings Item from the Configuration file
        /// </summary>
        /// <param name="pSettingsKey">Settings Item Key</param>
        /// <returns>Configuration Item Value</returns>
        public static string GetSettingsItemValue(string pSettingsKey)
        {
            string itemValue = string.Empty;

            if (ConfigurationManager.AppSettings.AllKeys.Contains(pSettingsKey))
            {
                itemValue = ConfigurationManager.AppSettings[pSettingsKey];
            }

            return itemValue;
        }

        #endregion

        #region Size Conversion

        public static double ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f);
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public static double ConvertMegabytesToGigabytes(double megabytes)
        {
            return megabytes / 1024.0;
        }

        public static double ConvertMegabytesToTerabytes(double megabytes)
        {
            return megabytes / (1024.0 * 1024.0);
        }

        public static double ConvertGigabytesToMegabytes(double gigabytes)
        {
            return gigabytes * 1024.0;
        }

        public static double ConvertGigabytesToTerabytes(double gigabytes)
        {
            return gigabytes / 1024.0;
        }

        public static double ConvertTerabytesToMegabytes(double terabytes)
        {
            return terabytes * (1024.0 * 1024.0);
        }

        public static double ConvertTerabytesToGigabytes(double terabytes)
        {
            return terabytes * 1024.0;
        }

        #endregion
    }
}