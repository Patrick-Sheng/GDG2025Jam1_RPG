EXTERNAL canbuypancake()
EXTERNAL boughtpancake()

-->main

===main===
#speaker:Dr. Green #portrait:dr_green_neutral #layout:left
{ boughtpancake():

    Sorry Dear, we only sell 1 pancake per customer #layout:default
    -> END

- else:
    Hello dear, would you like a pancake? Its only 21 dollars #layout:default
    
        +[Yes]
            { canbuypancake():
            Here you go dear (+1 pancake)#plus1pancake
            -> END
            
            - else:
            oh you don't have the money? that's ok dear you can come back anytime
            -> END
            }
            
            
        +[No]
            ok dear 
            -> END
            


 }
