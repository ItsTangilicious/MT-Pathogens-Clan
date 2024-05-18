using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Trainworks.Managers;
using static StatusEffectState;




namespace CustomEffectsPathogens
{
    public class StatusEffectReplicate : StatusEffectState
    {
        public static StatusEffectData data;
        public const string statusID = "status_replicate";
        //public static List<CardState> cardsTriggeredOn = new List<CardState>() { };

        public static void Build()
        {
            data = new StatusEffectDataBuilder()
            {
                StatusEffectStateType = typeof(StatusEffectReplicate),
                StatusID = statusID,
                IsStackable = true,
                IconPath = "AssetsAll/ClanAssets/ReplicateLarge.png",
                TooltipIconPath = "AssetsAll/ClanAssets/ReplicateSmall.png",
                TriggerStage = StatusEffectData.TriggerStage.None,
                DisplayCategory = StatusEffectData.DisplayCategory.Positive,
                ShowStackCount = false,
                RemoveAtEndOfTurn = false,
                RemoveWhenTriggered = true,
               
                //Description = "Gains Endless. Loses Replicate when this unit dies.",
                ParamInt = 1,


            }.Build();
            List<StatusEffectData.TriggerStage> triggerStages = new List<StatusEffectData.TriggerStage>
            {
                StatusEffectData.TriggerStage.OnPostEaten
            };
            AccessTools.Field(typeof(StatusEffectData), "additionalTriggerStages").SetValue(data, triggerStages);

        }

        //This is applying in Preview Mode...test if ProviderManager fixes issue?
        public override void OnStacksAdded(CharacterState character, int numStacksAdded)
        {

            if (numStacksAdded > 0 && !ProviderManager.SaveManager.PreviewMode)
            {
                character.AddStatusEffect(VanillaStatusEffectIDs.Endless, 1);
            }
            
        }             

    }
}


