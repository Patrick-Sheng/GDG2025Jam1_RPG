EXTERNAL hasbone()
   // { hasbone():
   // - else:
       // HEY! Where's my snack??
         
   // }

Ruff ruff!
Ya got any snacks? 
+ [Yup, take this!]
    { hasbone():
    (Ooooh thanks so much!) #takeBone
    scoff scoff* #dogMovesToLeft 
    -> DONE
    - else:
        HEY! Where's my snack??
        -> DONE
}
+ [No sorry]
    Oh, okay. 
    (tail stops wagging and ears flop down)
    -> DONE
