using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using MonsterCardPathogens;


namespace CustomEffectsPathogens 
{
    internal class StatusEffectSheddingDummyStacks : StatusEffectState
    {
        public static StatusEffectData data;
        public const string statusId = "status_SheddingDummy";
        public override bool TestTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            return false;
        }
        protected override IEnumerator OnTriggered(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            yield break;
        }
        public override int GetEffectMagnitude(int stacks = 1)
        {
            return 0;
        }
        public static void Build()
        {
            data = new StatusEffectDataBuilder
            {
                StatusEffectStateType = typeof(StatusEffectSheddingDummyStacks),
                StatusID = statusId,
                Name = "Shedding",
                Description = "On trigger, gain 1 stack of Shedding. <b>Sheding X:</b> Remove X shedding stacks and trigger its Shedding ability.",
                DisplayCategory = StatusEffectData.DisplayCategory.Positive,
                TriggerStage = StatusEffectData.TriggerStage.None,
                ShowStackCount = true,
                RemoveAtEndOfTurn = false,
                RemoveWhenTriggered = false,
                IconPath = "assets/status_weakness.png",


            }.Build();
        }
    }
}
