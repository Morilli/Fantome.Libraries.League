using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.Libraries.League.IO.RMAN
{
    public class RMANContent
    {
        public RMANContent(byte[] data)
        {
            using (BinaryReader br = new BinaryReader(new MemoryStream(data)))
            {
                for (int i = 0; i < 6; i++)
                {
                    int length = br.ReadInt32();
                    Console.WriteLine(length);
                    br.ReadBytes(length);
                }
            }
        }
    }
}
