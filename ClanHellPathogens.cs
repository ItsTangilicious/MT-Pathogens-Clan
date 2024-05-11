using Test_Bounce;
using Trainworks.BuildersV2;
using UnityEngine;
using Trainworks.ConstantsV2;
using Trainworks.ManagersV2;
using Trainworks.Enums;



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
                    Name = "Hellborn Pathogens",
                    TitleLoc = "HellPathogens_Clan_Name",
                    Description = "Test Clan Description",
                    SubclassDescription = "Test Clan Sub Description",
                    CardStyle = ClassCardStyle.Stygian,
                    IconAssetPaths =
                {   
                    "assets/testclan-large.png",
                    "assets/testclan-large.png",
                    "assets/testclan-large.png",
                    "assets/testclan-silhouette.png"
                },
                    DraftIconPath = "assets/TestClan_CardBack.png",
                    UiColor = new Color(0.43f, 0.15f, 0.81f, 1f),
                    UiColorDark = new Color(0.12f, 0.42f, 0.39f, 1f),
                }.BuildAndRegister();
              
                  
                }
            }
        }
    

