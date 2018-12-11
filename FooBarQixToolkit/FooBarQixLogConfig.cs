/*
 * Title: FooBarQixToolkit
 * File: FooBarQixLogConfig.cs
 * Description: The logging configuration class.
 * Author:Imene Khemiri
 * Copyright: Copyright (c) 2018
 * @version 1.0.0
 * ------------------------------

 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixToolkit
{
    public class FooBarQixLogConfig
    {
        #region DllImport
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion
        #region Attributes
        private string strpath;
        public string Path { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Ini Configuration File Constructor.
        /// </summary>
        /// <PARAM name="INIPath">the ini file path</PARAM>
        public FooBarQixLogConfig(string strINIPath)
        {
            strpath = strINIPath;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="strSection">Section name</PARAM>
        /// <PARAM name="strKey">Key Name</PARAM>
        /// <PARAM name="strValue">Value Name</PARAM>
        public void IniWriteValue(string strSection, string strKey, string strValue)
        {
            try
            {
                WritePrivateProfileString(strSection, strKey, strValue, this.strpath);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="strSection">Section name</PARAM>
        /// <PARAM name="strKey">Key Name</PARAM>
        /// <returns>The value of the key</returns>

        public string IniReadValue(string strSection, string strKey)
        {
            StringBuilder temp = new StringBuilder(255);
            int i;
            try
            {
                i = GetPrivateProfileString(strSection, strKey, "", temp, 255, this.strpath);
                return temp.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        #endregion

    }
}
