using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;


namespace SpellCardPathogens
{
    internal class ColiformDeterminatorSpell
   { 
   public static readonly string ID = Rats.CLANID + "ColiformDeterminatorSpell";

    public static void BuildAndRegister()
    {
        new CardDataBuilder
        {
            CardID = ID,
            Name = "Experimental Cloning Device",
            Description = "Spawn a copy of a random unit from your deck to the back of this room. Any [attack] or [health] buffs applied to the copied unit will apply to original card until it is played.",
            Cost = 3,
            Rarity = CollectableRarity.Rare,
            TargetsRoom = true,
            Targetless = true,
            ClanID = Clan.ID,
            AssetPath = "AssetsAll/MonsterAssets/ColiformCard.png",
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
                                            EffectStateType = typeof(CardEffectSpawnUnitFromDeck),
                                            TargetMode = TargetMode.DrawPile,
                                            TargetTeamType = Team.Type.None,
                                            TargetCardType = CardType.Monster,
                                            ParamInt = 2,

                                        }
                    
                }
        }.BuildAndRegister();
    }
}
}
