using PotionCraft.PotionScripts;

public class Heal : PotionEffect
{
    #region Fields
    private int _healAmount = 5;
    #endregion

    #region Properties
    public int HealAmount { get => _healAmount; set => _healAmount = value; }
    #endregion

    #region Methods

    public override void ApplyEffect()
    {
        EffectTime = 0;
        UnityEngine.Debug.Log(HealAmount + " " + EffectTime);
    }

    #endregion
}
