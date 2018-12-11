using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ShotModifier
{
    Ristretto,
    Long
}

public enum ShotType
{
    DecafSingle,
    DecafDouble,
    HalfDecafDouble,
    HalfDecafQuad,
    Single,
    Double,
    Triple,
    Quad
}

public enum Size
{
    Small,
    Medium,
    Large
}
public enum MilkType
{
    _2Percent,
    Nonfat,
    Whole,
    Soy,
    Coconut,
    Almond
}



public enum Drink
{
    Latte,
    Cappuccino,
    Americano
}

public enum DrinkComponent
{
    Drink,
    ShotType,
    ShotModifier,
    Size,
    MilkType
}

public struct Order
{
    public Size size;
    public MilkType milkType;
    public ShotModifier shotModifier;
    public ShotType shotType;
    public Drink drink;

    public Order(Size _size, MilkType _milkType, 
        ShotType _shotType, Drink _drink, ShotModifier _shotModifier)
    {
        shotModifier = _shotModifier;
        size         = _size;
        milkType     = _milkType;
        shotType     = _shotType;
        drink        = _drink;
    }
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private Dictionary<ShotType, string> shots = new Dictionary<ShotType, string>()
    {
        { ShotType.DecafSingle,     "Decaf Single" },
        { ShotType.DecafDouble,     "Decaf Double" },
        { ShotType.HalfDecafDouble, "½ Decaf Double" },
        { ShotType.HalfDecafQuad,   "½ Decaf Quad" },
        { ShotType.Single,          "Single" },
        { ShotType.Double,          "Double" },
        { ShotType.Triple,          "Triple" },
        { ShotType.Quad,            "Quad" }
    };

    private Dictionary<MilkType, string> milks = new Dictionary<MilkType, string>()
    {
        { MilkType.Almond,      "Almond" },
        { MilkType.Coconut,     "Coconut" },
        { MilkType.Nonfat,      "Nonfat" },
        { MilkType.Soy,         "Soy" },
        { MilkType.Whole,       "Whole"},
        { MilkType._2Percent,   "2%" }
    };
    private Dictionary<Size, string> sizes = new Dictionary<Size, string>()
    {
        { Size.Small,      "Small" },
        { Size.Medium,     "Medium" },
        { Size.Large,      "Large" }
    };
    private Dictionary<Drink, string> drinks = new Dictionary<Drink, string>()
    {
        { Drink.Americano,  "Americano" },
        { Drink.Cappuccino, "Cappuccino" },
        { Drink.Latte,      "Latte" }
    };
    private Dictionary<ShotModifier, string> modifiers = new Dictionary<ShotModifier, string>()
    {
        { ShotModifier.Long,      "Long" },
        { ShotModifier.Ristretto, "Ristretto" }
    };

    private List<Order> orders = new List<Order>();
    public Order CurrentOrder { get; private set; }
    public List<TextMeshProUGUI> orderTexts;


    private bool shotGlass1OnMachine = true;
    private bool shotGlass2OnMachine = true;

    public MilkType SelectedMilk { get; set; }
    public ShotType SelectedShotType { get; set; }
    public ShotModifier SelectedShotModifier { get; set; }
    public bool PitcherOnMachine { get; set; }
    public bool ShotGlass1OnMachine { get { return shotGlass1OnMachine; } set { shotGlass1OnMachine = value; } }
    public bool ShotGlass2OnMachine { get { return shotGlass2OnMachine; } set { shotGlass2OnMachine = value; } }

    public GameObject SelectedMilkLabel;

    public Dropdown milkDropDown;

