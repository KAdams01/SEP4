using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunModelManager : MonoBehaviour
{
    public static GunModelManager Instance = null;
    public GameObject PrintedModel;
    public GameObject LaserPointer;
    public GameObject SniperRifle;
    /*private MeshRenderer[] PrintedChildren;
    private MeshRenderer[] SniperChildren;*/
    public enum currentlySelected
    {
        Printed, Sniper
    };

    public static currentlySelected currentWeapon { get; private set; }
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
    }
    // Start is called before the first frame update
    void Start()
    {
        /*PrintedChildren = PrintedModel.GetComponentsInChildren<MeshRenderer>();
        SniperChildren = SniperRifle.GetComponentsInChildren<MeshRenderer>();
        Debug.Log("PrintedChildren length: " + PrintedChildren.Length);
        Debug.Log("SniperChildren length: " + SniperChildren.Length);*/
        /*Color c1 = new Color(1,1,1,1);
        foreach (var mesh in PrintedChildren)
        {
            
            mesh.material.color = c1;
        }*/
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "PracticeMode" || SceneManager.GetActiveScene().name == "TargetRange")
        {
            ShowSniperRifle();
        }
        else
        {
            ShowPrintedModel();
        }
        

    }

    public void ShowPrintedModel()
    {
        if (currentWeapon != currentlySelected.Printed)
        {
            PrintedModel.SetActive(true);
            LaserPointer.SetActive(true);
            Debug.Log("Show Printed Called");
            /*StartCoroutine(FadeToModel(PrintedChildren));
            StartCoroutine(FadeFromModel(SniperChildren));*/
            currentWeapon = currentlySelected.Printed;
        }
        SniperRifle.SetActive(false);

    }

    public void SwitchModels()
    {
        if(currentWeapon == currentlySelected.Printed)
        {
            ShowSniperRifle();
        }
        else
        {
            ShowPrintedModel();
        }
    }

    public void ShowSniperRifle()
    {
        if (currentWeapon != currentlySelected.Sniper)
        {
            SniperRifle.SetActive(true);
            Debug.Log("Show Sniper Called");
            /*StartCoroutine(FadeToModel(SniperChildren));
            StartCoroutine(FadeFromModel(PrintedChildren));*/
            currentWeapon = currentlySelected.Sniper;
        }
        LaserPointer.SetActive(false);
        PrintedModel.SetActive(false);

    }

    /*IEnumerator FadeToModel(MeshRenderer[] rendArray)
    {
        foreach (var rend in rendArray)
        {
            foreach (var material in rend.materials)
            {
                for (float f = 0.05f; f <= 1; f += 0.05f)
                {
                    Color c = material.color;
                    c.a = f;
                    material.color = c;
                    yield return new WaitForSeconds(0.05f);
                }
            }

        }
    }

    IEnumerator FadeFromModel(MeshRenderer[] rendArray)
    {
        foreach (var rend in rendArray)
        {
            foreach (var material in rend.materials)
            {
                for (float f = 1f; f <= -0.05f; f -= 0.05f)
                {
                    Color c = material.color;
                    c.a = f;
                    material.color = c;
                    yield return new WaitForSeconds(0.05f);
                }
            }

        }

    }*/
}
