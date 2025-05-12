EXTERNAL PlacedAll()

-> main

=== main ===


{PlacedAll():
How did you know where to place which items ??????
->DONE
-else:

Well hello again!
This is a riddle puzzle room.
You'll need to solve these riddles, and bring the riddle items to the table to move on.


}
-> options

=== options ===
What can I help you with?

+ [Read riddle]
    -> riddles

+ [Read hint]
    Go back to the main room and interact with objects to see if you can pick them up.
    -> options

+ [Leave]
    Ok bye.
    -> END

=== riddles ===
Select the riddle you want to read:

+ [Riddle 1]
    Riddle 1: "Left by one who once would bark, now it lies where teeth made mark."
    ++ [Go Back]
        -> options

+ [Riddle 2]
    Riddle 2: "Two are twins, but one has gleam— Find the one that caught a dream."
    ++ [Go Back]
        -> options

+ [Riddle 3]
    Riddle 3: "In earthen skin a secret sleeps, where cracked and dry, the red heart peeps."
    ++ [Go Back]
        -> options