    private bool milkCorrect = false;
    private bool shotCorrect = false;
    private bool shotModifierCorrect = false;
    private bool sizeCorrect = false;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
        //DontDestroyOnLoad(gameObject);
        StartGame();

       
    }

    private void StartGame()
    {
        orderTexts.Clear();
        orderTexts.Add(GameObject.FindGameObjectWithTag("Chalkboard1").GetComponent<TextMeshProUGUI>());
        orderTexts.Add(GameObject.FindGameObjectWithTag("Chalkboard2").GetComponent<TextMeshProUGUI>());
        orderTexts.Add(GameObject.FindGameObjectWithTag("Chalkboard3").GetComponent<TextMeshProUGUI>());
        orderTexts.Add(GameObject.FindGameObjectWithTag("Chalkboard4").GetComponent<TextMeshProUGUI>());

        milkDropDown = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<Dropdown>();
        SelectedMilkLabel = GameObject.FindGameObjectWithTag("DropdownLabel");


        GenerateOrders(1);
        CurrentOrder = orders[0];
        //for(int i = 0; i < orderTexts.Count; i++)
        //{
        //    orderTexts[i].text = OrderToString(orders[i]);
        //}

        orderTexts[0].text = modifiers[orders[0].shotModifier];
        orderTexts[1].text = shots[orders[0].shotType];
        orderTexts[2].text = sizes[orders[0].size];
        orderTexts[3].text = milks[orders[0].milkType] + " milk";

        milkDropDown.options = new List<Dropdown.OptionData>();

        for(int i = 0; i < milks.Count; i++)
        {
            milkDropDown.options.Add(new Dropdown.OptionData(milks[(MilkType)i]));
        }
        milkDropDown.RefreshShownValue();
    }

    public void EvaluateChoice(string shotType)
    {

    }

    public void GenerateOrders(int nOrders)
    {
        orders.Clear();
        for(int i = 0; i < nOrders; i++)
        {
            orders.Add(new Order(
                (Size)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(Size)).Length)),
                (MilkType)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(MilkType)).Length)),
                (ShotType)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(ShotType)).Length)),
                (Drink)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(Drink)).Length)),
                (ShotModifier)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(ShotModifier)).Length))));
        }
    }

    public string OrderToString(Order order)
    {
        return
        modifiers[order.shotModifier] + " " +
        shots[order.shotType] + " " +
        sizes[order.size] + " " +
        drinks[order.drink] + " with " +
        milks[order.milkType] + " Milk";
    }

    public void UpdateMilkSelection()
    {
        string milkString = SelectedMilkLabel.GetComponent<Text>().text;
        for(int i = 0; i < milks.Count; i++)
        {
            if(milks[(MilkType)i] == milkString)
            { 
                SelectedMilk = (MilkType)i;
                break;
            }
        }
    }

    public void SetSelectedShotType(string type)
    {
        SelectedShotType = (ShotType)Enum.Parse(typeof(ShotType), type);
    }
    public void SetSelectedShotModifier(string type)
    {
        SelectedShotModifier = (ShotModifier)Enum.Parse(typeof(ShotModifier), type);
    }

    public void UpdateText(DrinkComponent shotModifier)
    {

        //orderTexts[0].text = modifiers[orders[0].shotModifier];
        //orderTexts[1].text = shots[orders[1].shotType];
        //orderTexts[2].text = sizes[orders[2].size];
        //orderTexts[3].text = milks[orders[3].milkType];
        //bad hardcoded
        switch(shotModifier)
        {
            case DrinkComponent.Drink:
                break;
            case DrinkComponent.ShotModifier:
                orderTexts[0].fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
                shotModifierCorrect = true;
                break;
            case DrinkComponent.ShotType:
                orderTexts[1].fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
                shotCorrect = true;
                break;
            case DrinkComponent.Size:
                orderTexts[2].fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
                sizeCorrect = true;
                break;
            case DrinkComponent.MilkType:
                orderTexts[3].fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
                milkCorrect = true;
                break;
        }

        if( shotModifierCorrect && shotCorrect && milkCorrect && sizeCorrect)
        {
            //play sound
            GetComponent<AudioSource>().Play();
            //ResetData();
            StartCoroutine(ResetSceneDelayed(1.5f));
        }
    }

    public IEnumerator ResetSceneDelayed(float time)
    {
        yield return new WaitForSeconds (time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //StartGame();
    }
    
    public void ResetData()
    {
        milkCorrect = false;
        shotCorrect = false;
        shotModifierCorrect = false;
        sizeCorrect = false;
        ShotGlass1OnMachine = false;
        ShotGlass2OnMachine = false;
        PitcherOnMachine = false;
        SelectedMilk = MilkType._2Percent;
    }
}


