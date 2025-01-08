using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactions : MonoBehaviour
{
    //Player
    private Transform player;
    public float distance;
    public Transform cam;
    public Transform pcCam;
    public Transform lpCam;
    private bool onPC;
    private bool onLP;
    public TextMeshProUGUI NPCTalk;
    public TextMeshProUGUI moneyText;
    private float money;
    private bool moneyStart;

    //Text
    public TextMeshProUGUI iText;
    public TextMeshProUGUI fText;
    public GameObject platesCorrect;
    private int plateCount;
    private bool interactableNear = false;

    //IDs Unlocked
    public bool ID1 = false;
    public bool ID2 = false;
    public bool ID3 = false;
    public bool ID4 = false;
    public bool ID5 = false;
    public bool ID6 = false;
    public bool cakeID = false;
    public bool basement = false;

    //Freezer
    public Transform redDial;
    public Transform yellowDial;
    public Transform greenDial;
    private int redCount;
    private int yellowCount;
    private int greenCount;
    public GameObject redNumber;
    public GameObject yellowNumber;
    public GameObject greenNumber;
    public GameObject dialBerg;
    public GameObject dialsCorrect;

    //Pantry
    public Transform kingsWine;
    public Transform wineColumn;
    public Transform wineFix;
    private bool wineBroke = true;
    public TextMeshPro ID2Text;

    //Kitchen
    public Transform egg;
    public Transform flour;
    public Transform milk;
    public Transform bowl;
    public Transform oven;
    public GameObject cake;
    private bool holdingCake;
    private bool eggBool = false;
    private bool flourBool = false;
    private bool milkBool = false;
    private bool eggBool1 = false;
    private bool flourBool1 = false;
    private bool milkBool1 = false;
    private bool allIng = false;
    private bool holdBowl = false;
    private bool inOven = false;
    public TextMeshPro timerText;
    private float elapsedTime;
    private bool timerStarted = false;

    //Flags
    public Transform pie;
    public Transform syrup;
    public Transform waffles;
    public Transform mochi;
    public Transform churro;
    public Transform tiramissu;
    public Transform cinammonroll;
    public Transform macaroon;

    private bool holdingFood = false;

    public Transform piePlate; //USA
    public Transform syrupPlate; //CANADA
    public Transform wafflesPlate; //BELGIUM
    public Transform mochiPlate; //JAPAN
    public Transform churroPlate; //SPAIN
    public Transform tiramissuPlate; //ITALY
    public Transform cinammonrollPlate; //SWEDEN
    public Transform macaroonPlate; //FRANCE
    public Transform swapPlate;

    private Transform foodHeld;

    private bool wasRight;
    private bool pieCheck = false;
    private bool syrupCheck = false;
    private bool wafflesCheck = false;
    private bool mochiCheck = false;
    private bool churroCheck = false;
    private bool tiramissuCheck = false;
    private bool cinammonrollCheck = false;
    private bool macaroonCheck = false;

    //Lounge
    public Transform laptop;

    //Bedroom
    public Transform computer;

    //Bathroom
    public Transform bSwitch;
    public bool switched;

    //Sounds
    public AudioClip moneySound;
    public AudioClip dingSound;
    public AudioClip switchSound;
    public AudioClip tapeSound;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    //List
    private List<Transform> interactables;

    void Start()
    {
        player = GetComponent<Transform>();
        dialBerg.gameObject.SetActive(false);
        dialsCorrect.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        cake.gameObject.SetActive(false);
        wineFix.gameObject.SetActive(false);
        ID2Text.gameObject.SetActive(false);
        NPCTalk.gameObject.SetActive(false);
        moneyText.gameObject.SetActive(false);
        interactables = new List<Transform> {
        //FREEZER
        redDial, yellowDial, greenDial,
        //PANTRY
        wineColumn,
        //KITCHEN
        egg, flour, milk, bowl, oven,
        //FLAGS
        pie, syrup, waffles, mochi, churro, tiramissu, cinammonroll, macaroon, piePlate, syrupPlate, wafflesPlate, mochiPlate, churroPlate, tiramissuPlate, cinammonrollPlate, macaroonPlate, swapPlate,
        //LOUNGE
        laptop,
        //BEDROOM
        computer,
        //BATHROOM
        bSwitch};
        iText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        interactableNear = false;

        foreach (Transform obj in interactables)
        {
            distance = Vector3.Distance(player.position, obj.position);

            if (distance < 1f)
            {
                interactableNear = true;
                iText.gameObject.SetActive(true);

                //FREEZER
                if (obj == redDial)
                {
                    iText.text = "Adjust Red Dial";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(redCount == 8)
                        {
                            redCount = 0;
                        }
                        else
                        {
                            redCount = redCount + 1;
                        }
                        string red = redCount.ToString();
                        redNumber.GetComponent<TextMeshPro>().text = red;
                    }
                }

                else if (obj == yellowDial)
                {
                    iText.text = "Adjust Yellow Dial";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (yellowCount == 8)
                        {
                            yellowCount = 0;
                        }
                        else
                        {
                            yellowCount = yellowCount + 1;
                        }
                        string yellow = yellowCount.ToString();
                        yellowNumber.GetComponent<TextMeshPro>().text = yellow;
                    }
                }
                
                else if (obj == greenDial)
                {
                    iText.text = "Adjust Green Dial";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (greenCount == 8)
                        {
                            greenCount = 0;
                        }
                        else
                        {
                            greenCount = greenCount + 1;
                        }
                        string green = greenCount.ToString();
                        greenNumber.GetComponent<TextMeshPro>().text = green;
                    }
                }

                //PANTRY
                else if (obj == wineColumn && wineBroke)
                {
                    iText.text = "Fix Bottle";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        audioSource4.PlayOneShot(tapeSound);
                        wineColumn.gameObject.SetActive(false);
                        wineFix.gameObject.SetActive(true);
                        iText.text = "";
                        wineBroke = false;
                        ID2Text.gameObject.SetActive(true);
                        ID2 = true;
                    }
                }
                //KITCHEN
                else if (obj == egg && !holdingFood && !holdingCake)
                {
                    iText.text = "Pick up EGGS";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        egg.position = new Vector3(0, 30, 0);
                        iText.text = "";
                        holdingCake = true;
                        eggBool = true;
                        eggBool1 = true;
                    }
                }
                else if (obj == flour && !holdingFood && !holdingCake)
                {
                    iText.text = "Pick up FLOUR";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        flour.position = new Vector3(0, 33, 0);
                        fText.text = "";
                        holdingCake = true;
                        flourBool = true;
                        flourBool1 = true;
                    }
                }
                else if (obj == milk && !holdingFood && !holdingCake)
                {
                    iText.text = "Pick up MILK";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        milk.position = new Vector3(0, 36, 0);
                        fText.text = "";
                        holdingCake = true;
                        milkBool = true;
                        milkBool1 = true;
                    }
                }
                else if (obj == bowl)
                {
                    if (holdingCake)
                    {
                        iText.text = "Place in BOWL";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            fText.text = "";
                            holdingCake = false;
                            eggBool1 = false;
                            milkBool1 = false;
                            flourBool1 = false;
                        }
                    }
                    if(!holdingCake)
                    {
                        if(allIng)
                        {
                            iText.text = "Pick up BOWL";
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                bowl.position = new Vector3(0, 40, 0);
                                holdBowl = true;
                                holdingCake = true;
                            }
                        }
                        else
                        {
                            iText.text = "";
                        }
                    }
                }
                else if (obj == oven && holdBowl)
                {
                    iText.text = "Put in Oven";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        iText.text = "";
                        inOven = true;
                        holdBowl = false;
                        holdingCake = false;
                        Timer();
                    }
                }

                //FLAGS
                else if (obj == pie && !holdingFood && !pieCheck && !holdingCake)
                {
                    iText.text = "Pick up APPLE PIE";
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(pie);
                    }
                }

                else if (obj == syrup && !holdingFood && !syrupCheck && !holdingCake)
                {
                    iText.text = "Pick up MAPLE SYRUP";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(syrup);
                    }
                }

                else if (obj == waffles && !holdingFood && !wafflesCheck && !holdingCake)
                {
                    iText.text = "Pick up WAFFLE";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(waffles);
                    }
                }

                else if (obj == mochi && !holdingFood && !mochiCheck && !holdingCake)
                {
                    iText.text = "Pick up MOCHI";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(mochi);
                    }
                }

                else if (obj == churro && !holdingFood && !churroCheck && !holdingCake)
                {
                    iText.text = "Pick up CHURRO";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(churro);
                    }
                }

                else if (obj == tiramissu && !holdingFood && !tiramissuCheck && !holdingCake)
                {
                    iText.text = "Pick up TIRAMISSU";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(tiramissu);
                    }
                }

                else if (obj == cinammonroll && !holdingFood && !cinammonrollCheck && !holdingCake)
                {
                    iText.text = "Pick up CINAMMON ROLL";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(cinammonroll);
                    }
                }

                else if (obj == macaroon && !holdingFood && !macaroonCheck && !holdingCake)
                {
                    iText.text = "Pick up MACARON";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HoldFood(macaroon);
                    }
                }

                else if (obj == piePlate && holdingFood)
                {
                    iText.text = "PLATE USA";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(piePlate, foodHeld);
                    }
                }

                else if (obj == syrupPlate && holdingFood)
                {
                    iText.text = "PLATE CANADA";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(syrupPlate, foodHeld);
                    }
                }

                else if (obj == wafflesPlate && holdingFood)
                {
                    iText.text = "PLATE BELGIUM";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(wafflesPlate, foodHeld);
                    }
                }

                else if (obj == mochiPlate && holdingFood)
                {
                    iText.text = "PLATE JAPAN";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(mochiPlate, foodHeld);
                    }
                }

                else if (obj == churroPlate && holdingFood)
                {
                    iText.text = "PLATE SPAIN";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(churroPlate, foodHeld);
                    }
                }

                else if (obj == tiramissuPlate && holdingFood)
                {
                    iText.text = "PLATE ITALY";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(tiramissuPlate, foodHeld);
                    }
                }

                else if (obj == cinammonrollPlate && holdingFood)
                {
                    iText.text = "PLATE SWEDEN";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(cinammonrollPlate, foodHeld);
                    }
                }

                else if (obj == macaroonPlate && holdingFood)
                {
                    iText.text = "PLATE FRANCE";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(macaroonPlate, foodHeld);
                    }
                }

                else if (obj == swapPlate && holdingFood)
                {
                    iText.text = "SPARE PLATE";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlateFood(swapPlate, foodHeld);
                    }
                }

                //LOUNGE
                else if (obj == laptop)
                {
                    if (!onLP)
                    {
                        iText.text = "Use Laptop";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            onLP = true;
                            cam.gameObject.SetActive(false);
                            pcCam.gameObject.SetActive(false);
                            lpCam.gameObject.SetActive(true);
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            GetComponent<CharacterController>().enabled = false;
                        }
                    }
                    else
                    {
                        iText.text = "";
                        if(Input.GetKeyDown(KeyCode.B))
                        {
                            onLP = false;
                            cam.gameObject.SetActive(true);
                            lpCam.gameObject.SetActive(false);
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            GetComponent<CharacterController>().enabled = true;

                        }
                    }
                }
                //BEDROOM
                else if (obj == computer)
                {
                    if (!onPC)
                    {
                        iText.text = "Use PC";

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            onPC = true;
                            SwitchCamera();
                        }
                    }
                    else
                    {
                        iText.text = "";

                        if (Input.GetKeyDown(KeyCode.B))
                        {
                            onPC = false;
                            SwitchCamera();
                        }
                    }
                }

                //BATHROOM
                else if (obj == bSwitch)
                {
                    iText.text = "Use Switch";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        audioSource3.PlayOneShot(switchSound);
                        switched = true;
                        bSwitch.position = new Vector3(0, 15, 0);
                        iText.text = "";
                        ID6 = true;
                    }
                }
                break;

            }
        }
        if(!interactableNear)
        {
            iText.gameObject.SetActive(false);
            iText.text = "";
        }
        if(holdingFood || holdingCake)
        {
            fText.gameObject.SetActive(true);
        }
        if(!holdingFood && !holdingCake)
        {
            fText.gameObject.SetActive(false);
        }

        if (redCount == 2 && greenCount == 6 && yellowCount == 3)
        {
            dialBerg.gameObject.SetActive(true);
            dialsCorrect.gameObject.SetActive(true);
            dialsCorrect.GetComponent<TextMeshPro>().text = "All Dials Correct\n" + "ID:1 UNLOCKED";
            ID1 = true;
        }

        if(eggBool && flourBool && milkBool)
        {
            allIng = true;
        }
        if(eggBool1)
        {
            fText.text = "INVENTORY:\nEggs";
        }
        if(flourBool1)
        {
            fText.text = "INVENTORY:\nFlour";
        }
        if(milkBool1)
        {
            fText.text = "INVENTORY:\nMilk";
        }
        if(holdBowl)
        {
            fText.text = "INVENTORY:\nBowl";
        }
        if(inOven && timerStarted)
        {
            timerText.gameObject.SetActive(true);
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 5f)
            {
                audioSource2.PlayOneShot(dingSound);
                timerText.text = "DONE";
                timerStarted = false;
                cake.gameObject.SetActive(true);
                ID3 = true;
            }
        }
        if(moneyStart)
        {
            money = money + 1f;
            moneyText.text = "$:" + money;
        }
    }

    void HoldFood(Transform food)
    {
        food.position = new Vector3(0, 10, 0);
        fText.text = "INVENTORY:\n" + food.name;
        holdingFood = true;
        iText.text = "";
        foodHeld = food;

        if(wasRight)
        {
            plateCount--;
            UpdatePlatesCorrectText();
        }
    }
    void PlateFood(Transform plate, Transform food)
    {
        food.position = plate.position;
        holdingFood = false;
        fText.text = "";
        iText.text = "";

        if (PlateCheck(plate, food))
        {
            plateCount++;
            UpdatePlatesCorrectText();
            if(food == pie)
            {
                pieCheck = true;
            }
            if (food == syrup)
            {
                syrupCheck = true;
            }
            if (food == waffles)
            {
                wafflesCheck = true;
            }
            if (food == mochi)
            {
                mochiCheck = true;
            }
            if (food == churro)
            {
                churroCheck = true;
            }
            if (food == tiramissu)
            {
                tiramissuCheck = true;
            }
            if (food == cinammonroll)
            {
                cinammonrollCheck = true;
            }
            if (food == macaroon)
            {
                macaroonCheck = true;
            }
        }
    }
    bool PlateCheck(Transform plate, Transform food)
    {
        Dictionary<Transform, Transform> correctPlates = new Dictionary<Transform, Transform>
        {
            { pie, piePlate },
            { syrup, syrupPlate },
            { waffles, wafflesPlate },
            { mochi, mochiPlate },
            { churro, churroPlate },
            { tiramissu, tiramissuPlate },
            { cinammonroll, cinammonrollPlate },
            { macaroon, macaroonPlate }
        };
        return correctPlates.ContainsKey(food) && correctPlates[food] == plate;
    }
    void UpdatePlatesCorrectText()
    {
        if (plateCount == 8)
        {
            platesCorrect.GetComponent<TextMeshPro>().text = "All Plates Correct\n" + "ID:4 UNLOCKED";
            ID4 = true;
        }
        else
        {
            platesCorrect.GetComponent<TextMeshPro>().text = "Correct Plates\n" + plateCount + "/8";
        }
    }
    void SwitchCamera()
    {
        if (onPC) 
        { 
            cam.gameObject.SetActive(false);
            pcCam.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            cam.gameObject.SetActive(true);
            pcCam.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GetComponent<CharacterController>().enabled = true;
        }
    }
    void Timer()
    {
        elapsedTime = 0f;
        timerStarted = true;
        timerText.text = "Baking";
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CandyCane"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "Welcome to the Dessert Mansion";
        }
        if (other.CompareTag("CandyBar"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "Rumor has it there's a riddle per room";
        }
        if (other.CompareTag("Butter"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "Hi.";
        }
        if (other.CompareTag("Cola"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "I wonder if the bedroom riddle is last";
        }
        if (other.CompareTag("Pancake"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "I have no clue what IceCream is saying";
        }
        if (other.CompareTag("IceCream"))
        {
            NPCTalk.gameObject.SetActive(true);
            NPCTalk.text = "WASD to move\nShift to sprint\nE to Interact";
        }
        if (other.CompareTag("Cake"))
        {
            audioSource1.PlayOneShot(moneySound);
            NPCTalk.gameObject.SetActive(true);
            moneyStart = true;
            moneyText.gameObject.SetActive(true);
            NPCTalk.text = "YOU DID IT!\nYou were smart enough to solve all of the riddles!\nFor your reward I will share my wealth with you!";
            GetComponent<CharacterController>().enabled = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CandyCane"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
        if (other.CompareTag("CandyBar"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
        if (other.CompareTag("Butter"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
        if (other.CompareTag("Cola"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
        if (other.CompareTag("Pancake"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
        if (other.CompareTag("IceCream"))
        {
            NPCTalk.gameObject.SetActive(false);
        }
    }
}
