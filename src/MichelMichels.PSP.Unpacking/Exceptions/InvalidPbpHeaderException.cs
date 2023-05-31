using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichelMichels.PSP.PBP.Exceptions;

public class InvalidPbpHeaderException : Exception
{
    public InvalidPbpHeaderException(string message) : base(message) { }
}
