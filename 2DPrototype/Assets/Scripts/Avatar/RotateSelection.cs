using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TARGET: Empty game object - Manager, 
///         which has AvatarPartCollection, CategorySelection and RotateSelection scripts attached
/// PURPOSE: - React to arrow keys and pedalling
/// </summary>

public class RotateSelection : MonoBehaviour {

    //Array of avatar elements which can be selected
    public AvatarDescription[] avatarElements;

    //Main avatar sprite, which is changed 
    public GameObject mainSprite;

    //Selection item TODO: make it prettier
    public GameObject partS;    //Selection item
    public Text priceTag;
    public GameObject buyBtn;

    //Sprites
    public GameObject bike;
    public GameObject spriteOnBike;
    private int currentSelectedSprite = 0;

    //Selection and pedalling
    public float progressToUnlock = 100.0f;
    private bool verticalSelectionActive = false;
    private float currentVerticalProgress = 0.03f;
    public float extraSpeedModifier = 0.15f;

    private bool bikeSpriteSet = false;
    private Vector2 initialBikePos;

    //Bought Items
    ListOfBoughtItems boughtItemsScript;
    public GameObject buyButton;

    //Audio
    AvatarAudio audioManager;

    //START
    // Use this for initialization
    void Start ()
    {
        initialBikePos = bike.transform.position;

        //Script
        boughtItemsScript = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<ListOfBoughtItems>();

        //Audio
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AvatarAudio>();
    }
	
    //UPDATE
	// Update is called once per frame
	void Update ()
    {
        //Check for input and change sprite selection
       if (HorizontalInputReceived())
          ChangeSelection();

        //Vertical input detected
        if (Input.GetAxis("Vertical") > 0.05f && mainSprite.GetComponent<SpriteRenderer>().sprite != avatarElements[currentSelectedSprite].getSprite())
        {
            verticalSelectionActive = true;

            VerticalSelection();
        }

        //Space bar to buy
        if(Input.GetKeyUp("space") && buyButton.activeSelf)
        {
            OnBuyItemClick();
        }
    }

    void VerticalSelection()
    {
        //If item is owned
        if (avatarElements[currentSelectedSprite].isOwned)
        {
            //Bike on the move towards avatar
            if (currentVerticalProgress < progressToUnlock)
            {
                //Add current spinning value
                currentVerticalProgress += Input.GetAxis("Vertical");

                //Move bike
                bike.transform.position += Vector3.right * Input.GetAxis("Vertical") * extraSpeedModifier;
            }
            else //Bike reached avatar
            {
                //SPECIAL CASES
                CheckIfSkinChanged();            //Skin colour 
                CheckIfHairDyeChanged();         //Hair colour

                //Change sprite picture
                mainSprite.GetComponent<SpriteRenderer>().sprite = avatarElements[currentSelectedSprite].getSprite();

                //Change ID
                mainSprite.GetComponent<CurrentAvatarDescription>().spriteId = avatarElements[currentSelectedSprite].spriteId;

                currentVerticalProgress = 0.1f;
                verticalSelectionActive = false;

                //Return bike to the beginning
                bike.transform.position = initialBikePos;

                //Set selection to none
                spriteOnBike.GetComponent<SpriteRenderer>().sprite = null;

                //Audio
                audioManager.PlayChangeApplied();
            }
        }
    }

    //--------------------------------------------------------------------------
    //--- SPECIAL CASES ---
    //--------------------------------------------------------------------------

    //SKIN
    //If a skin colour was moved to avatar, apply changes to face and body
    void CheckIfSkinChanged()
    {
        if (avatarElements[currentSelectedSprite].SkinDye != spriteColour.none)
        {
            this.GetComponent<CategorySelection>().currentSkinColour = avatarElements[currentSelectedSprite].SkinDye;

            //Change face
            ChangeToMatchColour(spriteType.faceShape, GetComponent<AvatarPartsCollection>().faceShapes, "skin");
            //Body
            ChangeToMatchColour(spriteType.body, GetComponent<AvatarPartsCollection>().bodies, "skin");
        }
    }

    //HAIR DYE
    void CheckIfHairDyeChanged()
    {
        if (avatarElements[currentSelectedSprite].HairDye != spriteColour.none)
        {
            Debug.Log("time to change hair colour to " + avatarElements[currentSelectedSprite].HairDye);
            this.GetComponent<CategorySelection>().currentHairColour = avatarElements[currentSelectedSprite].HairDye;

            //Change hair up
            ChangeToMatchColour(spriteType.hairUp, GetComponent<AvatarPartsCollection>().hairUp, "hair");
            //Change hair down
            ChangeToMatchColour(spriteType.hairDown, GetComponent<AvatarPartsCollection>().hairDown, "hair");
        }
    }

    //--------------------------------------------------------------------------

    //This is a public function which is called when a category is changed
    public void RepositionParticles()
    {
        currentSelectedSprite = 0;

        //Position selection item at the beginning of the row
        ModifySelectionItem();
    }

