EXTERNAL FishPlayed()
EXTERNAL FullHands()
EXTERNAL tankisfull()
EXTERNAL changePond()
EXTERNAL thankyou()

-> start
=== start ===
{ FishPlayed():
    {FullHands(): 
        {tankisfull():
                {changePond():
                Thank you for your kindness, go to the pond to see the truth.
                -else:
                ...That feels like warmth.  
                I had forgotten what it’s like to be cared for without a reason.  
                Let me give you something in return—a truth, or perhaps... a warning.  
                The ‘God’ of this place has never judged anyone. Not a single soul.  
                I cannot tell you more. You’ll have to find out what comes next.  
                Go to the pond. I will help you find the 'helper'.   
                ...As someone kind, I hope you can save this world.  
                Goodbye.
                #changePond
                ->DONE
                }
        -else:
        Thank you for the water. I feel my tank filling up #fulltankmore #fullhandsfalse #thankyou
            ->DONE
        }
    -else:
        {thankyou():
        
        You are so kind
        ->DONE
        -else:
        
        My water is disapearing. If you want to help me, I won’t stop you.
        }
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
