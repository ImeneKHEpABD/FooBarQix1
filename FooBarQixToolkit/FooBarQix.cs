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

namespace FooBarQixToolkit
{
    public class FooBarQix
    {
        private static Logger logger;
        private FooBarQixOperations foobarqixoperations;

        public FooBarQix(FooBarQixOperations opM)
        {
            logger = LogManager.GetCurrentClassLogger();
            logger.Info("Initialize FooBarQix Toolkit");
            foobarqixoperations = opM;
        }

        /// <summary>
        /// Evaluate the string using the division and contains rules.
        /// </summary>
        /// <param name="number">The  string number to be evaluated</param>
        /// <returns>The string returned after applying the division and the container rules</returns>
        public string Compute(string number)
        {
            try
            {
                return foobarqixoperations.EvaluateRules(number);
            }
            catch(Exception ex)
            {
                logger.Error("An error occurred in the Compute method: " + ex.Message);
                return string.Empty;
            }
 
        }
    }
}