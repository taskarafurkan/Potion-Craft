using PotionCraft.PotionScripts;

public class Fire : PotionEffect
{

    #region Fields
    private float _fireIntervalTime = 3;
    private int _fireDamage = 30;
    #endregion

    #region Properties
    public float FireIntervalTime { get => _fireIntervalTime; set => _fireIntervalTime = value; }
    public int FireDamage { get => _fireDamage; set => _fireDamage = value; }
    #endregion

    #region Methods
    public override void ApplyEffect()
    {
        EffectTime = 3;
        UnityEngine.Debug.Log(FireIntervalTime + " " + FireDamage + " " + EffectTime);
    }
    #endregion

}
