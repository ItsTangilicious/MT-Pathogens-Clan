using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;
using Trainworks.ConstantsV2;
using MonsterCardPathogens;
using ShinyShoe.Loading;


namespace CustomEffectsPathogens 
{
    class CardEffectRecruitsShedding : CardEffectBase
    //From 3a Pony
    {
        public override bool CanApplyInPreviewMode
        {
            get
            {
                return false;
            }
        }
        public override bool CanPlayInEngineRoom
        {
            get
            {
                return false;
            }
        }

        
        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {


            RoomState roomState = cardEffectParams.GetSelectedRoom();
            RelicManager relicManager = cardEffectParams.relicManager;
            CharacterData monsterData = CustomCharacterManager.GetCharacterDataByID(RecombinantVirusMonster.CharID);
           

            CharacterState newMonster = null;

            yield return cardEffectParams.monsterManager.CreateMonsterState(monsterData, null, cardEffectParams.selectedRoom, delegate (CharacterState character)
            {
                newMonster = character;

            }, SpawnMode.SelectedSlot, roomState.GetMonsterPoint(0), null, false, null, null, true);

            relicManager.CharacterAdded(newMonster, cardEffectState.GetParentCardState());

            if (!cardEffectParams.saveManager.PreviewMode)
            {
                yield return cardEffectParams.roomManager.GetRoomUI().CenterCharacters(roomState, false, false, false);
            }

            yield break;
        }

        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            RoomState selectedRoom = cardEffectParams.GetSelectedRoom();
            return !selectedRoom.GetIsPyreRoom() && selectedRoom.GetFirstEmptyMonsterPoint() != null;
        }
    }

}






