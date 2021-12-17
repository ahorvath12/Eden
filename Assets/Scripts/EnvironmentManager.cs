using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private GameObject[] rats, dogs, cats, humans, chickens, lilyPads, husbandry, ducks;
    private int[] neededValues = new int[] { 20, 100, 150, 200, 300, 400, 700, 1000 };
    private int environmentIndex = 0, oldIndex;

    int ratsVal = 20, dogsVal = 100, catsVal = 150, humansVal = 200, chickensVal = 300, lilyPadsVal = 400, husbandryVal = 700, ducksVal = 1000;

    // Start is called before the first frame update
    void Start()
    {
        oldIndex = environmentIndex;

        rats = GameObject.FindGameObjectsWithTag("Rat");
        dogs = GameObject.FindGameObjectsWithTag("Dog");
        cats = GameObject.FindGameObjectsWithTag("Cat");
        humans = GameObject.FindGameObjectsWithTag("Human");
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
        lilyPads = GameObject.FindGameObjectsWithTag("LilyPad");
        husbandry = GameObject.FindGameObjectsWithTag("Husbandry");
        ducks = GameObject.FindGameObjectsWithTag("Duck");

        DeactiateStuff(rats);
        DeactiateStuff(dogs);
        DeactiateStuff(cats);
        DeactiateStuff(humans);
        DeactiateStuff(chickens);
        DeactiateStuff(lilyPads);
        DeactiateStuff(husbandry);
        DeactiateStuff(ducks);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(environmentIndex);

        // if (oldIndex != environmentIndex)
        // {
        //     bool add = false;
        //     if (oldIndex < environmentIndex)//growth
        //         add = true;

        //     int randInd;
        //     if (environmentIndex >= ratsVal && environmentIndex < lilyPadsVal)
        //     {
        //         randInd = Random.Range(0, rats.Length);
        //         rats[randInd].SetActive(add);
        //     }
        //     else if (environmentIndex < ratsVal)
        //     {
        //         randInd = Random.Range(0, rats.Length);
        //         rats[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= dogsVal && environmentIndex < ducksVal)
        //     {
        //         randInd = Random.Range(0, dogs.Length);
        //         dogs[randInd].SetActive(add);
        //     }
        //     else if (environmentIndex < dogsVal)
        //     {
        //         randInd = Random.Range(0, dogs.Length);
        //         dogs[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= catsVal)
        //     {
        //         randInd = Random.Range(0, cats.Length);
        //         cats[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, cats.Length);
        //         cats[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= humansVal)
        //     {
        //         randInd = Random.Range(0, humans.Length);
        //         humans[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, humans.Length);
        //         humans[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= chickensVal)
        //     {
        //         randInd = Random.Range(0, chickens.Length);
        //         chickens[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, chickens.Length);
        //         chickens[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= lilyPadsVal)
        //     {
        //         randInd = Random.Range(0, lilyPads.Length);
        //         lilyPads[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, lilyPads.Length);
        //         lilyPads[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= husbandryVal)
        //     {
        //         randInd = Random.Range(0, husbandry.Length);
        //         husbandry[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, husbandry.Length);
        //         husbandry[randInd].SetActive(add);
        //     }

        //     if (environmentIndex >= ducksVal)
        //     {
        //         randInd = Random.Range(0, ducks.Length);
        //         ducks[randInd].SetActive(add);
        //     }
        //     else
        //     {
        //         randInd = Random.Range(0, ducks.Length);
        //         ducks[randInd].SetActive(add);
        //     }
        // }
        // oldIndex = environmentIndex;
    }

    //called by gun everytime something's added/deleted
    public void UpdateIndex(int amount)
    {
        oldIndex = environmentIndex;
        environmentIndex += amount;
    }

    // everytime something's added, check here to see if we can add anything
    public void UpdateEnvironment(bool add)
    {
        int randInd;
        if (add && environmentIndex >= ratsVal && environmentIndex < lilyPadsVal)
        {
            randInd = Random.Range(0, rats.Length);
            rats[randInd].SetActive(add);
        }
        else if (!add && environmentIndex < ratsVal)
        {
            DeactivateOne(rats);
        }

        if (add && environmentIndex >= dogsVal && environmentIndex < ducksVal)
        {
            randInd = Random.Range(0, dogs.Length);
            dogs[randInd].SetActive(add);
        }
        else if (!add && environmentIndex < dogsVal)
        {
            DeactivateOne(dogs);
        }

        if (add && environmentIndex >= catsVal)
        {
            randInd = Random.Range(0, cats.Length);
            cats[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(cats);
        }

        if (add && environmentIndex >= humansVal)
        {
            randInd = Random.Range(0, humans.Length);
            humans[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(humans);
        }

        if (add && environmentIndex >= chickensVal)
        {
            randInd = Random.Range(0, chickens.Length);
            chickens[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(chickens);
        }

        if (add && environmentIndex >= lilyPadsVal)
        {
            randInd = Random.Range(0, lilyPads.Length);
            lilyPads[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(lilyPads);
        }

        if (add && environmentIndex >= husbandryVal)
        {
            randInd = Random.Range(0, husbandry.Length);
            husbandry[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(husbandry);
        }

        if (add && environmentIndex >= ducksVal)
        {
            randInd = Random.Range(0, ducks.Length);
            ducks[randInd].SetActive(add);
        }
        else if (!add)
        {
            DeactivateOne(ducks);
        }
    }

    //everytime something's removed, check to see what needs to be removed

    private void InitializeAll()
    {

    }

    private void DeactiateStuff(GameObject[] things)
    {
        foreach (GameObject go in things)
        {
            go.SetActive(false);
        }
    }

    private void DeactivateOne(GameObject[] things)
    {
        bool found = false;
        int i = 0;
        while (!found && i < things.Length)
        {
            if (things[i].activeSelf)
            {
                things[i].SetActive(false);
                found = true;
            }
            i++;
        }
    }
}
