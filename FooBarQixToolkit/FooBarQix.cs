/*
 * Title: FooBarQixToolkit
 * File: FooBarQix.cs
 * Description: Main class.
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
using System.IO;
using System.Linq;
using System.Text;

namespace FooBarQixToolkit
{
    public class FooBarQix
    {
        #region Attributes
        private readonly FooBarQixOperationsManager ObjfooBarQixManager;
        public static FooBarQixLog Logger;
        #endregion
        #region Constructor
        public FooBarQix()
        {
            Logger = new FooBarQixLog();
            Logger.InitializeLog();
            Logger.TraceLog(LogLevel.Info, "Initialize FooBarQix Toolkit");
            ObjfooBarQixManager = new FooBarQixOperationsManager(Logger);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Evaluate the string using the division and contains rules.
        /// </summary>
        /// <param name="strNumber">The  string number to be evaluated</param>
        /// <returns>The string returned after applying the division and the container rules</returns>
        public string Compute(string strNumber)
        {
            return ObjfooBarQixManager.EvaluateRules(strNumber);
        }
        public void ReleaseFooBarQix()
        {
            ObjfooBarQixManager.ReleaseFooBarQixOperationsManager();
            Logger.ReleaseLog();
        }
            #endregion
        }
}