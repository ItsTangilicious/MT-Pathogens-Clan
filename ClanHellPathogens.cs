using Test_Bounce;
using Trainworks.BuildersV2;
using UnityEngine;



namespace HellPathogens.Clan
{
    class Clan
    {
        public static readonly string ID = Rats.GUID + "HellPathogens_Clan";

            public static void BuildClan()
            {
                new ClassDataBuilder
                {
                    ClassID = ID,
                    Name = "Hellborne Pathogens",
                    TitleLoc = "HellPathogens_Clan_Name",
                    Description = "Test Clan Description",
                    SubclassDescription = "Test Clan Sub Description",
                    CardStyle = ClassCardStyle.Stygian,
                    IconAssetPaths =
                {
                    "AssetsAll/ClanAssets/PathogensLarge.png",
                    "AssetsAll/ClanAssets/PathogensLarge.png",
                    "AssetsAll/ClanAssets/PathogensLarge.png",
                    "AssetsAll/ClanAssets/PathogensSilhouette.png"
                },
                    DraftIconPath = "AssetsAll/ClanAssets/PathogensCardBack.png",
                    UiColor = new Color(0.43f, 0.15f, 0.81f, 1f),
                    UiColorDark = new Color(0.12f, 0.42f, 0.39f, 1f),
                }.BuildAndRegister();
              
                  
                }
            }
        }
    

