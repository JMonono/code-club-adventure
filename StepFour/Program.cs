// First let's write some text out to the screen to start telling our story :)

// The 'Console.WriteLine' command is some C# code that helps us print out text to the screen
Console.WriteLine("Welcome to 'Escape from Zen!' - we are escaping from the upside down version of Zen!!!");
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
ZenBuddysLair();
return;

void ZenBuddysLair()
{
    // We should always start off by defining the valid directions the player can go. Before we only had one direction to go in,
    // but now we need two (so exciting)! Now that we need to store more than direction, we need a special type of *VARIABLE* to store that.
    // We will use a *COLLECTION* type which can store multiple values in - the C# type we will use is a `List`
    List<string> validChoices = ["North", "South", "East", "West", "Quit"];

    Console.WriteLine("You are in a room that is very dark, with just a single small desk covered in posion ivy " +
                      "You can just make out some old bones in the corner, mixed in with some fur balls that look like they have " +
                      "been coughed up by a very large cat. " +
                      $"Let's get out of here! [{string.Join(", ", validChoices)}]");

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
            DeadEnd(comingFromRoom: "ZenBuddysLair");
        }
        else if (playerChoice == "South")
        {
            // Player has chosen to go South - this takes them to the HauntedRoom ooooooooo!
            Console.WriteLine("You chose to go south...");
            LethalServerRoom();
        }
        else if (playerChoice == "East")
        {
            // Player has chosen to go East - this takes them to the ShowSkeletons room!
            Console.WriteLine("You chose to go east...");
            SquidGamesRoom();
        }
        else if (playerChoice == "West")
        {
            // Player has chosen to go West - this takes them to the ShadowyFigure room
            Console.WriteLine("You chose to go west...");
            DangerHub();
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

// This room should allow the player to go North (to our special DeadEnd room that has a useful tool in!), South (to the Exit and freedom!), East (to a CockroachCafe())
// and West (back to the ZenBuddysLair).
void SquidGamesRoom()
{
    List<string> validChoices = ["North", "East", "South", "West", "Quit"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination :)
    System.Console.WriteLine("A big strange mannequin is standing at the front of the room. You hear a voice over the speaker saying. Let's play 'RED LIGHT, GREEN LIGHT'" +

    $"We should run!!! [{string.Join(", ", validChoices)}]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "North")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose North... looks like a poor choice to me");

            // And now send them off to the right room by calling the right method
            DeadEndWithTool();
        }
        else if (playerChoice == "East")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose east.. I can see bugs coming from that room :(");

            // And now send them off to the right room by calling the right method
            CockroachCafe();
        }
        else if (playerChoice == "South")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose south.. I feel lucky");

            // And now send them off to the right room by calling the right method
            ExitScene();
        }
        else if (playerChoice == "West")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose west.. back back back");

            // And now send them off to the right room by calling the right method
            ZenBuddysLair();
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
void CockroachCafe()
{
    List<string> validChoices = ["Fight", "Flight"]; // Only two choices now - it really is the end!

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination :)
    System.Console.WriteLine("Dimly lit chaotic room, filled with the smell of rotten food. There are cockroaches everywhere :(. You are getting food thrown at you by a dinner lady" +
    " you grab a dinner tray to defend yourself! " +
    $"Choose what to do next!!! [{string.Join(", ", validChoices)}]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we have to decide what happens when the player fights! Could they escape?!
        if (playerChoice == "Fight")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose Fight... This was a big mistake! You take a rock hard piece of chicken to the face and then you slip on the sauces spilled on the ground" +
            "You will never leave here alive, cursing your aggressive nature and wishing you'd just eaten some of those unusual chips!!!");

            // And now send them off to the success or failure :)
            DeathScene();

        }
        // Now we have to decide what happens when the player runs away! Could they survive?!
        else if (playerChoice == "Flight")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose Flight... You dodged the frozen chicken and humped over the spilled sauces and jump through a door into daylight");

            // And now send them off to the success or failure :)
            ExitScene();

        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

