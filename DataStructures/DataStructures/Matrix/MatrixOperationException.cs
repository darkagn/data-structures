using System;

namespace DataStructures.Matrix
{
    public class MatrixOperationException : ArgumentOutOfRangeException
    {
        public MatrixOperationException(string paramName, string message)
            : base(paramName, message)
        {
        }
    }
}
