using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Trainworks.Managers;

namespace SpellCardPathogens
{
    internal class MiraculousRecovery
    {
        public static readonly string ID = Rats.CLANID + "_MiraculousRecovery";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Miraculous Recovery",
                Description = "Restore a friendly unit to full health and remove all debuffs.",
                Cost = 1,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/MiraculousSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CustomCardEffectHealToFull),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters,
                        //ParamInt = 9999
                     },
                      new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectRemoveAllStatusEffects),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters,
                        ParamInt = (int)StatusEffectData.DisplayCategory.Negative,
                        AppliedVFX = CustomCardManager.GetCardDataByID(VanillaCardIDs.PurifyingCleanse).GetEffects()[0].GetAppliedVFX(),
                      },
                }
            }.BuildAndRegister();
        }
    }
}
