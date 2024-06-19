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
         *
         *June 3, 2024
         *CardEffectRecruitsShedding should now work in preview mode
         *Carrier - Immunologist now only buffs unit attack
         *Carrier - Patient Zero changed from a Revenge trigger to a Resolve trigger
         *Simplexvirus changed from a Revenge trigger to a Resolve trigger and will always summon once per round
         *Swarm Tactics chagned from 2 ember → 3 ember, is single target, and only buffs attack. This brings it more in line with Ritual of Battle
         *Booster Shot now gives +4 health instead of +4 attack
         *Recombinant Virus now only applies Contagion to the front enemy unit
         *Vibrio Infernum now requires 4 shards to gain multistrike
         *Clarified descriptions of Grant Reapplication and Evolving Resistance
         *Spelleogenisis reduced from 5 ember → 4 ember
         *Prolonged Life now has Consume, decided better of it, then removed Consume from it
         *Viral Outcropping now summons 2 Recombinant Virus instead of 3
         *Hyperlasic Spike reduced from +2/+2 per summoned unit to +1/+1 per summoned unit
         *Herzal's Anvil now excludes Champion units
         *Carrier Bioengineer II and III stat gain to hand reduced to +15/+5
         *Divinity Sequence changed from "All friendly units gain Multistrike 1. At the end of each combat, gain 10 Pact Shards." to "Your Champion can be upgraded, but all units have one fewer upgrade slots."
         *Mitotic Division changed from "Rally and Culture abilities trigger an additional time." to "When you summon your first unit each turn, and a Virion spell to your hand."
         *
         *June 6, 2024
         *Supervirus - Hemorrhagic no longer gains health on trigger, but initial health has been increased to to 10/20/30
         *Supervirus - Hemorrhagic does not gain Trample until level III
         *Hurried Exit cost increased 1-ember → 2-ember
         *Multistrand DNA cost increased 3-ember → 4-ember and Melee Weakness 2 → Melee Weakness 4
         *Mitotic Division now gives Purge to the gained Virion
         *
         *June 9, 2024
         *Bacterial Growth 2-ember → 1-ember
         *Swarm Tactics 3-ember → 2-ember
         *Experimental Cloning Device 3-ember → 2-ember
         *Carrier - Immunologist health changed from 15/15/20 → 20/25/30
         *Supervirus - Hemorrhagic health changed from 10/20/30 → 15/30/45
         *
         *Jun 12, 2024
         *Attempted fix for Aerosolizer
         *Recombinant Virus now targets back of room instead of front of room.
         *
         *June 15, 2024
         *These are non-implemented ideas
         *Flea → 4 to lowest health unit and then 4 to strongest unit.
         *Network → only triggers off of non-morsels
         *Spelleo → give permafrost?
         *Using CardTraitDataBuilder {ParamTrackedValue = CardStatistics.TrackedValueType.StatusEffectCountInTargetRoom} to set the damage attack of a unit?
         *Above for Roaming Macrophage - Quick. Action: -10 attack then gain attack equal to Contagion on the floor. (Infusion = quick). 0/10.
         *Make the above a Harvest trigger but only for units with Contagion?
         *
         *June 16, 2024
         *Antigen Mimic's ability reduced from "Culture: Restore 5 health to all friendly units and apply Regen 2." → "Culture: Restore 5 health to all friendly units and apply Regen 1."
         *Antigen Mimic attack reduced from 20 → 10
         *Spliced Monstrosity health incrased 10 → 20
         *(failed)Attempted change to Mycorrhizial Network so Morsels do not trigger it off floor       
         *
         *June 17, 2024
         *Changed Roaming Macrohpage ability from "Quick. Slay: +3 attack and health." → "Has Attack equal to the amount of Contagion on this floor."
         *Roaming Macrophage infusion changed from "Quick and Slay: +2 attack" → "Has Attack equal to the amount of Contagion on this floor."
         *Virodaemonologist health reduced 25 → 15
         *Virodaemonologist ability reduced "Gain +5 attack and Armor 5." → "Gain +4 attack and Armor 3."
         *Borrelia Daemonium cost reduced 2-ember → 1-ember and attack/health reduced 20/20 → 10/15
         *Fixed Aerosilizer bug trying where it tried to kill a unit that was already dead and softlocking the game
         */
    }
}
