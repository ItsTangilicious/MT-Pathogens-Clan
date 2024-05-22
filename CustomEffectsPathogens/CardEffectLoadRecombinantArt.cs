using MonsterCardPathogens;
using ShinyShoe.Loading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;

namespace CustomEffectsPathogens
    //deleted from the actual mod as it was unused
    //taken from Three Fishies AddThreeBackbroundPoniesArtFix in the Equestrian Mod
{
    internal class CardEffectLoadRecombinantArt : CardEffectBase
    {
        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            SaveManager saveManager = cardEffectState.SaveManager;
            CardState card = new CardState();
            LoadingScreen.AddTask(new LoadAdditionalCards(CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID), loadSpawnedCharacters: true, LoadingScreen.DisplayStyle.Background, delegate
            {
                card = saveManager.AddCardToDeck(CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID), null, applyExistingRelicModifiers: true, applyExtraCopiesMutator: false, showAnimation: false, setupStartingUpgrades: true, notifyDeckCount: false);
                saveManager.RemoveCardFromDeck(card);
            }));
            yield break;
        }
    }
    
}

