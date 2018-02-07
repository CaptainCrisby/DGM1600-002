using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour {

    public enum States { lobby, hallway, mirror, hospital, smash, bedroom, drink, enter, noEnter, trumpet, attack, run, wristwatch, noDrink, noEat, eat, good, bad };
    private States currentState;
    public Text textObject;
    public Text titleObject;
    public Text keyObject;
    public bool key = false;
    public string soda;
    private bool user;

    // Use this for initialization
    void Start()
    {
        //Checks whether or not the user is a number (UVU ID) or a word (real name)
        if (System.Environment.UserName.Contains("1")){
            user = false;
        }
        else{
            user = true;
        }

        currentState = States.lobby;

        //Setting up the random soda from the txt file
        string path = "Assets/sodas.txt";
        string[] lines = System.IO.File.ReadAllLines(path);
        soda = lines[Random.Range(0, lines.Length)];
    }
        // Update is called once per frame
        void Update() {

        if (currentState == States.lobby)
        {
            Lobby();
        }

        else if (currentState == States.hallway)
        {
            Hallway();
        }

        else if (currentState == States.mirror)
        {
            Mirror();
        }

        else if ((currentState == States.hospital))
        {
            Hospital();
        }

        else if ((currentState == States.smash))
        {
            Smash();
        }

        else if ((currentState == States.bedroom))
        {
            Bedroom();
        }

        else if ((currentState == States.drink))
        {
            Drink();
        }

        else if ((currentState == States.enter))
        {
            Cat();
        }

        else if ((currentState == States.noEnter))
        {
            NoCat();
        }

        else if ((currentState == States.trumpet))
        {
            Trumpet();
        }

        else if ((currentState == States.attack))
        {
            Attack();
        }

        else if ((currentState == States.run))
        {
            Run();
        }

        else if ((currentState == States.wristwatch))
        {
            Wristwatch();
        }

        else if ((currentState == States.noDrink))
        {
            NoDrink();
        }

        else if ((currentState == States.noEat))
        {
            NoEat();
        }

        else if ((currentState == States.eat))
        {
            Eat();
        }

        else if ((currentState == States.bad))
        {
            BadEnd();
        }

        else if ((currentState == States.good))
        {
            GoodEnd();
        }

    }

    // "\n" makes it so it displays on a new line. This is a bunch of stuff that runs depending on currentState's value.

    private void Lobby(){
        titleObject.text = "The Lobby";
        textObject.text = "I'm in a dimly lit room..." +
            "\nThere are <color=#800000ff><b>2 doors</b></color>, each with poorly written, illegible handwriting." +
            "\nJust trying to make out these words makes my head hurt..." +
            "\n<i>Left click for the first door, right click for the second door.</i>";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.hallway; }
        if (Input.GetKeyDown(KeyCode.Mouse1)) { currentState = States.bedroom; }
    }

    private void Hallway()
    {
        titleObject.text = "The Hallway";
        textObject.text = "I can see there's a peculiarly long hallway." +
            "\nSeems pretty ominous." +
            "\nAt the very end there's a locked door...";
        if (key == true)
        {
            textObject.text += "I use the <color=#800000ff> <b>key</b> </color> I just received..." +
                "\nThe door unlocked!";
            if (Input.GetKeyDown(KeyCode.Mouse0)) currentState = States.mirror;
        }
        else if (key == false)
        {
            textObject.text += "I don't have anything that could unlock this at this time." +
                "\nBest I head back." +
                "\n<i>Click to continue.</i>";
            if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.lobby; }
        }
    }

    private void Mirror()
    {
        titleObject.text = "The Mirror Room";
        textObject.text = "There's an image of me. " +
            "\nIt's showcasing some of my most memorable events... " +
            "\nLike the time I got an A to show Mom. " +
            "\nOr scoring that goal in P.E. " +
            "\nAnd even meeting that special someone. " +
            "\nAn overwhelming emotion starts to sweep over myself. " +
            "\nSuddenly, these memories fade into the mirror. " +
            "\nThe silhouette has appeared. " +
            "\nHe's holding an object with an obvious trigger and handle at hand. " +
            "\nThe room has, for some reason, has begun to snow. " +
            "\nWhat do I do?" +
            "\n<i>Left click to smash the mirror, and right click to hold back.</i>";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.smash; }
        if (Input.GetKeyDown(KeyCode.Mouse1)) { currentState = States.hospital; }
    }

    private void Hospital()
    {
        titleObject.text = "";
        textObject.text = "I hold back as the silhouette slowly puts away its object. " +
            "\nIt nods its head at me as my vision began to fade... " +
            "\n... " +
            "\n\"...\" " +
            "\n\"H-'s -akin- up!\"" +
            "\n\"Do--or! -e's a-ke!\"" +
            "\nA familiar white room surrounds me. ";
            if (user == false) //if there's a number, it's your uvu id!
        {
            textObject.text += "\n\"Hey! You're UVU Number " + System.Environment.UserName + ", right?\"" +
            "\n\"...\" " +
            "\n\"I see.\"" +
            "\n\"Well, you see, you've been in a coma " + System.Environment.UserName + " .\"" +
            "\nI remember that number. " +
            "\nMy family walks into the room, embracing the mere sight of my eyes open. " +
            "\nI've missed them for such a long time. " +
            "\nI wonder how much I've missed?" +
            "\nEither way, I'm glad to be back home now. Safe from whatever weird dream that was. " +
            "\nClick to continue.";
            if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.good; }
        }
            else if (user == true) //If there's no number, it knows it's a name
        {
            textObject.text += "\n\"Hey! You're " + System.Environment.UserName + ", right?\"" +
            "\n\"...\"" +
            "\n\"I see.\"" +
            "\n\"Well, you see, you've been in a coma " + System.Environment.UserName + " .\"" +
            "\nI remember that name. " +
            "\nMy family walks into the room, embracing the mere sight of my eyes open. " +
            "\nI've missed them for such a long time. " +
            "\nI wonder how much I've missed?" +
            "\nEither way, I'm glad to be back home now. Safe from whatever weird dream that was. " +
            "\nClick to continue.";
            if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.good; }
        }
    }

    private void Smash()
    {
        titleObject.text = "";
        textObject.text = "I threw my fist at the mirror as hard as I could!" +
            "\nIt shattered. " +
            "\nAn overwhelming sense of pride washes over me. " +
            "\nAdmittedly, I can't help but laugh about the situation. " +
            "\nAnd the laughter slowly gets louder. " +
            "\nAnd louder. " +
            "\n\"...\" " +
            "\n... " +
            "\n\"H-'s -akin- up!\"" +
            "\n\"Do--or! -e's a-ke!\"" +
            "\nAn uncomfortably bright, white room surrounds me. ";
        if (user == false) //if there's a number, it's your uvu id!
        {
        textObject.text += "\n\"Hey! You're UVU number" + System.Environment.UserName + ", right?\"" +
        "\n\"...\" " +
        "\n\"I see.\" " +
        "\n\"Well, you see, you've been in a coma " + System.Environment.UserName + " .\"" +
        "\nThat's weird" +
        "\nI don't remember that number. " +
        "\nA family walks into the room, embracing the mere sight of my eyes open. " +
        "\nBut I'm not sure I recognize them. " +
        "\nAnd I don't think I ever will. " +
        "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.bad; }
        }
        else if (user ==true) //if there isn't, it's your name
        {
            textObject.text += "\n\"Hey! You're " + System.Environment.UserName + ", right?\"" +
            "\n\"...\" " +
            "\n\"I see.\" " +
            "\n\"Well, you see, you've been in a coma " + System.Environment.UserName + " .\" " +
            "\nThat's weird" +
            "\nI don't remember that name. " +
            "\nA family walks into the room, embracing the mere sight of my eyes open. " +
            "\nBut I'm not sure I recognize them. " +
            "\nAnd I don't think I ever will. " +
            "\nClick to continue.";
            if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.bad; }
        }
    }

    private void Bedroom()
    {
        titleObject.text = "The Bedroom";
        textObject.text = "I open the door carefully... " +
            "\nIt's a <color=#800000ff> <b>bedroom.</color> </b> " +
            "\nThe bed looks super comfy, but you resist temptation. " +
            "\nStrangely enough, a <color=#800000ff> <b>giant can of " + soda + "</color> </b> sits in the room. " +
            "\n<i>Press D to drink or N to not drink.</i>";
        if (Input.GetKeyDown(KeyCode.D)) { currentState = States.drink; }
        if (Input.GetKeyDown(KeyCode.N)) { currentState = States.noDrink; }
    }

    private void Drink()
    {
        titleObject.text = "The Bedroom: Cat Edition";
        textObject.text = "I feel rejuvenated!" +
            "\nA giant cat head crashes through the wall with its mouth wide open. " +
            "\n<i>Press E to enter, N to not.</i>";
        if (Input.GetKeyDown(KeyCode.E)) { currentState = States.enter; }
        if (Input.GetKeyDown(KeyCode.N)) { currentState = States.noEnter; }
    }

    private void Cat()
    {
        titleObject.text = "The Cat's Mouth";
        textObject.text = "You decide to go inside the cat's mouth. " +
            "\nAs you walk into the deepest and darkest corners of its mouth, a silhoutte appears. " +
            "\nBefore you can get a good look at it... " +
            "\n*SMACK*" +
            "\nThat was weird?" +
            "\nThat noise sounded like a loud thud... " +
            "\nHow strange. " +
            "\nIt almost sounded like the noise came from me. " +
            "\nNot even a moment passes and the realization hit me... " +
            "\nI've been struck on the head. " +
            "\nA have of heat penetrated my head as I rapidly grasped the now throbbing ache. " +
            "\nQuickly, my body grew numb as it slowly wobbed toward the floor... " +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.bad; }
    }

    private void NoCat()
    {
        titleObject.text = "The Bedroom";
        textObject.text = "I decided not to enter in the cat's mouth. " +
            "\nThe room's quiet air is suddenly interrupted as the cat began to move its jaw. " +
            "\n\"Thanks man\" it remarked." +
            "\nHowever, just as quickly as it spoke, <color=black> <b>the silhouette</color> </b> appeared. " +
            "\nAnd before I know it, there is a trumpet and wristwatch in front of me. " +
            "\nPress T for the trumpet and W for the wristwatch. ";
        if (Input.GetKeyDown(KeyCode.T)) { currentState = States.trumpet; }
        if (Input.GetKeyDown(KeyCode.W)) { currentState = States.wristwatch; }
    }

    private void Trumpet()
    {
        titleObject.text = "The Bedroom: The Musical";
        textObject.text = "I grab the trumpet and attempt to play it quickly. " +
            "\nOf course, however, I have no clue how to play the trumpet. " +
            "\nDespite my lack of knowledge, I attempt to serenade the silhouette. " +
            "\nHe remains unimpressed. " +
            "\nPress A to attack him, press R to run away. ";
        if (Input.GetKeyDown(KeyCode.A)) { currentState = States.attack; }
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.run; }
    }

    private void Attack()
    {
        titleObject.text = "The Bedroom: Attacked";
        textObject.text = "The silhouette moves at a blinding speed. " +
            "\n*Woosh!*" +
            "\nSome sort of bludgeon just barely skims over my head. " +
            "\nEven with my quick evasive skills, I can't find an opening to hit him!" +
            "\nThe small space the room gave me works against me in this fight. " +
            "\nAnd in a moment's notice... " +
            "\n*SMACK*" +
            "\nThat was weird?" +
            "\nThat noise sounded like a loud thud... " +
            "\nHow strange. " +
            "\nIt almost sounded like the noise came from me. " +
            "\nNot even a moment passes and the realization hit me... " +
            "\nI've been struck on the head. " +
            "\nA have of heat penetrated my head as I rapidly grasped the now throbbing ache. " +
            "\nQuickly, my body grew numb as it slowly wobbled toward the floor... " +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.bad; }
    }

    private void Run()
    {
        titleObject.text = "The Bedroom: Flee";
        textObject.text = "No way I can take on this guy!" +
            "\nI run back into the lobby, forgetting everything that just happened. " +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.lobby; }
    }

    private void Wristwatch()
    {
        titleObject.text = "The Bedroom: Key Get";
        key = true;
        keyObject.text = "Keys x 1";
        titleObject.text = "WUDDUP PIMPS IN THE CELL";
        textObject.text = "I pick up the wriswatch to tell the time. " +
            "\n\"The current date and time is " + System.DateTime.Now + ".\"" +
            "\nThe silhouette readjusts his stance, seemingly pleased with this response. " +
            "\nHe's dropped something... " +
            "\nA... key?" + 
            "\nAs the silhouette disappears, I think about what this key could go to. " +
            "\nIt doesn't seem like there's anything important here anymore. " +
            "\nSo let's try visiting the other door in the lobby. " +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.hallway; }
    }

    private void NoDrink()
    {
        titleObject.text = "The Bedroom feat. Mascot";
        textObject.text = "I don't feel like drinking it right now. " +
            "\nHowever, unease begins to fill inside of me as the Cola disappears. " +
            "\nSuddenly, " + soda + " man, the brand's mascot, pounds his way through the wall!" +
            "\n\"Unfortunately, this is the end of the line.\"" +
            "\nCola Man draws back his fist, readying his infamous punch. " +
            "\nSuddenly, Cola Man returns to the caramel colored ooze he is. " +
            "\nHe leaves behind a trinket. " +
            "\nIt's a picture of you? That's weird. " +
            "\nThere's an urge to eat it... it might taste like cola!" +
            "\nPress E to eat it, press N to not eat it. ";
        if (Input.GetKeyDown(KeyCode.E)) { currentState = States.eat; }
        if (Input.GetKeyDown(KeyCode.N)) { currentState = States.noEat; }
    }

    private void NoEat()
    {
        key = true;
        keyObject.text = "Keys x 1";
        titleObject.text = "The Bedroom: Key Get";
        textObject.text = "I don't think it's a good idea to eat this thing. " +
            "\n... " +
            "\nIt began to glow a mysterious light. " +
            "\nIt's turned into a key!" + 
            "\nDoesn't seem like this room needs it. " +
            "\nLooks like we'll have to try the other door in the lobby. " +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.hallway; }
    }

    private void Eat()
    {
        titleObject.text = "The Bedroom: Eating Trinkets";
        textObject.text = "I figure I might as well eat it. " +
            "\nWhat else is it supposed to do? " +
            "\nI popped it into my mouth. " +
            "\n... " +
            "\nYou know?" +
            "\nIt actually doesn't taste half bad. " +
            "\nI have an urge to chew it, but as soon as I do... " +
            "\n*crunch*" +
            "\nThe trinket, in a strange event, turned into a malleable gold key as soon as I chewed. " +
            "\nThe key is now broken in half. " +
            "\nThe door from where I came from is now closed shut and has locked itself." +
            "\nWithout much left to do, I guess I'll just have to sit and wait..." +
            "\nAnd wait..." +
            "\nAnd wait....................." +
            "\nClick to continue.";
        if (Input.GetKeyDown(KeyCode.Mouse0)) { currentState = States.bad; }
    }

    private void BadEnd()
    {
        titleObject.text = "BAD END";
        textObject.text = "\nit's the bad ending";
    }

    private void GoodEnd()
    {
        titleObject.text = "GOOD END";
        textObject.text = "\nit's the good ending";
    }

}