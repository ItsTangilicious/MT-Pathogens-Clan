using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace SpellCardPathogens
{
    internal class HurriedExit
    {
        public static readonly string ID = Rats.CLANID + "HurriedExit";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Hurried Exit",
                Description = "<b>Ascend</b> a unit and apply [sap]<b><nobr>[effect1.status0.power]</nobr></b>.",
                Cost = 2,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/HurriedExitSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectBump),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                        ParamInt = 1,
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.LastTargetedCharacters,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Sap,
                                count =  2
                            }
                        }



                    },
                }
            }.BuildAndRegister();
        }
    }
}