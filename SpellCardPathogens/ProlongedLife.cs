using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;


namespace SpellCardPathogens
{
    internal class ProlongedLife
    {
        public static readonly string ID = Rats.CLANID + "_ProlongedLife";


        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = "_ProlongedLife",
                Name = "Prolonged Life",
                Description = "Apply <b>Replicate</b> to a friendly unit.",
                Cost = 1,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/ProlongedLifeSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                /*TraitBuilders =
                {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   },
                },*/
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
                                statusId = StatusEffectReplicateStackable.statusID,
                                count =  1
                            }
                        }

                    },           
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_ProlongedLifeReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply <b>Damage Shield <nobr>[effect0.status0.power]</nobr></b> to a random friendly unit on the floor where your turn ended.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.RandomInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.DamageShield,
                                        count =  1
                                    }
                                }
                            }
                        }

                    }
                }
            }.BuildAndRegister();
        }
    }
}
