using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Bounce
{
    internal class ChangeLog
    {
        /*
         * No actual coding here, just a change log.
         * 
         *May 17, 2024
         *Added Status Icons, Clan Banners, Clan Cardback, Clan Symbol assets.
         *
         *May 18, 2024
         *Carrier Immunologist stat gain reduced from 3/3; 5/5; 10/10 → 2/2; 4/4; 8/8
         *Carrier Bioengineer stat gain reduced from 10/10; 25/25; 50/50 → 10/5; 20/10; 40/20
         *Added RelicActivatedKey to Aerosolizer, Growth Chamber, Research Notebook
         *Moved Aeroslizer over to Localization CSV
         *Reduced Evolving Resistance play from Armor 10 → Armor 5
         *Reduced Evolving Resistance 2A play from Armor 10, Rage 5 → Armor 5, Rage 3
         *Reduced Evolving Resistance 2B play from Armor 10 → Armor 5
         *Reduced Evolving Resistance 3A play from Armor 10, Rage 5 → Armor 5, Rage 3
         *Reduced Evolving Resistance 3B play from Armor 12, Rage 6 → Armor 6, Rage 3
         *Reduced Evolving Resistance 3C play from Armor 10 → Armor 5
         *
         *May 19, 2024
         *Added Icon assets for both Champions
         *Removed starter cards and Recombinanat Virus from the MegaPool
         *Fixed CardEffectSpawnUnitFromDeck not always spawning a unit from deck
         *Added pre-load for the art of Recombinant Virus
         *
         *May 20, 2024
         *Changed Supervirus Hemorrhagic II from Gain 1 Shard, +3/+3 per shard → Gain 2 Shard, +2/+1 per shard
         *Reduced Supervirus Hemorrhagic III from Gain 2 Shard, +3/+3 per shard → Gain 2 Shard, +3/+1 per shard
         *Added Trigger descriptions to Synthesis data of units as needed
         *
         *May 21, 2024
         *Removed Recombinant Virus from mastery collection
         *Removed upgraded versions of Evolving Resistance from the mastery collection and the from logbook (similar to Blazing Bolts upgrades are not in the logbook)
         *Linked mastery of an upgraded Evolving Resistance to the base Evolving Resistance
         *Deleted unneeded cases without borking the mod
         *
         *May 22, 2024
         *Created StatusEffectReplicateStackable so Prolonged Life and Multistranded RNA can be Doublestacked
         *Hopefully set Recombinant Virus to become visible when you see the Virion starter card
         *Possibly fixed Contagion combat math giving red X on random floors when combat math is recalculated
         *
         *May 27, 2024
         *CardEffectSheddingSpawn now gives tooltip info for Recombinant Virus
         *CardEffectRecruitsShedding still does not give tooltip info and applying the same code to above causes it to crash?
         *
         *May 29, 2024
         *Frozen in Ice II and III now stay as a 1-pip unit
         *Gave ParamCharacterData to Patient Zero II and III so it doesn't crash as often
         *Added tooltip key to Survival of the Prolific
         */
    }
}
