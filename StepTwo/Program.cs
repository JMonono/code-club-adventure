// First let's write some text out to the screen to start telling our story :)

// The 'Console.WriteLine' command is some C# code that helps us print out text to the screen
Console.WriteLine("Welcome to 'Familiar Items - Adventure in The Right Way Up'");
Console.WriteLine("This is a thrilling adventure that will not test your skills and nerves!");
Console.WriteLine("But first - please tell us your name:");

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
    List<string> validChoices = ["North", "South", "Quit"];

    Console.WriteLine("You are in a room that is very dark, with just a single small window letting in a tiny " +
                      "amount of light. You can just make out what looks like a pile of clothes in the corner " +
                      "- from the smell it must be a pile of dirty laundry left by a giant who doesn't wash " +
                      "very much. Let's get out of here! [North, South or Quit]");

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
        else if(playerChoice == "South")
        {
            // Player has chosen to go South - this takes them to the HauntedRoom ooooooooo!
            Console.WriteLine("You chose to go south...");
            HauntedRoom();
        }
        else if(playerChoice == "Quit")
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
        else if(playerChoice == "Quit")
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

void HauntedRoom()
{
    List<string> validChoices = ["North", "East", "West", "Quit"];

    Console.WriteLine("As you enter this room you feel a real chill in the air… you can see your breath in front of " +
                      "your face. As you look at the grey stone walls you hear a ghostly sound coming out of " +
                      "thin air... 'Oooooh my name is Derek and my back is killing me today! It’s rubbish being a " +
                      "ghost!'. This doesn’t sound good! [North, East, West or Quit]");

    var playerChoice = string.Empty;

    while(validChoices.Contains(playerChoice) is false)
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
    // The player has made a wrong turn - they never made it back home :(
    Console.WriteLine("No one said The Right Way Up would be easy to escape... you take a wrong turn and " +
                      "come across a cute looking Guinea Pig. Unfortunately it is one of the most fearsome " +
                      "creatures in The Right Way Up and with one horrific 'SQUEAK!' your brain is scrambled " +
                      "and all you can think about is lettuce and chew toys. You are stuck here forever! " +
                      "Don't worry though - you can always press [Enter] to play again :)");
    Console.ReadLine();
    Environment.Exit(0);
}