// First let's write some text out to the screen to start telling our story :)

// The 'Console.WriteLine' command is some C# code that helps us print out text to the screen
Console.WriteLine("Welcome to 'My First Adventure Game - Pretty Boring'");
Console.WriteLine("This is a not so thrilling adventure that will not test your skills or nerves very much!");
Console.WriteLine("But first - please tell us your name:");

// Now let's ask the player their name - to do that we will need a *VARIABLE* to store what they tell us
string? name = Console.ReadLine();

// Now we can the *VARIABLE* and make them feel special by writing out their name, using `Console.WriteLine(...)` again :)
// PS - don't worry too much about the $"..." syntax - it just let's us combine variables and text into one string of text
Console.WriteLine($"Great! Welcome, {name} - are you ready for a (not) thrilling adventure?!");

// Now let's run some code (a *METHOD* in C# terms) that starts the game
IntroScene();
return;

void IntroScene()
{
    // We should always start off by defining the valid directions the player can go. Let's create another *VARIABLE*
    // to store that value - don't worry the game will get more interesting soon!
    string validDirection = "North";

    Console.WriteLine("You are in a murky room that smells of fish which has only one door out. I guess you'll" +
                      " have to go through it! [North]");

    // Now let's create a *VARIABLE* again that will store where the player wants to go. Notice that this time we have used a
    // different keyword for defining the variable: `var`. We just set the starting value to an empty string (which looks like "" in C#)
    var playerChoice = string.Empty;

    // Now what we want to do is wait until the player enters a direction we recognise before moving on to the next step. We can achieve that
    // by using a *LOOP*, which only exits when the *CONDITION" we define is equal to `true`. In this case we set the condition to be that the
    // direction the player enters must eaxactly match the only direction we defined as valid earlier. When you run the code try adding a dodgy
    // direction and see what happens :)

    // By the way, our loop will always run at least once because the first time the condition is checked the `playerChoice` will be empty so *won't*
    // match the direction we expect (North)
    while (playerChoice != validDirection)
    {
        playerChoice = Console.ReadLine();

        // Here we are using some *CONDITIONAL LOGIC* to check what the player has selected - maybe we can find a neater
        // way to perform this check later?

        if (playerChoice == "North")
        {
            // Player has chosen to go north - this takes them to a DeadEnd()
            Console.WriteLine("You chose to go north...");
            DeadEnd(comingFromRoom: "IntroScene");
        }
        else if(playerChoice == "Quit")
        {
            // The player has had enough - which is fair as they can only go back and forwards between a Dead End :) Let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            return;
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
    var validDirection = "South";

    // Then we write out a description of the room they are in - they can only go back to the room they came from though :)
    Console.WriteLine("You have reached a dead end – better turn back! [South]");

    string? playerChoice = string.Empty;

    // Can you see we are using another *LOOP*, which will only end when the player gives us a direction we recognise?
    while (playerChoice != validDirection)
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
                break;
            }
        }
        else if(playerChoice == "Quit")
        {
            // The player has had enough - which is fair as they can only go back and forwards between a Dead End :) Let's stop the game!
            Console.WriteLine("I guess the adventure was too thrilling and you have chosen to QUIT... bye!");
            return;
        }
        else
        {
            // The player has entered a direction we don't recognise - let's get them to try again
            Console.WriteLine("I don't understand that choice - please try again");
        }
    }
}