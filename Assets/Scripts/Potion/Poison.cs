using System;

[Serializable]
public class Poison : PotionEffect
{
    #region Fields
    private float _poisonIntervalTime;
    private int _poisonDamage;
    #endregion

    #region Properties
    public float PoisonIntervalTime { get => _poisonIntervalTime; set => _poisonIntervalTime = value; }
    public int PoisonDamage { get => _poisonDamage; set => _poisonDamage = value; }
    #endregion

    #region Methods
    public override void ApplyEffect()
    {
        EffectTime = 8;
        UnityEngine.Debug.Log(PoisonIntervalTime + " " + PoisonDamage + " " + EffectTime);
    }

    #endregion
}