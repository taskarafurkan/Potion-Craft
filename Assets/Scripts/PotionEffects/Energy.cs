using PotionCraft.PotionScripts;

public class Energy : PotionEffect
{
    #region Fields
    private int _energyAmount = 15;
    #endregion

    #region Properties
    public int EnergyAmount { get => _energyAmount; set => _energyAmount = value; }
    #endregion

    #region Methods
    public override void ApplyEffect()
    {
        EffectTime = 0;
        UnityEngine.Debug.Log(EnergyAmount + " " + EffectTime);
    }
    #endregion
}
