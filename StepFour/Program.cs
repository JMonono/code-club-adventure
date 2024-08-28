// First let's write some text out to the screen to start telling our story :)

// The 'Console.WriteLine' command is some C# code that helps us print out text to the screen
Console.WriteLine("Welcome to 'Dungeon Escape!'");
Console.WriteLine("This is a thrilling adventure that *will* test your skills and nerves!");
Console.WriteLine("But first - please tell us your name:");

// We'll need this next variable to store a choice the player can make later!
bool playerPickedUpTool = false;

// Now let's ask the player their name - to do that we will need a *VARIABLE* to store what they tell us
string? name = Console.ReadLine();

// Now we can the *VARIABLE* and make them feel special by writing out their name, using `Console.WriteLine(...)` again :)
// PS - don't worry too much about the $"..." syntax - it just let's us combine variables and text into one string of text
Console.WriteLine($"Great! Welcome, {name} - get ready for a thrilling adventure!");

// Now let's run some code (a *METHOD* in C# terms) that starts the game
IntroScene();
return;

void IntroScene()
{
    // We should always start off by defining the valid directions the player can go. Before we only had one direction to go in,
    // but now we need two (so exciting)! Now that we need to store more than direction, we need a special type of *VARIABLE* to store that.
    // We will use a *COLLECTION* type which can store multiple values in - the C# type we will use is a `List`
    List<string> validChoices = ["North", "South", "East", "West", "Quit"];

    Console.WriteLine("We are in a cell - there is a little window with bars on letting in almost no light." +
    "The room smells like a wet dog and there are things crawling around in the corner that I don't want to think about!!!" +
    "Make a choice: [North, South or Quit]");

    // Now let's create a *VARIABLE* again that will store where the player wants to go
    var playerChoice = string.Empty;

    // Now what we want to do is wait until the player enters a direction we recognise before moving on to the next step. We can achieve that
    // by using a *LOOP*, which only exits when the *CONDITION" we define is equal to `true`. This time the *CONDITION* must check that the player
    // has entered one of several valid choices. As we are using a *COLLECTION* to hold our valid choices, C# gives us some methods that can help us
    // check if the player has entered a valid value

    // By the way, our loop will always run at least once because the first time the condition is checked the `playerChoice` will be empty so *won't*
    // match the direction we expect (North)
    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Here we are using some *CONDITIONAL LOGIC* to check what the player has selected - maybe we can find a neater
        // way to perform this check later?

        if (playerChoice == "North")
        {
            // Player has chosen to go North - this takes them to a DeadEnd()
            Console.WriteLine("You chose to go north...");
            DeadEnd(comingFromRoom: "IntroScene");
        }
        else if (playerChoice == "South")
        {
            // Player has chosen to go South - this takes them to the Dragon room!
            Console.WriteLine("You chose to go south. It feels warm and smoky in this direction...");
            DragonRoom();
        }
        else if (playerChoice == "East")
        {
            // Player has chosen to go East - this takes them to the SuperGuardsRoom room!
            Console.WriteLine("You chose to go east. A lot of voices shouting military comands can be heard...");
            SuperGuardsRoom();
        }
        else if (playerChoice == "West")
        {
            // Player has chosen to go West - this takes them to the GuardsRoom room
            Console.WriteLine("You chose to go west. I hear clinking of armour...");
            GuardsRoom();
        }
        else if (playerChoice == "Quit")
        {
            // The player has had enough - let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            Environment.Exit(0);
        }
        else
        {
            // The player has entered a direction we don't recognise - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

// This room should allow the player to go North (to our special DeadEnd room that has a useful tool in!), South (to the Exit and freedom!), East (to a StrangeCreature())
// and West (back to the IntroScene).
void SuperGuardsRoom()
{
    List<string> validChoices = ["North", "South", "East", "West", "Quit"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination :)
    System.Console.WriteLine("You enter a room with lots of beefy people in military fatigues. THey are waving pool cues and shouting 'WHO POTTED THE RED?!?!'. You don't fancy sticking around: [North, South, East, West, Quit]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "North")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose North. Might not be the right way...");

            // And now send them off to the right room by calling the right method
            DeadEndWithTool();
        }
        else if (playerChoice == "East")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose East. This could be the final showdown...");

            // And now send them off to the final room by calling the right method
            FinalBossRoom();
        }
        else if (playerChoice == "South")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose South. This looks promising...");

            // And now send them off to the final room by calling the right method
            ExitScene();
        }
        else if (playerChoice == "West")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose West. I think we're going back on ourselves here...");

            // And now send them off to the final room by calling the right method
            IntroScene();
        }
        else if (playerChoice == "Quit")
        {
            // The player has had enough - let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            Environment.Exit(0);
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

// This room is our final encounter room and only has two choices... Fight or Flight! One only leads to failure and one leads to freedom - which is which is up to
// you :) Oh and can you find a use for the tool that the player may have found along the way?!
void FinalBossRoom()
{
    List<string> validChoices = new List<string> { "Fight", "Flight" }; // Only two choices now - it really is the end!
    var playerChoice = string.Empty;

    // Description of the room
    Console.WriteLine("You stumble into a dimly lit chamber, the air thick with the stench of decay. Water drips steadily from the cracked stone ceiling, echoing throughout the vast darkness. The walls are adorned with chains and strange markings, almost as if this place was once used for ancient, sinister rituals. As your eyes adjust, you notice something moving in the shadows—a grotesque creature with glowing eyes, hunched over and snarling. Its skin is slick and slimy, and the faint glimmer of sharp teeth catches the meager light. You can feel the weight of its gaze as it sizes you up, a predator eyeing its prey.");

    Console.WriteLine("\nYou have only two choices: \n1. Fight the creature \n2. Run for your life");
    Console.WriteLine("\nType 'Fight' to stand your ground or 'Flight' to flee!");

    while (!validChoices.Contains(playerChoice))
    {
        playerChoice = Console.ReadLine();

        // What happens when the player fights?
        if (playerChoice == "Fight")
        {
            Console.WriteLine("You tighten your grip on your weapon, adrenaline surging through your veins. The creature lunges at you with a bone-chilling screech. You manage to dodge its initial attack and strike back with all your might.");

            // Random success or failure
            Random random = new Random();
            bool isSuccess = random.Next(0, 2) == 0; // 50% chance to succeed

            if (isSuccess)
            {
                Console.WriteLine("Your strike lands true, piercing the creature's heart. It lets out a final, pitiful wail before collapsing into a heap at your feet. You've defeated the creature and a hidden passage reveals itself behind the altar. You've escaped!");
                // Proceed to the next part of the game or end successfully
            }
            else
            {
                Console.WriteLine("Your attack misses, and the creature pounces, knocking you to the ground. Its sharp claws tear into you as darkness overwhelms you. You fought bravely, but the creature was too strong. This is the end.");
                // Game over or another branch for failure
            }
        }
        // What happens when the player runs away?
        else if (playerChoice == "Flight")
        {
            Console.WriteLine("Your instincts scream at you to run. You turn on your heels and sprint back the way you came, the creature's furious roars echoing behind you.");

            // Random success or failure
            Random random = new Random();
            bool isSuccess = random.Next(0, 2) == 0; // 50% chance to succeed

            if (isSuccess)
            {
                Console.WriteLine("You manage to outrun the creature, ducking and weaving through the dark corridors. You can hear it snarling behind you, but finally, you find a heavy door and slam it shut just in time. You take a moment to catch your breath. You've escaped!");
                // Proceed to the next part of the game or end successfully
            }
            else
            {
                Console.WriteLine("As you flee, you hear the creature's footsteps growing closer. You risk a glance back and trip over a loose stone. Before you can get back up, the creature is upon you. You struggle, but its strength is overwhelming. This is the end.");
                // Game over or another branch for failure
            }
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure what you want to do - please type 'Fight' or 'Flight'.");
        }
    }
}

// This room is just like our normal DeadEnd... but we want to give the player a surprise! Let's give the players a choice that allows them to find and take a tool
// which might save them later (or not!)
void DeadEndWithTool()
{
    List<string> validChoices = ["Take", "South"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination and include a description of something enticing the player could pick up...
    System.Console.WriteLine("This looks like a dead end... but something is glinting in the wall. It looks like a handle...");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "Take")
        {
            // Write a cool description that explains what they have just picked up!
            System.Console.WriteLine("You have chosen to pull the handle... and you pull out a sword! It might be made of rubber but you never know");

            // And now let's record that the player has picked up the tool
            playerPickedUpTool = true;

            // And now send them back to the room they came from
            SuperGuardsRoom();
        }
        else if (playerChoice == "South")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose South. Back we go...");

            // And now send them off to the final room by calling the right method
            SuperGuardsRoom();
        }
        else if (playerChoice == "Quit")
        {
            // The player has had enough - let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            Environment.Exit(0);
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

/// Now you have a chance to write some code yourself - the player should be able to move North (to the CameraScene room), South (to a DeadEnd)
/// or East (basically back to the IntroScene room they came from). If you can't remember how to define the possible player choices and
/// capture which direction the player wants to go, take a look at one of our previous rooms (like the IntroScene or HauntedRoom)
void GuardsRoom()
{
    List<string> validChoices = ["North", "East", "South"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination :)
    System.Console.WriteLine("You are in a ring like something from the Coliseum in Ancient Rome. You can see two gladiators throwing potatoes at each other. You don't like potatoes so think it's time to go: [North, East, South, Quit]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "North")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose north. You can hear tapping on a keyboard and someone talking loudly on the phone..");

            // And now send them off to the right room by calling the right method
            Receptionist();
        }
        if (playerChoice == "East")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose east. Back back back..");

            // And now send them off to the right room by calling the right method
            IntroScene();
        }
        if (playerChoice == "South")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose south. Hope you like looking at brick walls..");

            // And now send them off to the right room by calling the right method
            DeadEnd("GuardsRoom");
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

// I will leave this room to you to code - but it should let the player go North (Exit) or South (back to where they came from). And don't forget
// we should let them Quit if they hate our game :)
void Receptionist()
{
    List<string> validChoices = new List<string> { "North", "South", "Quit" }; // Choices to go north, south, or quit the game
    var playerChoice = string.Empty;

    // Description of the room
    Console.WriteLine("You enter a dimly lit room that oddly resembles a waiting area. A rusty desk sits in the middle, and behind it, a skeletal receptionist with a crooked smile and empty eye sockets stares at you. Faded posters on the walls hint at long-forgotten rules of the dungeon. The receptionist raises a bony finger, pointing in two directions.");

    Console.WriteLine("\nThe receptionist speaks in a raspy voice: 'North leads to the unknown, South to familiar dangers. Or you can Quit if you dare.'");
    Console.WriteLine("\nChoose your path: 'North', 'South', or 'Quit'.");

    while (!validChoices.Contains(playerChoice))
    {
        playerChoice = Console.ReadLine();

        if (playerChoice == "North")
        {
            Console.WriteLine("You nod and head north, past the receptionist's unblinking gaze, deeper into the shadows.");
            // Continue the game with the northern path
            ExitScene();
        }
        else if (playerChoice == "South")
        {
            Console.WriteLine("You choose the southern path, retracing your steps through familiar territory.");
            // Continue the game with the southern path
            GuardsRoom();
        }
        else if (playerChoice == "Quit")
        {
            Console.WriteLine("The receptionist nods solemnly. 'Some escapes are just another form of imprisonment.' You turn away, and the game ends.");

            // The player has had enough - let's stop the game!
            Environment.Exit(0);

        }
        else
        {
            Console.WriteLine("The receptionist tilts its head. 'Choose wisely: North, South, or Quit.'");
        }
    }
}


// This is a method that also accepts a *PARAMETER* called 'comingFromRoom'. Perhaps we can use the value stored in this
// parameter to help the player get back to the room they came from?
void DeadEnd(string comingFromRoom)
{
    // Again we set up the valid directions the player can move here
    List<string> validChoices = ["South", "Quit"];

    // Then we write out a description of the room they are in - they can only go back to the room they came from though :)
    Console.WriteLine("You have reached a dead end – better turn back! [South or Quit]");

    string? playerChoice = string.Empty;

    // Can you see we are using another *LOOP*, which will only end when the player gives us a direction we recognise?
    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Let's use some *CONDITIONAL LOGIC* again to check what the player has entered
        if (playerChoice == "South")
        {
            // And now we use *CONDITIONAL LOGIC* to check the *PARAMETER* "comingFromRoom" to figure out which room they came from.
            // What do you think would happen if the *PARAMETER* contained a value we didn't recognise?
            if (comingFromRoom == "IntroScene")
            {
                IntroScene();
            }
            else
            {
                // If we somehow reach here our code has a bug in it somewhere - so the player is stuck forever :O
                Console.WriteLine("I don't know where you came from... but now you're stuck here until you pass out from boredom!");
                Environment.Exit(0);
            }
        }
        else if (playerChoice == "Quit")
        {
            // The player has had enough - let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            Environment.Exit(0);
        }
        else
        {
            // The player has entered a direction we don't recognise - let's get them to try again
            Console.WriteLine("I don't understand that choice - please try again");
        }
    }
}

