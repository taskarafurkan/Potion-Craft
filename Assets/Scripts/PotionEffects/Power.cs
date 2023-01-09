using PotionCraft.PotionScripts;

public class Power : PotionEffect
{
    #region Fields
    private float _powerAmount = 20;
    private float _powerTimeOut = 35;
    #endregion

    #region Properties
    public float PowerAmount { get => _powerAmount; set => _powerAmount = value; }
    public float PowerTimeOut { get => _powerTimeOut; set => _powerTimeOut = value; }
    #endregion

    #region Methods
    public override void ApplyEffect()
    {
        EffectTime = 0;
        UnityEngine.Debug.Log(PowerAmount + " " + PowerTimeOut + " " + EffectTime);
    }
    #endregion
}
