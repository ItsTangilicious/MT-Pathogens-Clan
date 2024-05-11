using CustomEffectsPathogens;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;

namespace Test_Bounce.CustomEffectsPathogens
{
    internal class StatusEffectMarkedForSacrificeDummyStacks : StatusEffectState
    {
        public static StatusEffectData data;
        public const string statusId = "status_SacrificeDummy";

        public static void Build()
        {
            data = new StatusEffectDataBuilder
            {
                StatusEffectStateType = typeof(StatusEffectMarkedForSacrificeDummyStacks),
                StatusID = statusId,
                Name = "Shedding",
                //Description = "A unit marked with this debuff will be eaten by the Macrophage.",
                DisplayCategory = StatusEffectData.DisplayCategory.Persistent,
                TriggerStage = StatusEffectData.TriggerStage.None,
                ShowStackCount = false,
                RemoveAtEndOfTurn = false,
                RemoveWhenTriggered = false,
                IconPath = "assets/status_weakness.png",


            }.Build();
        }
    }
}
