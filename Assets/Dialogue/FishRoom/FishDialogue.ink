EXTERNAL FishPlayed()
EXTERNAL FullHands()
-> start
=== start ===
{ FishPlayed():
    { FullHands():
        Thank you for the water. I feel my tank filling up #fulltankmore #fullhandsfalse
        ->DONE
    -else:
        My water is disapearing. If you want to help me, I won’t stop you.
        ->DONE
    }
- else:
...Hello. A new arrival. I could tell by the way you walk, unsure. Still searching.
I’ve been in this tank for a long time. Longer than most can remember.
My water… it’s disappearing. Bit by bit.
They say it’s ‘natural,’ but you’re smarter than that, aren’t you?
It’s punishment. I... said something I shouldn't have.
About Him.
I knew something I wasn’t supposed to know. And now the water goes.
Still, you’re free to try. If you want to help me, I won’t stop you. #FishPlayed
    ->DONE
}
