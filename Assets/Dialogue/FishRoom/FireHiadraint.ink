EXTERNAL FishPlayed()
EXTERNAL FullHands()
EXTERNAL FireHDone()
-> start

=== start ===
{ FishPlayed():

    {FireHDone():
        You have already taken from this fire hidrant
        ->DONE
    -else:
        {FullHands():
        You are already holding water
        ->DONE
        -else:
        You pick up some water with your hands #pickUpWater #FireHDone
        ->DONE
        }
    
    }




-else:
Its a fire hidrant
    -> END
}