    //Check for arrow key input
    //Change currently selected sprite accordingly
    bool HorizontalInputReceived()
    {
        bool changeSpriteSelection = false;

        //ARROW RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelectedSprite + 1 < avatarElements.Length)
                currentSelectedSprite++;
            else
                currentSelectedSprite = 0;

            changeSpriteSelection = true;
        }

        //ARROW LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelectedSprite > 0)
                currentSelectedSprite--;
            else
                currentSelectedSprite = avatarElements.Length - 1;

            changeSpriteSelection = true;
        }

        return changeSpriteSelection;
    }

    //ON BUTTON CLICK
    public void SelectionRight()
    {
        if (currentSelectedSprite + 1 < avatarElements.Length)
            currentSelectedSprite++;
        else
            currentSelectedSprite = 0;

        ChangeSelection();
    }

    //ON BUTTON CLICK
    public void SelectionLeft()
    {
        if (currentSelectedSprite > 0)
            currentSelectedSprite--;
        else
            currentSelectedSprite = avatarElements.Length - 1;

        ChangeSelection();
    }

    //Respond to arrow key input to indicate which picture is selected
    public void ChangeSelection()
    {
        //Move Selection item
        ModifySelectionItem();

        //Set on bike sprite to a current selection only if it is npt applied yet
        if (mainSprite.GetComponent<SpriteRenderer>().sprite != avatarElements[currentSelectedSprite].getSprite())
        {
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = avatarElements[currentSelectedSprite].getSprite();
        }
        else
        {
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = null;
        }
        
    }

    //Change selection item depending on if its owned or not
    void ModifySelectionItem()
    {
        //Move particles
        partS.transform.position = new Vector2(avatarElements[currentSelectedSprite].getPosition().x, avatarElements[currentSelectedSprite].getPosition().y);

        //Audio
        audioManager.PlaySpriteChange();

        //If owned
        if(avatarElements[currentSelectedSprite].isOwned)
        {
            //Dont show buy btn
            buyBtn.SetActive(false);

            //Change colour of the overlay
            partS.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else //Not owned
        {
            //Show buy btn
            buyBtn.SetActive(true);

            //Price tag
            priceTag.text = avatarElements[currentSelectedSprite].price.ToString();

            //Change colour of the overlay
            partS.GetComponent<SpriteRenderer>().color = Color.cyan;

        }
    }

    void ChangeToMatchColour(spriteType avatarElement, List<SpriteInstance> collection, string dyeType)
    {
        //Query a list by number
        //Look for the skin colour
        GameObject faceSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(avatarElement.ToString()).gameObject;
        int currentFaceId = faceSprite.GetComponent<CurrentAvatarDescription>().spriteId;
        Debug.Log(currentFaceId);

        foreach (var face in collection)
        {
            if (face.spriteId == currentFaceId)
            {
                if (dyeType == "skin")
                {
                    if (face.colour == GetComponent<CategorySelection>().currentSkinColour)
                    {
                        faceSprite.GetComponent<SpriteRenderer>().sprite = face.spriteObject;
                        return;
                    }
                }
                else
                {
                    if(dyeType == "hair")
                    {
                        if (face.colour == GetComponent<CategorySelection>().currentHairColour)
                        {
                            faceSprite.GetComponent<SpriteRenderer>().sprite = face.spriteObject;
                            return;
                        }
                    }

                }

            }
        }
    }
    

    //Called externally
    public void SetUpArray(List<GameObject> newItemList)
    {
        avatarElements = new AvatarDescription[newItemList.Count];

        //Convert a list of game objects to an array of avatar descriptions
        for(int i=0; i<avatarElements.Length; i++)
        {
            avatarElements[i] = newItemList[i].GetComponent<AvatarDescription>();
        }


        Debug.Log(this.GetComponent<CategorySelection>().currentCategory.ToString());

        mainSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(this.GetComponent<CategorySelection>().currentCategory.ToString()).gameObject;
    }

    //--------------------------------------------------------------------------
    //--- BUY ITEMS ---
    //--------------------------------------------------------------------------
    //Button click
    public void OnBuyItemClick()
    {
        PlayerMoney playerMoney = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<PlayerMoney>();

        if (playerMoney.getBalance() >= avatarElements[currentSelectedSprite].price)
        {
            //Reduce balane
            playerMoney.pay(avatarElements[currentSelectedSprite].price);

            //Oficially desclare item bought
            avatarElements[currentSelectedSprite].isOwned = true;

            //Remember that this item is owned
            boughtItemsScript.AddItemToCategory(GetComponent<CategorySelection>().currentCategory, currentSelectedSprite);

            //Change selection item
            ModifySelectionItem();

            //Audio
            audioManager.PlayCoins();
        }
        else
        {
            //Audio
            audioManager.PlayTooExpensive();
        }
    }
}
