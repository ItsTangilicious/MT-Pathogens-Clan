using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.Managers;

namespace HellPathogens.HostSubtype

{
    class HostSubtype
    {
        public static readonly string Host = Rats.GUID + "_SubtypeHost";

        public static void BuildAndRegister()
        {
            CustomCharacterManager.RegisterSubtype(Host, "Host");
        }
    }
}