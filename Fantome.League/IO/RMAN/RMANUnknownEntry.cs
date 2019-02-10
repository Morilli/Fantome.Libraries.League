using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.Libraries.League.IO.RMAN
{
    public class RMANUnknownEntry
    {
        public ulong Unknown1Hash { get; private set; }
        public uint Unknown2Offset { get; private set; }
        public uint Unknown3Offset { get; private set; }
        public ulong Unknown4Hash { get; private set; }
        public uint Unknown5 { get; private set; }

        public RMANUnknownEntry(BinaryReader br)
        {
            this.Unknown1Hash = br.ReadUInt32();
            this.Unknown2Offset = br.ReadUInt32();
            this.Unknown3Offset = br.ReadUInt32();
            this.Unknown4Hash = br.ReadUInt64();
            this.Unknown5 = br.ReadUInt32();
        }
    }
}
