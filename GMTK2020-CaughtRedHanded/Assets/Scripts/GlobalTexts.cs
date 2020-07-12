using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class stores various texts that will appear in the message box in the game

public class GlobalTexts
{
    private static List<string> tutorialMessages = new List<string> {
        "Yello! I’s Captain Niat Pac. Welcome aboard the UGLY Martian, our mission’s ta collect scientific data as mysterious as the dark side of the moon. Which is why we’re goin’ to--you guessed it--Mercury, to accumulate luminating data for the room-in-ating scientists back home.",
        "Now listen well, don’t let that engine get too hot. Just keep it cool for as looong as possible… but take a break if you need to. Good luck, stay hydrated, and I’ll check in later.",
        "Everything changed when the fire—fire? Fire! Get the extinguisher, quick, the smoke’s- *cough* getting into the ventilation *cough*",
        "I think we’re being shot at by the rock aliens. Tape up any seals you see, as a favor to me.",
        "Howie? I’ve got two words for you: Goose smacker. Bright red, can’t miss it. She’ll knock your tools out of your hand, clever girl.",
        "Uh, you didn’t happen to blow a fuse in the electrical box, didja? If you don’t mind, Madam Adam is complainin’ that there’s no heat in the showers, so please put out them flames and replace it.",
        "It’s awful dark up here, did a wire run into a problem on the way? If you don’t replace it soon, aliens might start to pop out of unexpected places.",
        "Oh, your fan is screwed. Or, it’s never screwed enough? Thoughts for later.",
        "That alarm’s like my child: loud and pointless. And just like him, all you got to do is push the big red button.",
        "Ah, the coolant’s leaking. Flick the lever to drain the water until the leaking stops, then tape it up. Page 501, UGLY Manual."
    };

    private static List<string> displayedTutorialMessagges = new List<string>();

    private static List<string> randomMessages = new List<string> {
        "Have I e’er mentioned that UGLY stands for Unreliable Global Lunar Yacht? Hah… global lunar. Incompetition, the lot of ‘em.",
        "Did I ever tell you? The other day, all of a sudden these men in suits come in askin’ for GrandPac! Nah, knowin’ the suits like I’s does, I says to them I says, “I’m Niat Pac, and what’s it to ya?” Ptooey. They said it’s time to go and, well, here I am.",
        "Given that the Empire State Building was about three Guiseppe’s tall, it takes 289,177 and a third of a Guiseppe to climb on each other’s shoulders and form a bridge to the moon.",
        "Do you want to meet up for munchies later? I packed a fresh goose in the cargo hold, straight outta GrandPac’s barn--uh, don’t tell the suits we have a range. Lunar property is so tight these days.",
        "Madam Adam tells me there’s a ‘borg in the cargo bay. It keeps going on about asimilar somethings. We fed him Nik Nej Jenkin and he was on his way.",
        "… Now I hate to be ta one to tell you this, but, today was meatball sub day. You juuust missed it.",
        "I have to say, I do feel like a right idjit. Them showers? They ain’t no showers.",
        "You ever wonder what powers our ship? Don’t tell anyone, but, it might just be because we’re such good pals, you and I. That’s why they call it a friendship.",
        "So further is for abstract nouns and farther is for physical goals—sorry, that was meant to be sent to Professor Forp, I’m getting my doctorate in clarinet performance.",
        "You ever work for IoI? They use some rigid virtual reality learning so I can’t even paint my locker! Absurdities upon absurdities.",
        "I haven’t gotten a response from your panel in a while, so I’m just checking in on you, making sure you’re okay… I made cookies if you want some when your break comes.",
        "Oh, butter my biscuits! I didn’t pack the right goose smacker, the one I casted out of molten lead. This is the one issued to me by court authorities after mine was confiscated. Talk about fun police.",
        "When you’re in space, no one can hear me scream because of all the ruckus you’re making down there.",
        "“For whom the bell tolls…” I ought to give Pa a hug when we get back.",
        "Open the blast doors, open the blast doors! I accidentally closed the engine exhaust vent—phew!",
        "Wait a minute… Can you tell me how much is left in the fire extinguisher? If you run out, don’t worry, we definitely have more than the one we brought.",
        "You ever wonder why we’re here?",
        "Hey, you think we can get away with resuming our tabletop campaign? Because last I heard, your rogue failed his stealth check against the tarasque.",
        "I wonder if there’s limited memory capacity on these consoles.",
        "Do you believe in the warrior deity, Lady Jingle?",
        "I just wanted you to know, I spent the past five minutes yelling, “secret tunnel,” and it still doesn’t get old.",
        "How does the internet work?",
        "Ladies and gentlefolk, this is Captain Niat Pac speaking. Friendly reminder, where we’re going, we won’t need seatbelts.",
        "I’m slowly losing my sanity being stuck in the same room for weeks on end. Tell me a joke, please?",
        "Fun fact: You can’t breathe when you’re smiling. No really, I’m serious, I’m not serious, I was kidding, I just wanted you to smile.",
        "I might have an explanation for why there’s so many things going wrong where you are, but… you won’t like it.",
        "Has anyone ever made the mistake of flying through acid rain?",
        "I’ve been touching up on my foreign languages. Forte means fortified, vivace means the best possible quality, and crescendo means having to do with the moon. But what language though?"
    };

    /// <summary>
    /// Gives a specific tutorial message
    /// </summary>
    /// <param name="index">desired tutorial number</param>
    public static string GetTutorialMessagge(int index)
    {
        if (TutorialHasNotBeenSeen(tutorialMessages[index]))
            displayedTutorialMessagges.Add(tutorialMessages[index]);

        return tutorialMessages[index];
    }

    /// <summary>
    /// Gives a random message from the comedic list
    /// </summary>
    public static string GetRandomMessage()
    {
        int index = Random.Range(0, randomMessages.Count);
        return randomMessages[index];
    }

    /// <summary>
    /// Gives the list of all tutorials the player has already seen
    /// </summary>
    public static List<string> GetAllSeenTutorials()
    {
        return displayedTutorialMessagges;
    }

    /// <summary>
    /// Checks whether the player has already seen this tutorial
    /// </summary>
    /// <param name="tutorial">message to compare against</param>
    private static bool TutorialHasNotBeenSeen(string tutorial)
    {
        for (int i=0; i<displayedTutorialMessagges.Count; i++)
            if (tutorial.Equals(displayedTutorialMessagges[i]))
            {
                return false;
            }

        return true;
    }
}
