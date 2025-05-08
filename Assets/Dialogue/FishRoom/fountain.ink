EXTERNAL FishPlayed()
EXTERNAL FullHands()
EXTERNAL fountaindone()
-> start

=== start ===
{ FishPlayed():

    {fountaindone():
        You have already taken from this fountain
        ->DONE
    -else:
        {FullHands():
        You are already holding water
        ->DONE
        -else:
        You pick up some water with your hands #pickUpWater #fountaindone
        ->DONE
        }
    
    }




-else:
Its a fountain
    -> END
}
