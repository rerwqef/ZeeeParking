
using UnityEngine;
[CreateAssetMenu(fileName ="create",menuName ="carAssets")]
public class CarScriptable : ScriptableObject
{

    [Header("Car Engine")]
    public int price;
    public float accilartionForce = 300f;
    public float breackForce = 3000f;
    public AudioClip breackSound;
   public  AudioClip EngineSound;

    [Header("Car Steering")]
    public float maxsteeiAgangle = 35f;
    [Header("moving Sound")]
    public AudioClip[] movinfgSound;


}

