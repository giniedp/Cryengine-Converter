using System;
using System.IO;
using System.Linq;

namespace CgfConverter.CryEngineCore;

internal sealed class ChunkMtlName_804 : ChunkMtlName
{
    public override void Read(BinaryReader b)
    {
        base.Read(b);

        var bytes = b.ReadBytes((int)Size);
        
        Name = System.Text.Encoding.UTF8.GetString(
            bytes
                .Reverse()
                .SkipWhile(x => x == 0)
                .TakeWhile(x => x != 0 && x != 255)
                .Reverse()
                .ToArray()
        );
        NumChildren = 0;

        return;
        // SkipBytes(b, 38); // contains some ID e.g.: {85CC24CE-D415-52CB-B590-EBD8C994A042}
        // SkipBytes(b, 26); // usually empty bytes
        // // some count followed by 3 emtpy bytes 
        // var count = b.ReadByte();
        // SkipBytes(b, 3);

        // // skip some flags
        // SkipBytes(b, count * 4);
        
        // //Name = b.ReadFString((int)(Offset + Size - b.BaseStream.Position));
        // Name = b.ReadCString();
        // Console.WriteLine($"NAME {Name}");
        // NumChildren = 0;
    }
}
