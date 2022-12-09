using System;
using System.Collections.Generic;
using System.Text;

namespace Razensoft.Functional
{
    public partial class Result
    {
        public override string ToString()
        {
            return IsSuccess ? "Success" : $"Failure({Error})";
        }
    }


    public partial class Result<T>
    {
        public override string ToString()
        {
            return IsSuccess ? $"Success({Value})" : $"Failure({Error})";
        }
    }


    public partial class Result<T, E>
    {
        public override string ToString()
        {
            return IsSuccess ? $"Success({Value})" : $"Failure({Error})";
        }
    }


    public partial class UnitResult<E>
    {
        public override string ToString()
        {
            return IsSuccess ? "Success" : $"Failure({Error})";
        }
    }
}