void DragonRoom()
{
    List<string> validChoices = ["North", "East", "West", "Quit"];

    Console.WriteLine("In this room there is a small orange dragon. Beware! ALthough it does look cute you can see burnt objects that look like burnt underpants. WHere to next? [North, East, West or Quit]");

    var playerChoice = string.Empty;

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Let's check what the player entered and direct them to the right place - they might even escape now!
        if (playerChoice == "West")
        {
            // Player has chosen to go West - this takes them to safety!
            Console.WriteLine("You chose to go west...");
            ExitScene();
        }
        else if (playerChoice == "East")
        {
            // Player has chosen to go east - this takes them to a horrible death!
            Console.WriteLine("You chose to go east...");
            DeathScene();
        }
        else if (playerChoice == "North")
        {
            // Player has chosen to go north - this takes them back to the IntroScene()
            Console.WriteLine("You chose to go north...");
            IntroScene();
        }
        else if (playerChoice == "Quit")
        {
            // Player has chosen to quit - let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            Environment.Exit(0);
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

void ExitScene()
{
    // The player has got to the exit - they can escape back to Manchester :)
    Console.WriteLine("You see an open door and a Smart Car with the engine running. The M60 is visible in the distance - I think you have found your escape route! Congratulations player - press [Enter] to play again and see what else " +
                      "Dungeon Escape has in store!");
    Console.ReadLine();
    Environment.Exit(0);
}

void DeathScene()
{

var deaths = new Dictionary<int, string>()
{
    {1, "You stumble into the room and it feels very warm. The small orange dragon burped and a massive flame poured into the room. You are DEAD!"},
    {2, "You enter the room and one of the angry guards jabs you with the pool cue. 'YOU TOOK MY RED?!'. YOU ARE DEAD!"},
    {3, "You enter the room and Carlos Alcaraz is playing tennis.He hates being distured and throws his racket towards your dome. Hits you full on YOU ARE DEAD"},
};

Random random = new Random();
            var deathNumber = random.Next(1, 3);

    // The player has made a wrong turn - they never made it back home :(
    Console.WriteLine($"{deaths[deathNumber]}"+
                      "Don't worry though - you can always press [Enter] to play again :)");
    Console.ReadLine();
    Environment.Exit(0);
}