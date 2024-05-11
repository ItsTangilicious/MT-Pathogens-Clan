using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.Managers;

namespace HellPathogens.InstrumentSubtype

{
    class InstrumentSubtype
    {
        public static readonly string Instrument = Rats.GUID + "_SubtypeInstrument";

        public static void BuildAndRegister()
        {
            CustomCharacterManager.RegisterSubtype(Instrument, "Instrument");
        }
    }
}