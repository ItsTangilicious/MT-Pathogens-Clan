using Trainworks.Managers;
using Test_Bounce;

namespace HellPathogens.PathogenSubtype

{
    class PathogenSubtype
    {
        public static readonly string Pathogen = Rats.GUID + "_SubtypePathogen";

        public static void BuildAndRegister()
        {
            CustomCharacterManager.RegisterSubtype(Pathogen, "Pathogen");
        }
    }
}


