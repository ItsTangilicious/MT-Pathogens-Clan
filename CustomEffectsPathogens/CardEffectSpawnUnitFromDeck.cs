using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;
using Trainworks.ConstantsV2;
using MonsterCardPathogens;


namespace CustomEffectsPathogens
    //Apr 22, 2024: currently spawns a cardless copy of unit from deck to the back of the room. Does not hit the discard pile.
{
    internal class CardEffectSpawnUnitFromDeck : CardEffectBase
    {
        private CardManager cardManager;

        private List<CardState> toProcessCards = new List<CardState>();

        private int roomIndex;

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

        /*public bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            roomIndex = _srcRelicEffectData.GetParamInt();
            if (roomIndex < 0 || roomIndex >= relicEffectParams.roomManager.GetNumRooms())
            {
                Log.Error(LogGroups.Gameplay, "Invalid room index for spawning units - " + _srcRelicData.GetName());
                return false;
            }
           cardManager = cardEffectParams.cardManager;
            toProcessCards.Clear();
            foreach (CardState item in cardManager.GetDrawPile())
            {
                if (item.IsSpawnerCard() && !item.IsChampionCard())
                {
                    toProcessCards.Add(item);
                    
                }
            }

            if (toProcessCards.Count <= 0)
            {
                //Log.Warning(LogGroups.Gameplay, "Could not find a unit card to spawn for blessing - " + _srcRelicData.GetName());
                return false;
            }
            return true;
            
            /*{
                RoomState selectedRoom = cardEffectParams.GetSelectedRoom();
                return !selectedRoom.GetIsPyreRoom() && selectedRoom.GetFirstEmptyMonsterPoint() != null;
            }
        }*/
        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            RoomState selectedRoom = cardEffectParams.GetSelectedRoom();
            return !selectedRoom.GetIsPyreRoom() && selectedRoom.GetFirstEmptyMonsterPoint() != null;
        }

    

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            RoomState roomState = cardEffectParams.GetSelectedRoom();
            RelicManager relicManager = cardEffectParams.relicManager;

           //yield return cardEffectParams.roomManager.GetRoomUI().SetSelectedRoom(roomIndex);
            toProcessCards.Clear();
            toProcessCards.AddRange(cardEffectParams.cardManager.GetDrawPile());
            toProcessCards.AddRange(cardEffectParams.cardManager.GetDiscardPile());
            /*int num = 0;
            int intInRange = cardEffectState.GetIntInRange();
            for (int i = 0; i < toProcessCards.Count; i++)
            {
                if (num >= intInRange)
                {
                    break;
                }*/
                //toProcessCards.Shuffle(RngId.CardDraw);
                CardState cardState = toProcessCards[0];
                CharacterState characterState = null;
                if (cardState != cardEffectParams.playedCard && cardState.GetCardType() == cardEffectState.GetTargetCardType())
                {
                    yield return cardEffectParams.monsterManager.CreateMonsterState(cardState.GetSpawnCharacterData(), cardState, cardEffectParams.selectedRoom, delegate (CharacterState spawnedCharacter)
                    {
                        characterState = spawnedCharacter;
                    }, SpawnMode.FrontSlot, roomState.GetMonsterPoint(0), null, false, null, null, false);

                    relicManager.CharacterAdded(characterState, cardEffectState.GetParentCardState());

                    if (!cardEffectParams.saveManager.PreviewMode)
                    {
                        yield return cardEffectParams.roomManager.GetRoomUI().CenterCharacters(roomState, true, false, true);
                    }

                    if (!(characterState == null))
                    {
                        if (cardState.HasTrait(typeof(CardTraitCorruptState)))
                        {
                            RoomState room = cardEffectParams.roomManager.GetRoom(roomIndex);
                            int numCorruptionAddedPerTraitCorrupt = cardEffectParams.saveManager.GetNumCorruptionAddedPerTraitCorrupt();
                            int setCorruption = room.GetCurrentCorruption() + numCorruptionAddedPerTraitCorrupt;
                            yield return room.AdjustCorruption(cardEffectParams.combatManager, cardEffectParams.relicManager, setCorruption, room.GetMaxCorruption());
                        }
                        //characterState.ShowNotification(string.Empty, PopupNotificationUI.Source.General, _srcRelicState);
                        /*yield return cardManager.DiscardCard(new CardManager.DiscardCardParams
                        {
                            discardCard = cardState,
                            wasPlayed = true,
                            characterSummoned = characterState
                        });*/
                    }
                    //cardManager.SetCardIsDrawable(cardState, drawable: false);



                    //cardManager.SetCardIsDrawable(cardState, drawable: true);
                }

            }
        }
        
    }


