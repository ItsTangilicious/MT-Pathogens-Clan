using MonsterCardPathogens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;

namespace CustomEffectsPathogens
    //deleted from the actual mod as it was unused
{
    internal class CardEffectRecruitAllSheddings : CardEffectBase
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
    private Team.Type targetTeam;
    private List<CharacterData> paramCharacters;
    private CardPool paramCardPool;


        /*public override void Initialize(CardState cardState, CardData cardData, CardEffectData cardEffectData)
        {
            base.Initialize(cardState, cardData, cardEffectData);
            this.targetTeam = cardEffectData.GetTargetTeamType();
            this.cardCharacters = cardEffectData.GetParamCharacterData();
            this.paramCardPool = cardEffectData.GetParamCardPool();
        }*/
    
    public bool TestEffect(CardEffectParams cardEffectParams)
        {
            for (int ii = 0; ii < cardEffectParams.roomManager.GetNumRooms(); ii++)
            {
                if (this.targetTeam == Team.Type.Monsters && cardEffectParams.roomManager.GetRoom(ii).GetIsPyreRoom())
                {
                    continue;
                }
                if (cardEffectParams.roomManager.GetRoom(ii).IsRoomEnabled())
                {
                    continue;
                }
                if (this.targetTeam == Team.Type.Monsters && cardEffectParams.roomManager.GetRoom(ii).GetFirstEmptyMonsterPoint() != null)
                {
                    return true;
                }
                if (this.targetTeam == Team.Type.Heroes && cardEffectParams.roomManager.GetRoom(ii).GetFirstEmptyHeroPoint() != null)
                {
                    return true;
                }
            }

            return false;
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
            yield return cardEffectParams.roomManager.GetRoomUI().CenterCharacters(roomState, true, false, true);
        }

        yield break;
    }

    /*public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
    {
        RoomState selectedRoom = cardEffectParams.GetSelectedRoom();
        return !selectedRoom.GetIsPyreRoom() && selectedRoom.GetFirstEmptyMonsterPoint() != null;
    }*/
    }

}
  
