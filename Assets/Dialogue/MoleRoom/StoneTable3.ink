EXTERNAL hasDogBone()
EXTERNAL hasTruffle()
EXTERNAL hasRuby()

--> main

=== main ===

"In earthen skin a secret sleeps, where cracked and dry, the red heart peeps." #layout:default
#UPDATE_VAR:currentInteractingStoneTable,3

{ hasDogBone() or hasTruffle() or hasRuby():
    + [Place something here]
        -> place_item
    -> DONE
}

+ [Leave]
    -> END

=== place_item ===

Choose item to place:

{ hasDogBone():
    + [Place the Dog Bone]
        You placed the Dog Bone on the table.
        #UPDATE_VAR:placedDogBone,true
        -> END
}

{ hasTruffle():
    + [Place the Truffle]
        You placed the Truffle on the table.
        #UPDATE_VAR:placedTruffle,true
        -> END
}

{ hasRuby():
    + [Place the Ruby]
        You placed the Ruby on the table.
        #UPDATE_VAR:placedRuby,true
        -> END
}