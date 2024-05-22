using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;
using HellPathogens.CardPools;

namespace SpellCardPathogens
    //deleted from the actual mod as it was unused
{
    internal class EvolvingResistance2B
    {
        public static readonly string ID = Rats.CLANID + "_EvolvingResistance2B";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to friendly units. Upgrade this card.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "assets/nothornbreak.png",
                CardPoolIDs = {  },
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitSelfPurge)
                   },
                },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Armor,
                                count =  10
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectAddRunCard),
                         CopyModifiersFromSource = true,
                         TargetTeamType = Team.Type.None,
                         ParamInt = ((int)CardPile.DiscardPile),
                         AdditionalParamInt = 1,
                         ParamCardPool = MyCardPools.Resistance3B

                     }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistance2BReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> and [rage] <b><nobr>[effect1.status0.power]</nobr></b> to the front friendly unit. Upgrade this card and trigger <b>Purge</b>.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count =  5
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Rage,
                                        count =  2
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddRunCard),
                                CopyModifiersFromSource = true,
                                TargetTeamType = Team.Type.None,
                                ParamInt = ((int)CardPile.DiscardPile),
                                AdditionalParamInt = 1,
                                ParamCardPool = MyCardPools.Resistance3C

                            },
                            
                        }

                    }
                }

            }.BuildAndRegister();
        }
    }
}
