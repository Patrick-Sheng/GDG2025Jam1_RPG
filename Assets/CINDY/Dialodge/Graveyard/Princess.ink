EXTERNAL graveYard()


{graveYard():
Thank you for matching my favourite flowers!
I hope you enjoy the bone

-else:
Seems like you got the key to enter my place. #deleteKey

Do you like my garden? #layout:default
+ [Of course!]
    Oh I'm glad, you have good taste.
    -> next

+ [No, it is ugly.]
    Hmmm... maybe you need to go check your eyes instead.
    -> next
}
=== next ===
Anyway, are you ready to receive another quest?
+ [What quest?]
    Matching my favourite flowers.
    #StartFlowerGame
    -> DONE

+ [Probably not.]
    Ok, bye for now then.
    -> DONE





