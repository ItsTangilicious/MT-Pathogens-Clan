using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CustomEffectsPathogens
{
    internal class CustomCardEffectHealToFull : CardEffectBase
    {
        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            return cardEffectParams.targets.Count > 0;
        }

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            foreach (CharacterState target in cardEffectParams.targets)
            {
                
               
                
                int maxHP = target.GetMaxHP();
                int currentHP = target.GetHP();
                CardUpgradeState upgradeState = new CardUpgradeState();
                upgradeState.Setup();
               
                
                yield return target.ApplyHeal(maxHP);
                CardState spawnerCard = target.GetSpawnerCard();
                bool flag = false;
                if (spawnerCard != null && (target.GetSourceCharacterData() == spawnerCard.GetSpawnCharacterData() || spawnerCard.GetSpawnCharacterData() == null))
                {
                    flag = true;
                }
                if (spawnerCard != null && !cardEffectParams.saveManager.PreviewMode && flag)
                {
                    CardAnimator.CardUpgradeAnimationInfo type = new CardAnimator.CardUpgradeAnimationInfo(spawnerCard, upgradeState);
                    CardAnimator.DoAddRecentCardUpgrade.Dispatch(type);
                    spawnerCard.GetTemporaryCardStateModifiers().AddUpgrade(upgradeState);
                }
            }
        }
    }
}