// This room is just like our normal DeadEnd... but we want to give the player a surprise! Let's give the players a choice that allows them to find and take a tool
// which might save them later (or not!)
void DeadEndWithTool()
{
    List<string> validChoices = ["Take", "South", "Quit"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination and include a description of something enticing the player could pick up...
    System.Console.WriteLine("You have reached another brick wall... but you can see the edge of something plasticky and white in the wall. What to do?!" +
    $"[{string.Join(", ", validChoices)}]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "Take")
        {
            // Write a cool description that explains what they have just picked up!
            System.Console.WriteLine("You grab a Nez keycard from the wall - it has a strange face on it of someone called NMGDale. Not sure if this will be useful or not!!!");

            // And now let's record that the player has picked up the tool
            playerPickedUpTool = true;

            // And now send them back to the room they came from
            SquidGamesRoom();
        }
        else
        {
            // Player has made a mistake - ask them to try again
            Console.WriteLine("I'm not sure where you want to go - please try again");
        }
    }
}

/// Now you have a chance to write some code yourself - the player should be able to move North (to the CameraScene room), South (to a DeadEnd)
/// or East (basically back to the ZenBuddysLair room they came from). If you can't remember how to define the possible player choices and
/// capture which direction the player wants to go, take a look at one of our previous rooms (like the ZenBuddysLair or HauntedRoom)
void DangerHub()
{
    List<string> validChoices = ["North", "South", "East"]; // Remember to add in the other valid player choices here... and don't forget the "Quit" option :)

    var playerChoice = string.Empty;

    // Then we write out a description of the room they are in - use your imagination :)
    System.Console.WriteLine("You are in the main hub of Nez. Ceiling tiles are crumbling, cleaning stuff is everywhere and there are more of those huge hairballs" +
    $"What shall we do>?! [{string.Join(", ", validChoices)}]");

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Now we know where the player wants to go - can you remember how we check what the player typed in? (HINT: You will need to replace "false"
        // below with your condition).
        // REMEMBER: You will need a condition for each of the valid choices a player can make!
        if (playerChoice == "North")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose North... hope we have the right gear");

            // And now send them off to the right room by calling the right method
            ReceptionOfDoom();
        }
        else if (playerChoice == "East")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose East... think we're going in circles here");

            // And now send them off to the right room by calling the right method
            ZenBuddysLair();
        }
        else if (playerChoice == "South")
        {
            // Write a message that confirms where the player has chosen to go
            System.Console.WriteLine("You chose South... looks like you're going into an elevator - hope it's working");

            // And now send them off to the right room by calling the right method
            DeadEnd("DangerHub");
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
void ReceptionOfDoom()
{
    List<string> validChoices = new List<string> { "North", "South", "Quit" };
    var playerChoice = string.Empty;

    // Description of the room
    Console.WriteLine("You find yourself in the Reception of Doom, a dark, desolate place where the air is thick with dust. " +
                      "The dim light flickers ominously, casting shadows of long-forgotten office furniture and eerie, " +
                      "twisted cobwebs. The walls are lined with flickering monitors displaying cryptic error messages. " +
                      "A rusty keycard reader blinks weakly near the only apparent exit to the North. " +
                      "To the South, you can see the darkened hallway from which you entered, " +
                      "and the atmosphere hints that going back might just prolong the inevitable. " +
                      "Your choices are limited, but each path could be your last...\n" +
                      $"What shall we do? [{string.Join(", ", validChoices)}]");

    while (!validChoices.Contains(playerChoice))
    {
        playerChoice = Console.ReadLine();

        if (playerChoice.Equals("North", StringComparison.OrdinalIgnoreCase))
        {
            if (playerPickedUpTool)
            {
                Console.WriteLine("You swipe your keycard and the door to the North creaks open. You step forward, " +
                                  "heart pounding, as you make your way to the exit. Congratulations, you've escaped!");
                // Code to end the game or move to the final victory room
                ExitScene();
            }
            else
            {
                Console.WriteLine("You approach the door to the North, but without a keycard, it's locked tight. " +
                                  "The blinking reader seems to taunt you as you realize you can't proceed this way.");
                // Code to handle lack of keycard, like retrying or searching for the keycard
                DeathScene();
            }
        }
        else if (playerChoice.Equals("South", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("You turn back to the South, retracing your steps through the musty hallway. " +
                              "Perhaps you'll find another way...");
            // Code to send them back to the previous room
            DangerHub();
        }
        else if (playerChoice.Equals("Quit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("You decide it's best to quit while you're ahead. The adventure ends here.");
            Environment.Exit(0); // Ends the application
        }
        else
        {
            Console.WriteLine("I'm not sure where you want to go - please try again.");
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
    Console.WriteLine($"You have reached a dead end – better turn back! [{string.Join(", ", validChoices)}]");

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
            if (comingFromRoom == "ZenBuddysLair")
            {
                ZenBuddysLair();
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

void LethalServerRoom()
{
    List<string> validChoices = ["North", "East", "West", "Quit"];

    Console.WriteLine("As you enter the room the hanging ceiling light nearly bops you on the head. One corner of the room is hotter than a dragon's sauna, the other side is colder than ice. If you stay in here too long you'll probably get shocked from the hanging wires. " +
                      $" This doesn’t sound good let's go!!! [{string.Join(", ", validChoices)}]");

    var playerChoice = string.Empty;

    while (validChoices.Contains(playerChoice) is false)
    {
        playerChoice = Console.ReadLine();

        // Let's check what the player entered and direct them to the right place - they might even escape now!
        if (playerChoice == "West")
        {
            // Player has chosen to go West - this takes them to safety!
            Console.WriteLine("You chose to go west...");
            DeathScene();
        }
        else if (playerChoice == "East")
        {
            // Player has chosen to go east - this takes them to a horrible death!
            Console.WriteLine("You chose to go east...");
            ExitScene();
        }
        else if (playerChoice == "North")
        {
            // Player has chosen to go north - this takes them back to the ZenBuddysLair()
            Console.WriteLine("You chose to go north...");
            ZenBuddysLair();
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
    Console.WriteLine("Running, you enter the next room and see what looks like a window to somewhere" +
                      " grey and rainy - it must be the portal home! You hold your breath and jump towards " +
                      "the window... and find yourself sat in a puddle outside the Arndale Centre. " +
                      "You've made it home! Congratulations player - press [Enter] to play again and see what else " +
                      "The Right Side Up has in store!");
    Console.ReadLine();
    Environment.Exit(0);
}

void DeathScene()
{
    var deaths = new Dictionary<int, string>()
    {
        {1, "Zen Buddy springs out from the shadows - you were too busy picking your nose to see him. He sinks his poisonous teeth into your arm and you wish you didn't like picking your nose so much. YOU FAILED!!!"},
        {2, "You end in an elevator and the doors close and lock behind you. You can semell a terrible smell like Zen Buddy has been burping in here all day. There is no peg for your nose and no escape. YOU FAILED!!"},
        {3, "You end up in a crumbling room and you hear a loud 'CRASH' as a ceiling tile falls and splats you underneath. You haven't been eating your Weetabix so can't pull it off. YOU FAILED!!!"},
        {4, "You are caught by Zen Buddy and he drags you back to the start because he's a joker and he likes annoying you. You'll have to play again!!!"},
    };

    var rng = new Random();
    var deathNumber = rng.Next(1, 4);

    if (deathNumber == 4)
    {
        System.Console.WriteLine($"{deaths[deathNumber]}");
        ZenBuddysLair();
    }
    else
    {
        // The player has made a wrong turn - they never made it back home :(
        Console.WriteLine("No one said 'Escape from Nez' would be easy to play... " +
                            $"{deaths[deathNumber]}" +
                          "Don't worry though - you can always press [Enter] to play again :)");
        Console.ReadLine();
        Environment.Exit(0);
    }
}