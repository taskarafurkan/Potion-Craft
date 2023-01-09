using PotionCraft.PotionScripts;

public class Mana : PotionEffect
{
    #region Fields
    private int _manaAmount = 30;
    #endregion

    #region Properties
    public int ManaAmount { get => _manaAmount; set => _manaAmount = value; }
    #endregion

    #region Methods
    public override void ApplyEffect()
    {
        EffectTime = 0;
        UnityEngine.Debug.Log(ManaAmount + " " + EffectTime);
    }
    #endregion
}
