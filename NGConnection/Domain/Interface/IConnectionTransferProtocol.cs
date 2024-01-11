using System;
using System.Collections.Generic;
using System.Text;

namespace NGConnection.Interface
{
    public interface IConnectionTransferProtocol
    {
        byte[] Select(string filePath);
    }
}
