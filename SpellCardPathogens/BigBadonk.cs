using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;


namespace SpellCardPathogens
{

    class BigBadonkas
    {
        public static readonly string ID = Rats.CLANID + "_BigBadonkas";


        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = "_BigBadonk",
                Name = "Destructive Testing",
                Description = "Apply <b>Replicate</b> to a friendly unit. Then destroy it and draw a card.",
                Cost = 0,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/DestructiveTestingSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
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
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectKill),
                        ParamInt = 1,
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDraw),
                        ParamInt = 1,
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.None,
                        ShouldTest = false
                    }
                },
            }.BuildAndRegister();
        }
    }
}
