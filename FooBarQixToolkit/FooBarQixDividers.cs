using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixToolkit
{
    public class FooBarQixDividers: FooBarQixRules
    {
        #region Attributes
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public Dictionary<int, string> DicDividerRules= new Dictionary<int, string>
        {
                [3] = "Foo",
                [5] = "Bar",
                [7] = "Qix"
        };
        #endregion

        #region Constructor
        public FooBarQixDividers()
        {
                   
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="number">The number to be evaluated</param>
        /// <returns>The string returned after applying the divider rules</returns>
        public override string BuildStringByRule(string number)
        {
            long Number = 0;
            var result = string.Empty;
            if (Int64.TryParse(number, out Number))
            {
                try
                {
                    foreach (var val in DicDividerRules)
                    {
                        if (Number % val.Key == 0)
                            result += val.Value;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("BuildStringByDividerRule Error: "+ ex.Message);
                }
            }
            return result;
        }
        #endregion
    }
}
