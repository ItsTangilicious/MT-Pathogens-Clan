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
    internal class LifeElixir
    {
        public static readonly string ID = Rats.CLANID + "_LifeElixir";


        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = "_LifeElixir",
                Name = "Life Elixir",
                Description = "Apply <b>Replicate</b> to a friendly unit.",
                Cost = 0,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/LifeElixirSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitExhaustState)
                    },
                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectReplicate.statusID,
                                count =  1
                            }
                        }

                    },
            
                },
            }.BuildAndRegister();
        }
    }
}

