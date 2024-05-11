using HellPathogens.Clan;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class QueueTime
    {
        public static readonly string ID = Rats.CLANID + "_QueueTime";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Queue Time",
                Description = "Apply [rooted] <b><nobr>[effect0.status0.power]</nobr></b> to an enemy unit.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/QueueSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Heroes,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Rooted,
                                count =  2
                            }
                        }
                    },
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_QueueTimeReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "<b>Descend</b> friendly and enemy units on this floor.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectBump),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                                ParamInt = -1
                            }
                        }

                    }
                }

            }.BuildAndRegister();
        }
    }
}
