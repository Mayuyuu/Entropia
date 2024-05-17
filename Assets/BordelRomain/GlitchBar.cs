using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlitchBar : MonoBehaviour
{

    public float GlitchPower;
    public float GlitchMax;
    public Image GlitchImage;

    public Material glitchMaterial;


    // ------------------------------------Glitch Bar

    [SerializeField] private GlitchBar maBar;
    [SerializeField] private float incGlitch;

    public GameObject Parent;  //le parent qui contient tout les trucs � d�truire
    public int ChildMax;  //le nombre de trucs � d�truire avant de mourir
    private int ChildBase;  //le nombre d'enfants de base
    private int ChildActuel;  //le nombre d'enfants update h24
    private float ratio;

    private int ChildManquants;


    // ------------------------------------UI GameOver

    public GameObject GameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        ChildBase = Parent.transform.childCount;
       
    }

    // Update is called once per frame
    void Update()
    {
        GlitchImageSetFillAmount();
        GlitchAberationChromatiqueParameterAugmentationCFaitUnPeuLong();
        GlitchBarAffichage();



        //Debug pour tester l'augmentation du glitch. (oui romain)A mettre ailleur BWAAAA !!
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     //Augmenter le glitch
        //     maBar.GlitchPower += maBar.GlitchPower + incGlitch;
        // }

        //A mettre dans un autre script (un gamemanager par exemple). BWAAAA (oui romain x2)!!
        if (GlitchPower >= 1)
        {
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);

        }

     
    }

    public void Restart()
    {
        SceneManager.LoadScene("Platformer");
    }

    public void GlitchImageSetFillAmount()
    {
        GlitchImage.fillAmount = /*1 - */(GlitchPower / GlitchMax); //permet de varier entre 0 et 1
    }

    public void GlitchAberationChromatiqueParameterAugmentationCFaitUnPeuLong()
    {
        glitchMaterial.SetFloat("_ParamGlitch", GlitchPower);
    }


    private void OnApplicationQuit()
    {
        glitchMaterial.SetFloat("_ParamGlitch", 0);
    }

    private void GlitchBarAffichage()
    {
        ratio = 1f / ChildMax;
        ChildActuel = Parent.transform.childCount;
        ChildManquants = ChildBase - ChildActuel;
        GlitchPower = ratio * ChildManquants;  //Glitch c'est la variable qui va de 0 � 1 qui g�re le glitch
        /*if (ChildManquants >= ChildMax)
        {
            //Le joueur meurt
        }*/
    }


}
//+ elt cass� -> augmenter barre glitch + fixer le max possible pour la barre
// quand barre glitch atteint son max
//kill player + changement de sc�ne
