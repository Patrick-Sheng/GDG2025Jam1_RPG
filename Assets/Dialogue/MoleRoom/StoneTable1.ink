EXTERNAL hasDogBone()

-> main

=== main ===
Place item for riddle 1 here:
#UPDATE_VAR:currentInteractingStoneTable,1

{ hasDogBone():
    + [Place the Dog Bone]
        You placed the Dog Bone on the table.
        #UPDATE_VAR:placedDogBone,true
        -> END
    + [Leave]
    -> END
 - else: 
    + [I don't have the item]
        -> END
} 

