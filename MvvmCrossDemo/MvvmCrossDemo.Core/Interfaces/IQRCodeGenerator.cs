using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Interfaces
{
    public interface IQRCodeGenerator
    {
        byte[] Generate(string barcode);
    }
}
