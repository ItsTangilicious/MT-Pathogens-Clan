﻿using ShinyShoe.Loading;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;


namespace Patches
{
    public static class FixArt
    {
        public static int cardsToLoad;

        public static void TryYetAnotherFix(CardPool cardPool, LoadingScreen.DisplayStyle displayStyle = LoadingScreen.DisplayStyle.FullScreen)
        {

            TryYetAnotherFix(cardPool.GetAllChoices(), displayStyle);
        }

        public static void TryYetAnotherFix(List<CharacterData> characters, LoadingScreen.DisplayStyle displayStyle = LoadingScreen.DisplayStyle.FullScreen, Action doneCallbak = null)
        {
            LoadingScreen.AddTask(new LoadAdditionalCharacters(characters, displayStyle, doneCallbak));
        }

        public static void TryYetAnotherFix(List<CardData> cards, LoadingScreen.DisplayStyle displayStyle = LoadingScreen.DisplayStyle.FullScreen, Action doneCallbak = null)
        {
            SaveManager saveManager = ProviderManager.SaveManager;
            CardState card = new CardState();

            cardsToLoad += cards.Count;
            foreach (CardData virus in cards)
            {
                LoadingScreen.AddTask(new LoadAdditionalCards(CustomCardManager.GetCardDataByID(virus.GetID()), loadSpawnedCharacters: true, displayStyle, delegate
                {
                    cardsToLoad--;
                }));
            }
        }
        
    }
}
