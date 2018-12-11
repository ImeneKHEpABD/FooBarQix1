/*
 * Title: FooBarQixToolkit
 * File: FooBarQixManager.cs
 * Description: Class to manage the FooBarQix operations.
 * Author:Imene Khemiri
 * Copyright: Copyright (c) 2018
 * @version 1.0.0
 * 
 * UPDATES HISTORY
 * ------------------------------

 * */

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixToolkit
{
    public class FooBarQixOperations
    {
        #region Attributes
        private readonly Dictionary<int, string> DicDividerRules;
        private readonly Dictionary<int, string> DicContainsRules;
        private FooBarQixLog Logger;
        private bool bLogInitialized;
        public bool LogInitialized {get ; set; }
           
        #endregion
        #region Constructor
        public FooBarQixOperations()
        {
            Logger = new FooBarQixLog();
            Logger.InitializeLog();
            bLogInitialized = true;
            DicDividerRules = new Dictionary<int, string>
            {
                [3] = "Foo",
                [5] = "Bar",
                [7] = "Qix"
            };
            DicContainsRules = new Dictionary<int, string>
            {
                [3] = "Foo",
                [5] = "Bar",
                [7] = "Qix",
                [0] = "*"
            };
        }
        public FooBarQixOperations(FooBarQixLog _Logger)
        {
            bLogInitialized = false;
            Logger = _Logger;
            DicDividerRules = new Dictionary<int, string>
            {
                [3] = "Foo",
                [5] = "Bar",
                [7] = "Qix"
            };
            DicContainsRules = new Dictionary<int, string>
            {
                [3] = "Foo",
                [5] = "Bar",
                [7] = "Qix",
                [0] = "*"
            };
        }
        #endregion
        #region Methods
        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="strNumber">The  string number to be evaluated</param>
        /// <returns>The string returned after applying the divider and the container rules</returns>
        public string EvaluateRules(string strNumber)
        {
            long lNumber = 0;
            var result = string.Empty;
            try
            {
                if (Int64.TryParse(strNumber, out lNumber))
                {
                    result = BuildStringByDividerRule(lNumber);
                    result += BuildStringByContainsRules(result, strNumber);
                    if (string.IsNullOrEmpty(result))
                        result = strNumber.ToString();
                }
                else
                {
                    Logger.TraceLog(LogLevel.Error, "The input value ["+ strNumber + "] is not a valid number");
                }
            }
            catch (Exception ex)
            {
                Logger.TraceException(ex, "EvaluateRules Error:");
            }
            return result;
        }
        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="lNumber">The number to be evaluated</param>
        /// <returns>The string returned after applying the divider rules</returns>
        private string BuildStringByDividerRule(long lNumber)
        {
            string strResult = string.Empty;
            try
            {
                foreach (var val in DicDividerRules)
                {
                    if (lNumber % val.Key == 0)
                        strResult += val.Value;
                }
            }
            catch (Exception ex)
            {
                Logger.TraceException(ex, "BuildStringByDividerRule Error:");
            }
            return strResult;
        }
        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="strDivResult">The string returned after applying the division rules</param>
        /// <param name="strNumberString">The number to be evaluated</param>
        /// <returns>The string returned after applying the contains rules</returns>
        private string BuildStringByContainsRules(string strDivResult, string strNumberString)
        {
            var result = string.Empty;
            try
            {
                if ((string.IsNullOrEmpty(strDivResult.Trim()) && (!strNumberString.AsEnumerable<char>().Select(x => int.Parse(x.ToString())).Any(x => DicDividerRules.ContainsKey(x)))))
                {

                    result = strNumberString.Replace('0', '*');


                }
                else
                {
                    result = strNumberString.Aggregate(result, (current, t) => current + BuildStringByDigitsContains(Int16.Parse(t.ToString())));
                }
            }
            catch (Exception ex)
            {
                Logger.TraceException(ex, "BuildStringByContainsRules Error:");
            }

            return result.ToString();
        }
        /// <summary>
        /// Returns the string that corresponds to the digit included in the contains rules.
        /// </summary>
        /// <param name="iNumber">The digit to be replaced by the correspondant string from the DicContainsRules if possible</param>
        /// <returns>The string returned after applying the contains rules</returns>
        private string BuildStringByDigitsContains(int iNumber)
        {
            var result = string.Empty;
            try
            {
                if (DicContainsRules.ContainsKey(iNumber))
                    result += DicContainsRules[iNumber];

            }
            catch (Exception ex)
            {
                Logger.TraceException(ex, "BuildStringByDigitsContains Error:");
            }
            return result;

        }
        /// <summary>
        /// Returns the string that corresponds to the digit included in the contains rules.
        /// </summary>
        /// <param name="iNumber">The digit to be replaced by the correspondant string from the DicContainsRules if possible</param>
        /// <returns>The string returned after applying the contains rules</returns>
        public void ReleaseFooBarQixOperationsManager()
        {
            try
            {
                DicDividerRules.Clear();
                DicContainsRules.Clear();
                if (bLogInitialized)
                    Logger.ReleaseLog();

            }
            catch (Exception ex)
            {
            }
               
        }
        #endregion

    }
}
