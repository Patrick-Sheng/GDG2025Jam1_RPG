//EXTERNAL inventory stuff

-> main
=== main === 

//{ hasKey():
  //  Thanks so much for helping me!
    //I better file that complaint soon. 

//- else:

    Hey, can you help me out? I'm in a bit of a pickle.
    There's a huge leak in my ceiling and I need someone to help me catch all the water.
    :

        + [How did you manage to get a water leak in a water temple?]
            -> a1

        === a1 ===
        Honestly, I wonder myself. Who knows what the guy upstairs is doing.
        :

        + [You should file a complaint.]
            -> a2

        === a2 ===
        You're right, I really should.
        Well we better hurry, the leak's not getting any smaller!
        :

        + [Let's go!]
        #goToBucketCatchRoom
            -> DONE
          //  + [Sorry, I got to go.]
         //   Sigh, I guess I'll be having a leaky night.
            //-> END
        -> DONE

   // Wow, thank you so much!
   // I don't know how I can repay you, but here's a key I found the other day - maybe you //can find some use for it!
   #plusFlowerKey
//


//-> END
