using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;
using static TargetHelper;

namespace CustomEffectsPathogens
{
    //June 6, 2024 currently won't let the unit spawn and softlocks the game
    internal class CustomRoomStateAttackForContagion : RoomStateModifierBase, IRoomStateDamageModifier, IRoomStateModifier, ILocalizationParamInt, ILocalizationParameterContext
    {
        private int contagionPerDamagePoint;
        protected SaveManager saveManager;
        private List<CharacterState> charsInTargetRoom = new List<CharacterState>();
        public int currentContagion;
        

        public override void Initialize(RoomModifierData roomModifierData, RoomManager roomManager)
        {
            base.Initialize(roomModifierData, roomManager);
            contagionPerDamagePoint = roomModifierData.GetParamInt();
        }

        public int GetModifiedDamage(Damage.Type damageType, CharacterState attackerState, bool requestingForCharacterStats)
        {
            if (requestingForCharacterStats)
            {
                return GetDynamicInt(attackerState);
            }
            return 0;
        }

        public override int GetDynamicInt(CharacterState characterContext)
        {
            
            if (ProviderManager.SaveManager == null)
            {
                return 0;
            }
            if (characterContext.GetRoomStateModifiers().Contains(this) && characterContext.GetSpawnPoint() != null)
            {
                RoomState roomOwner = characterContext.GetSpawnPoint().GetRoomOwner();
                if (roomOwner != null)
                {
                    //charsInTargetRoom.Clear();
                    roomOwner.AddCharactersToList(charsInTargetRoom, Team.Type.Heroes | Team.Type.Monsters);
                    //int num = 0;
                    
                    {
                        foreach (CharacterState item in charsInTargetRoom)
                        {
                            int currentContagionStacks = item.GetStatusEffectStacks(StatusEffectContagion.statusID);
                            //num += currentContagionStacks;
                            return currentContagionStacks * contagionPerDamagePoint;
                        }
                    }
                }
            }
                
            
            return 0;
        }
    }
}
