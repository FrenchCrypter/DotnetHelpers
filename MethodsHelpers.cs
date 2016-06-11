using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetHelpers
{
    public class MethodsHelpers
    {
        public void RunUntilWork(bool method)
        {
            for(int i = 0; i < 5; i++)
            {
                if (method)
                    break;
            }
        }


    }
}
