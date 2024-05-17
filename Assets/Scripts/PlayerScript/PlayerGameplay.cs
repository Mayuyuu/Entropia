using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class PlayerGameplay : MonoBehaviour
{
    //--------------------------------------------------------- ShockWave Variables
    private bool SWactivable = true;
    [SerializeField] private float RangeSW = 10f;
    [SerializeField] Sprite RevealSprite;

    [SerializeField] Material RevealMat;
     ParticleSystem ShockWavePS;
    [SerializeField] private float DurationMaxPS;
    [SerializeField] private float DurationMinPS = 0f;
    private float AlphaLerpDelay;
    private float InteractionDelay;
    //--------------------------------------------------------------------------------


    //--------------------------------------------------------------------- Glitch Bar
    [SerializeField] private GlitchBar maBar;
    [SerializeField] private float incGlitch;
    //----------------------------------------------------------------------Screen Shake

    // public float speed;
    // public GameObject effect;
    // private Shake shake;

    [SerializeField] GameObject MainCamera;


    void Start()
    {
        MainCamera=Camera.main.gameObject;
        ShockWavePS = gameObject.GetComponentInChildren<ParticleSystem>();      //On récupère le particle System enfant du player et on l'assigne à ShockWavePS
        DurationMaxPS = ShockWavePS.startLifetime;      //On récupère le lifetime du PS et on l'assigne à DurationMaxPS et je sais que c'est obsolète mais ça fonctionne !!

        //----------------------------------------------------------------------Screen Shake
        //shake= GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("ShockWave") && SWactivable == true)        //Si Player appuie P et SWactivable true : start coroutine de cooldown
        {
            StartCoroutine(SWcooldown());


            //transform.Translate(Vector2.right *speed* Time.deltaTime);

        }


        //Debug pour tester l'augmentation du glitch. A mettre ailleur BWAAAA !!
        // if(Input.GetKeyDown(KeyCode.O)) 
        // {
        //     //Augmenter le glitch
        //     maBar.GlitchPower = maBar.GlitchPower + incGlitch;
        // }


    }


    IEnumerator SWcooldown()
    {
        ShockWavePS.Play();     //Lancement du PS
        SWactivable = false;        //On empêche de Spam R


        Collider2D[] SWzone = Physics2D.OverlapCircleAll(transform.position, RangeSW);      // le overlap cr�� un circle Collider2D �ph�m�re, ils ajoute tous les collider d�tect�s dans la liste SWzone


        //Pour chaque Collider de la liste SWzone on active la Coroutine SWdetection
        foreach (Collider2D coll in SWzone)
        {

            StartCoroutine(SWDetection(coll));
        }

        //Après 2sec d'attentes on réactive la possibilite de lancer la ShockWave
        yield return new WaitForSeconds(2);

        SWactivable = true;



    }



    IEnumerator SWDetection(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("RevealPlateform"))      //Si le go contenant le coll a le tag "Reveal" : on recupere son sprite renderer et on le change
        {

            AlphaLerpDelay = ((gameObject.transform.position - coll.gameObject.transform.position).magnitude) / RangeSW;        //On calcul la distance entre le joueur et la plateforme ce qui determine l'Alpha du Lerp Ci-Dessous
            InteractionDelay = Mathf.Lerp(DurationMinPS, DurationMaxPS, AlphaLerpDelay);        //On determine le temps que mets la SW à atteindre la plateforme grace à l'Alpha Lerp et donc la distance player -> Plateforme
            yield return new WaitForSeconds(InteractionDelay);      //On attend et on lance l'effet voulu
            //coll.gameObject.GetComponent<SpriteRenderer>().sprite = RevealSprite; //Changer le sprite des plateformes par celui voulu (à définir directement dans l'inspecteur du player)
            coll.gameObject.GetComponent<SpriteRenderer>().material = RevealMat;                                                                      //changer le material coll.gameObject.GetComponent<SpriteRenderer>().material
            coll.GetComponent<Collider2D>().isTrigger = false;
        }

        else if (coll.gameObject.CompareTag("DestructPlateform"))       //Si le go contenant le coll a le tag "Destruct" : on le detruit
        {

            AlphaLerpDelay = ((gameObject.transform.position - coll.gameObject.transform.position).magnitude) / RangeSW;
            InteractionDelay = Mathf.Lerp(DurationMinPS, DurationMaxPS, AlphaLerpDelay);
            //MainCamera.GetComponent<Shake>().Update();
            yield return new WaitForSeconds(InteractionDelay);
            Destroy(coll.gameObject);
            MainCamera.GetComponent<Shake>().StartShaking();
        }

//----------------------------------------------------------------------Screen Shake

    //     void OnTriggerEnter2D(Collider2D other)
    // {
    //      shake.CamShake();
    //      Destroy(other.gameObject);
    //      Instantiate(effect,transform.position, Quaternion.identity);
    //      Destroy(gameObject);
    //  }
}
    }



    /*void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, 255, 0, 70);
        Gizmos.DrawSphere(transform.position, RangeSW);
    }*/



