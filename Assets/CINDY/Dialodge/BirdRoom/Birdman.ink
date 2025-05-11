EXTERNAL winBirdgame()

{winBirdgame():
Hahaha you won
you can keep the flower key, I wasnt using it anyway

-else:


Welcome to my world, you trapped soul.

How did you get here? #speaker:Ms. Yellow #portrait:ms_yellow_neutral #layout:default
+ [By a car carsh.]
    Oh, that's insane, same as me.
    -> next

+ [I don't know.]
    You silly humanbeing, what do you know?
    -> next
    
}

=== next ===

Well, no matter how you got here... you're here now.  

And I have just the task for a wandering soul like you.

+ [What task?]
    A test of skill, reflexes, and sheer bird-based chaos. 
    Only then will you be deemed worthy of my respect - and maybe a snack.
    #StartBirdGame
    -> DONE

+ [Uhh, no thanks.]
    Okok, you coward. Don't ever come back.
    -> DONE
    
->END




