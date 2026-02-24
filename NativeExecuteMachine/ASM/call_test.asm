__start:
    go main 


.p main:
    call privet
    out "it works", 1
    ret

    .p poka:
        out "goodbye", 1
        ret


    .p privet:
        out "hello hello", 1
        call poka
        out "if it works", 1
        ret


__stop:
    clear bytes