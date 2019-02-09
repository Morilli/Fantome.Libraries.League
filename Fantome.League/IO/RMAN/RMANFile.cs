using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fantome.Libraries.League.Helpers.Compression;

namespace Fantome.Libraries.League.IO.RMAN
{
    public class RMANFile
    {
        public RMANFile(string fileLocation) : this(File.OpenRead(fileLocation)) { }

        public RMANFile(Stream stream)
        {
            using (BinaryReader br = new BinaryReader(stream))
            {
                string magic = Encoding.ASCII.GetString(br.ReadBytes(4));
                if(magic != "RMAN")
                {
                    throw new Exception("This is not a valid RMAN file");
                }

                uint unknown = br.ReadUInt32();
                uint unknownCount = br.ReadUInt32();

                uint compressedFileSize = br.ReadUInt32();
                ulong releaseID = br.ReadUInt64();
                uint uncompressedFileSize = br.ReadUInt32();

                byte[] uncompressedFile = Compression.DecompressZStandard(br.ReadBytes((int)compressedFileSize));
                RMANContent content = new RMANContent(uncompressedFile);
                byte[] unknownData = br.ReadBytes(256);
            }
        }
    }
}
