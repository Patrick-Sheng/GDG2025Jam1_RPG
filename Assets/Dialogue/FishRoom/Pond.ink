EXTERNAL FishPlayed()
EXTERNAL FullHands()
EXTERNAL ponddone()
-> start

=== start ===
{ FishPlayed():

    {ponddone():
        You have already taken from this source
        ->DONE
    -else:
        {FullHands():
        You are already holding water
        ->DONE
        -else:
        You pick up some water with your hands #pickUpWater #ponddone
        ->DONE
        }
    
    }




-else:
Its a pond
    -> END
}
